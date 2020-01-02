import React from "react";
import { Link } from "react-router-dom";

export class Instructions extends React.Component {
    render() {
        return (
            <>
                <h4>Instructions</h4>
                <p>Instructions here...</p>
                <p>Instructions here...</p>
                <Link to="/test"><button type='submit'>Start Test</button></Link>
            </>
        );
    }
}