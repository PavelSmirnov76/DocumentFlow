import React from 'react';
import MyButton from '../UI/button/MyButton'
import {deleteEmployee} from '../../API/EmployeeService'

const EmployeeTableRow = (props) => {

    const removeEmployee = async () => {
        await deleteEmployee(props.employee.id);
        props.remove(props.employee);
    }

    const ConvertBool = (e) =>
    {
        if(e)
            return 'да';
        else
            return 'нет';
    }

    return (
        <tr>
            <td>{props.employee.person.fullName}</td>
            <td>{props.employee.position.name}</td>
            <td>{ConvertBool(props.employee.isSignatory)}</td>
            <td>{ConvertBool(props.employee.isСoordinating)}</td>
            <td>{ConvertBool(props.employee.isAddressee)}</td>
            <td>
                <MyButton onClick ={removeEmployee}>Удалить</MyButton>
            </td>
        </tr>
    );
};

export default EmployeeTableRow;