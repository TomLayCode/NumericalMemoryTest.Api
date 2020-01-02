import React, { Component } from 'react';
import { Answer } from './Answer';
import { Question } from './Question';
import { Results } from './Results';

export class NumericalTest extends Component {
    constructor(props){
        super(props);

        this.state = { 
            numbers: [], 
            testLength: 0, 
            pointsAwarded: 0,
            loading: false,
            counter: 0,
            showQuestion: true,
            answers: [],
            result: null,
            isOver: false
        }

        this.startCountDown = this.startCountDown.bind(this);
        this.submitAnswer = this.submitAnswer.bind(this);
        this.toggleShowQuestion = this.toggleShowQuestion.bind(this);
        this.calculateScore = this.calculateScore.bind(this);
    }

    componentDidMount(){
        this.getTestSettings()
            .then(() => {
                this.startCountDown();
            });
    }

    submitAnswer(number, timespan) {
        const answers = this.state.answers.slice();
        answers.push({
            expected: this.state.numbers[this.state.counter],
            actual: number,
            timeTakenMs: timespan
        });

        this.setState({
            answers,
            counter: this.state.counter + 1,
            showQuestion: true});
    }

    calculateScore() {
        let score = 0,
            numberCorrect = 0,
            numberIncorrect = 0;

        for (let answer of this.state.answers) {
            if (answer.actual === answer.expected) {
                score += this.state.pointsAwarded;
                numberCorrect++;
            } else {
                numberIncorrect++;
            }
        }

        return {
            score,
            numberCorrect,
            numberIncorrect
        };
    }

    async saveAnswers(score) {
        await fetch('api/NumericalMemoryTest/SubmitResults', {
            method: 'POST',
            headers: {
                'content-type' : 'application/json'
            },
            body: JSON.stringify(score)
        });
    }

    startCountDown() {
        setTimeout(async ()=>{
            const result = this.calculateScore();
            await this.saveAnswers(result);

            this.setState({
                isOver: true,
                result
            });
        }, this.state.testLength * 1000);
    }

    toggleShowQuestion() {
        this.setState({
            showQuestion: !this.state.showQuestion
        });
    }

    render() {
        if (this.state.loading) return(<p><em>Loading...</em></p>);

        if (this.state.isOver) {
            return (
                <Results
                    answers={this.state.answers}
                    result={this.state.result}
                />
            );
        }

        return this.state.showQuestion
            ? <Question
                number={this.state.numbers[this.state.counter]}
                countdownOver={this.toggleShowQuestion}
              />
            : <Answer submitAnswer={this.submitAnswer} />            
    }

    async getTestSettings(){
        this.setState({
            isLoading: true
        });

        const response = await fetch('api/NumericalMemoryTest/GetSettings');
        const data = await response.json();
        this.setState({testLength: data.testLength, pointsAwarded: data.score});

        await this.getTestNumbers();

        this.setState({
            isLoading: false
        });
    }

    async getTestNumbers(){
        const response = await fetch('api/NumericalMemoryTest/GetNumbers');
        const data = await response.json();
        this.setState({ numbers: data, loading: false});
    }
}