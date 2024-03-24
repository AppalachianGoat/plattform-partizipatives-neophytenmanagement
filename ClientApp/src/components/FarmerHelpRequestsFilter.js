import React, { Component } from "react";
import "./FarmerHelpRequestsFilter.css"
export class FarmerHelpRequestsFilter extends Component {
    constructor(props) {
        super(props);
        this.state = {
            farmerHelpRequestsFilter: {
                PLZ: '',
                Umkreis: 10,
                Anfangsdatum: Date.now(),
                Enddatum: '',
                Einsatzdauer: 1,
                AnzPersonen: 1
            }
        };
    }

    handleChange = (event) => {
        this.setState({
            farmerHelpRequestsFilter: {
                ...this.state.farmerHelpRequestsFilter,
                [event.target.name]: event.target.value
            }
        });
    }

    handleSubmit = (event) => {
        event.preventDefault();
        this.props.onFilterChange(this.state.farmerHelpRequestsFilter);
    }

    render() {
        return (
            <div id="farmer-help-request-filter">
                <form onSubmit={this.handleSubmit}>
                    <div id="filter-inputs">
                        <ul>
                            <li>
                                <input type="text" name="PLZ" placeholder="PLZ" onChange={this.handleChange} />
                            </li>
                            <li>
                                <input type="number" name="Umkreis" placeholder="Umkreis" onChange={this.handleChange} />
                            </li>
                            <li>
                                <input type="date" name="Anfangsdatum" placeholder="Anfangsdatum" onChange={this.handleChange} />
                            </li>
                            <li>
                                <input type="date" name="Enddatum" placeholder="Enddatum" onChange={this.handleChange} />
                            </li>
                            <li>
                                <input type="number" name="Einsatzdauer" placeholder="Einsatzdauer" onChange={this.handleChange} step="0.5" />
                            </li>     
                            <li>
                                <input type="number" name="AnzPersonen" placeholder="Anz. Personen" onChange={this.handleChange} />
                            </li>
                        </ul>
                    </div>
                    <button type="submit" class="neophyten-button" id="filter-button">Filter</button>
                </form>
            </div>
        );
    }
}