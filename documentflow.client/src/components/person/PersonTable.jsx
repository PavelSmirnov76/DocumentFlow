import React from 'react';
import PersonTableRow from './PersonTableRow'

const PersonTable = (props) => {

    return (
        <div>
            <table className="table table-striped">
                <thead>
                <tr>
                    <th scope="col">ФИО</th>
                    <th scope="col">Пол</th>
                    <th scope="col">Дата Рождения</th>
                    <th scope="col">Номер телефона</th>
                    <th scope="col"></th>
                </tr>
                </thead>
                <tbody>
                {props.persons.map(person => <PersonTableRow remove={props.remove} person={person} key = {person.id}/>)}
                </tbody>
            </table>
        </div>
    );
};

export default PersonTable;