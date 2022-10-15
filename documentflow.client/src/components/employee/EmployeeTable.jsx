import React from 'react';
import EmployeeTableRow from "./EmployeeTableRow";

const EmployeeTable = (props) => {

    return (
        <div>
            <table className="table table-striped">
                <thead>
                <tr>
                    <th scope="col">ФИО</th>
                    <th scope="col">Должность</th>
                </tr>
                </thead>
                <tbody>
                {props.employees.map(employee => <EmployeeTableRow remove={props.remove} employee={employee} key = {employee.id}/>)}
                </tbody>
            </table>
        </div>
    );
};

export default EmployeeTable;