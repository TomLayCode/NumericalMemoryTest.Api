import React from "react";
import ResultsGraph from "./ResultsGraph";
import { Link } from "react-router-dom";

function ScoreResult(props) {
    return <h3><span style={{ fontWeight: 400, fontSize: "0.85em" }}>{props.label}:</span> {props.value}</h3>;
}

export class Results extends React.Component {
    render() {
        return (
            <>
                <ScoreResult label="Score" value={this.props.result.score} />
                <ScoreResult label="Answers Correct" value={this.props.result.numberCorrect} />
                <ScoreResult label="Answers Incorrect" value={this.props.result.numberIncorrect} />
                <h3 style={{margin: "30px 0px 20px 0px"}}>Answer Response Times (ms)</h3>
                {
                    this.props.answers.length > 0 &&
                    <ResultsGraph answers={this.props.answers} />
                }
                {
                    this.props.answers.length === 0 &&
                    <p>No results to show</p>
                }
                <hr/>
                <Link to="/instructions"><button>Take Test Again</button></Link>
            </>
        );
    }
}