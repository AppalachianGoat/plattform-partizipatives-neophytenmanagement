import React, { useState, useEffect } from 'react';
import { FarmerHelpRequestsFilter } from './FarmerHelpRequestsFilter';
import { FarmerHelpRequestsTable } from './FarmerHelpRequestsTable';
import { FarmerHelpRequestsClient } from '../api/FarmerHelpServiceClients.js';

export const FarmerHelpRequests = () => {

    const [farmerHelpFilter, setFilter] = useState({
        PLZ: '',
        Umkreis: 10,
        Anfangsdatum: Date.now(),
        Enddatum: '',
        Einsatzdauer: 1,
        AnzPersonen: 1
    });

    const [farmerHelpRequests, setFarmerHelpRequests] = useState([
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
    ]);
    
    useEffect(() => {
        async function getNewTableData() {
            const currentTable = await FarmerHelpRequestsClient.getFarmerHelpRequests(farmerHelpFilter);
            setFarmerHelpRequests(currentTable);
        }
        getNewTableData()
    }, [farmerHelpFilter])

    return (
        <div>
            <h1>Jetzt Zäme sammle</h1>
            <p>Als Verein, Institution, etc. könnt ihr eure HIlfe anbieten oder in bestehenden Sammelaufrufen die passende Aktion auswählen</p>
            <FarmerHelpRequestsFilter filter={farmerHelpFilter} onFilterChange={setFilter} />
            <FarmerHelpRequestsTable farmerHelpRequests={farmerHelpRequests} />  
        </div>
    );
}

export default FarmerHelpRequests;