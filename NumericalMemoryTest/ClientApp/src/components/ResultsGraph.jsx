import React from "react";
import { Chart } from "react-charts";

function ResultsGraph(props) {
    function resolveDataPoint(index, submissionTime) {
        return [index + 1, submissionTime]
    }

    function resolveSeries() {
        return {
            type: "line"
        };
    }

    function resolveData() {
        return [
            {
                label: "Submission Time (ms)",
                data: props.answers.map((answer, index) => resolveDataPoint(index, answer.timeTakenMs))
            }
        ];
    }

    function resolveAxes() {
        return [
            { title: "Answer", primary: true, position: 'bottom', type: "ordinal" },
            { title: "Response Time (ms)", type: 'linear', position: 'left' }
        ];
    }

    return (
        <div style={{
            width: "400px",
            height: "250px"
        }}>
            <Chart
                series={resolveSeries()}
                data={resolveData()}
                axes={resolveAxes()}
            />
        </div>
    );
}

export default ResultsGraph;