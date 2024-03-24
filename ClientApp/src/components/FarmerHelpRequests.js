// This component serves as the page to display the available farmer help requests that fit the user's search criteria.
import React, { Component } from 'react';
import { FarmerHelpRequestsFilter } from './FarmerHelpRequestsFilter';
import { FarmerHelpRequestsTable } from './FarmerHelpRequestsTable';

export class FarmerHelpRequests extends Component {
    constructor(props)  {
        super(props);
        this.state = { farmerHelpRequests: [
            {
                
            }
        ], loading: true };
    }

    handleFilterChange = (event) => {
    }

    render() {
        return (
            <div>
                <h1>Jetzt Zäme sammle</h1>
                <p>Als Verein, Institution, etc. könnt ihr eure HIlfe anbieten oder in bestehenden Sammelaufrufen die passende Aktion auswählen</p>
                <FarmerHelpRequestsFilter onFilterChange={this.handleFilterChange} />
                <FarmerHelpRequestsTable farmerHelpRequests={this.state.farmerHelpRequests} />  
            </div>
        );
    }
}