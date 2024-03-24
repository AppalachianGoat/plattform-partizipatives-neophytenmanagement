// This component serves as the page to display the available farmer help requests that fit the user's search criteria.
import React, { Component } from 'react';
import { FarmerHelpRequestsFilter } from './FarmerHelpRequestsFilter';
import { FarmerHelpRequestsTable } from './FarmerHelpRequestsTable';

export class FarmerHelpRequests extends Component {
    constructor(props)  {
        super(props);
        this.state = { farmerHelpRequests: [
             {
                "id": 4,
                "ownerUser": null,
                "startDate": "2024-03-23T00:12:45.105Z",
                "endDate": "2024-03-24T00:12:45.105Z",
                "location": {
                "id": 3,
                "locationString": "1006",
                "latitude": 46.51,
                "longitude": 6.63
                },
                "workVolume": 0,
                "numberOfHelpers": 0,
                "invasiveSpeciesTypes": null
            },
            {
                "id": 5,
                "ownerUser": null,
                "startDate": "2024-03-23T00:12:45.105Z",
                "endDate": "2024-03-30T00:12:45.105Z",
                "location": {
                "id": 4,
                "locationString": "1700",
                "latitude": 46.68,
                "longitude": 7.08
                },
                "workVolume": 3,
                "numberOfHelpers": 3,
                "invasiveSpeciesTypes": null
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