import React, { FC, useState, useEffect } from 'react';
import { FarmerHelpRequestsFilter } from './FarmerHelpRequestsFilter';
import { FarmerHelpRequestsTable } from './FarmerHelpRequestsTable';
import { FarmerHelpRequest, FarmerHelpRequestsClient, FilterFarmerHelpRequestDto } from '../api/FarmerHelpServiceClients.js';

export const FarmerHelpRequests: FC = () => {

    const [farmerHelpFilter, setFilter] = useState<FilterFarmerHelpRequestDto>(new FilterFarmerHelpRequestDto({
        location: '',
        distanceFromLocation: 10,
        startDate: new Date(),
        endDate: undefined,
        workVolume: 1,
        numberOfHelpers: 1
    }));

    const [farmerHelpRequests, setFarmerHelpRequests] = useState<FarmerHelpRequest[]>([]);
    
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