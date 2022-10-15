import React from 'react';
import MyButton from '../UI/button/MyButton'
import {deleteEmployee} from '../../API/EmployeeService'

const EmployeeTableRow = (props) => {

    const removeEmployee = async () => {
        await deleteEmployee(props.employee.id);
        props.remove(props.employee);
    }

    return (
        <tr>
            <td>{props.employee.person.fullName}</td>
            <td>{props.employee.position.name}</td>
            <td>
                <MyButton onClick ={removeEmployee}>Удалить</MyButton>
            </td>
        </tr>
    );
};

export default EmployeeTableRow;