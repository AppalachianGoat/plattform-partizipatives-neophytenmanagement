import React, {FC} from "react";

import "./FarmerHelpRequestsFilter.css"
import { FilterFarmerHelpRequestDto } from "../api/FarmerHelpServiceClients";

interface FarmerHelpRequestsFilterProps {
    filter: FilterFarmerHelpRequestDto,
    onFilterChange: (filter: FilterFarmerHelpRequestDto) => void    
}

export const FarmerHelpRequestsFilter: FC<FarmerHelpRequestsFilterProps> = ({filter, onFilterChange}) => {
    const handleChange = (event) => {
        onFilterChange(new FilterFarmerHelpRequestDto({
            ...filter,
            [event.target.name]: event.target.value
        }));
    }

    const handleSubmit = (event) => {
        event.preventDefault();
        onFilterChange(filter);
    }

    return (
        <div id="farmer-help-request-filter">
            <form onSubmit={handleSubmit}>
                <div id="filter-inputs">
                    <ul>
                        <li>
                            <input type="text" name="PLZ" placeholder="PLZ" onChange={handleChange} />
                        </li>
                        <li>
                            <input type="number" name="Umkreis" placeholder="Umkreis" onChange={handleChange} />
                        </li>
                        <li>
                            <input type="date" name="Anfangsdatum" placeholder="Anfangsdatum" onChange={handleChange} />
                        </li>
                        <li>
                            <input type="date" name="Enddatum" placeholder="Enddatum" onChange={handleChange} />
                        </li>
                        <li>
                            <input type="number" name="Einsatzdauer" placeholder="Einsatzdauer" onChange={handleChange} step="0.5" />
                        </li>     
                        <li>
                            <input type="number" name="AnzPersonen" placeholder="Anz. Personen" onChange={handleChange} />
                        </li>
                    </ul>
                </div>
                <button type="submit" className="neophyten-button" id="filter-button">Filter</button>
            </form>
        </div>
    );
}

export default FarmerHelpRequestsFilter;