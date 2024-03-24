import React, { useMemo } from "react";
import { useTable } from "react-table";

export const FarmerHelpRequestsTable = ({farmerHelpRequests}) => {
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
            }
        ],
        []
    )

    const tableInstance = useTable({ columns, data: farmerHelpRequests })

    return (
        <div>
            <table {...tableInstance.getTableProps()}>
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