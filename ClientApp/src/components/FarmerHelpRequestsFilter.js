import React from "react";
import "./FarmerHelpRequestsFilter.css"

export const FarmerHelpRequestsFilter = ({filter, onFilterChange}) => {
    const handleChange = (event) => {
        onFilterChange({
            ...filter,
            [event.target.name]: event.target.value
        });
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