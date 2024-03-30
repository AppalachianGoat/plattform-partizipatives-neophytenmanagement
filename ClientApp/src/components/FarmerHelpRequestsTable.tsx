import React, { FC, useMemo } from "react";
import { useTable } from "react-table";
import './FarmerHelpRequestsTable.css';
import '../styles/buttons.css';
import { FarmerHelpRequest } from "../api/FarmerHelpServiceClients";


interface FarmerHelpRequestProps {
    farmerHelpRequests: FarmerHelpRequest[];
}

export const FarmerHelpRequestsTable: FC<FarmerHelpRequestProps> = ({farmerHelpRequests}) => {
    const columns = useMemo(
        () => [
            {
                Header: 'PLZ',
                accessor: 'location.locationString',
            },
            {
                Header: 'Anfangsdatum',
                accessor: 'startDate',
            },
            {
                Header: 'Enddatum',
                accessor: 'endDate',
            },
            {
                Header: "Einsatzdauer",
                accessor: 'workVolume',
            },
            {
                Header: 'Anz. Personen',
                accessor: 'numberOfHelpers',
            },
            {
                Header: 'Register',
                accessor: 'register',
                Cell: () => (
                    <button className="neophyten-button" onClick={() => { /* handle register event here */ }}>
                        Register
                    </button>
                ),
            }
        ],
        []
    )

    const tableInstance = useTable({ columns, data: farmerHelpRequests })

    return (
        <div>
            <table className="farmer-help-request-table" {...tableInstance.getTableProps()}>
                <thead>
                {
                    tableInstance.headerGroups.map(headerGroup => (
                        <tr {...headerGroup.getHeaderGroupProps()}>
                            {
                                headerGroup.headers.map(column => (
                                    <th {...column.getHeaderProps()}>{column.render('Header')}</th>
                                ))
                            }
                        </tr>
                    ))
                }
                </thead >
                <tbody {...tableInstance.getTableBodyProps()}>
                {
                    tableInstance.rows.map(row => {
                        tableInstance.prepareRow(row)
                        return (
                            <tr {...row.getRowProps()}>
                                {
                                    row.cells.map(cell => {
                                        return (
                                            <td {...cell.getCellProps()}>{cell.render('Cell')}</td>
                                        )
                                    })
                                }
                            </tr>
                        )
                    })
                }
                </tbody>
            </table>
        </div>
    );
}