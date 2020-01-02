import React from "react";

export class Question extends React.Component {
    constructor(props) {
        super(props);

        this.startQuestionCountdown = this.startQuestionCountdown.bind(this);
    }

    componentDidMount() {
        this.startQuestionCountdown();
    }

    startQuestionCountdown() {
        setTimeout(() => {
            this.props.countdownOver();
        }, 3000);
    }

    render() {
        return (
            <>
                <p>Memorise</p>
                <h1>{this.props.number}</h1>
            </>
        );
    }
}