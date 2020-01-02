import React from "react";

export class Answer extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            numericInput: "",
            inputError: null
        };

        this.start = new Date();
        
        this.textInput = React.createRef();

        this.handleNumericInput = this.handleNumericInput.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
        this.calculateTimeSpan = this.calculateTimeSpan.bind(this);
        this.validateInput = this.validateInput.bind(this);
    }

    componentDidMount() {
        if (this.textInput.current != null) this.textInput.current.focus();
    }

    handleNumericInput(event) {
        this.setState({
            numericInput: event.target.value,
            inputError: null
        });
    }

    calculateTimeSpan() {
        return new Date() - this.start;
    }

    validateInput() {
        const value = this.state.numericInput;
        if (value.length === 0) {
            this.setState({
                inputError: "You must enter something"
            });
            return false;
        }

        try {
            parseInt(value);
        } catch (ex) {
            this.setState({
                inputError: "You must enter a number"
            });
            return false;
        }

        return true;
    }

    handleSubmit(ev) {
        ev.preventDefault();

        if (!this.validateInput()) return;
        const number = parseInt(this.state.numericInput);
        this.props.submitAnswer(number, this.calculateTimeSpan());
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit}>
                <h4>Answer:</h4>
                <input type="number" placeholder="Enter Number..." value={this.state.numericInput} onChange={this.handleNumericInput} ref={this.textInput} />
                <button type='submit'>Submit</button>
                {
                    this.state.inputError &&
                    <p style={{ color: "red" }}>{this.state.inputError}</p>
                }
            </ form>
        )
    }
}