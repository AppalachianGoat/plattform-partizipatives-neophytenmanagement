// This component serves as the page to display the available farmer help requests that fit the user's search criteria.
import React, { Component } from 'react';
import { FarmerHelpRequestsFilter } from './FarmerHelpRequestsFilter';

export class FarmerHelpRequests extends Component {
    constructor(props)  {
        super(props);
        this.state = { farmerHelpRequests: [], loading: true };
    }

    handleFilterChange = (event) => {
    }

    render() {
        return (
            <div>
                <h1>Farmer Help Requests</h1>
                <p>Here are the farmer help requests that fit your search criteria</p>
                <FarmerHelpRequestsFilter onFilterChange={this.handleFilterChange} />
                <ul>
                    {this.state.farmerHelpRequests.map(farmerHelpRequest =>
                        <li key={farmerHelpRequest.id}>{farmerHelpRequest.title}</li>
                    )}
                </ul>
            </div>
        );
    }
}