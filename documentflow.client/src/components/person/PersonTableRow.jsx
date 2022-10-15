import React from 'react';
import MyButton from '../UI/button/MyButton'
import {deletePerson} from '../../API/PersonService'

const PersonTableRow = (props) => {

    const removePerson = async () => {
        await deletePerson(props.person.id);
        props.remove(props.person);
    }

    return (
        <tr>
            <td>{props.person.fullName}</td>
            <td>{props.person.sex}</td>
            <td>{props.person.dateBirth}</td>
            <td>{props.person.phoneNumber}</td>
            <td>
                <MyButton onClick ={removePerson}>Удалить</MyButton>
            </td>
        </tr>
    );
};

export default PersonTableRow;