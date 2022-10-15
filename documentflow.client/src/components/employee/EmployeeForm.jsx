import React, {useState} from 'react';
import MyButton from '../UI/button/MyButton'
import MyInput from '../UI/input/MyInput'
import {postEmployee} from '../../API/EmployeeService'
import Dropdown from 'react-bootstrap/Dropdown';
import {getPersons} from "../../API/PersonService";
import {getPositions} from "../../API/PositionService";

const EmployeeForm = ({create}) => {

    const defState = {
        personId : 0,
        positionId: 0,
        isSignatory: false,
        isСoordinating: false,
        isAddressee: false
    };

    const [employee, setEmployee] = useState(defState);

    const addNewEmployee = async (e) => {
        e.preventDefault();

        const result = await postEmployee(employee);

        create(result.data);
        setEmployee(defState);
    }

    const [persons, setPersons] = useState([]);
    const [positions, setPositions] = useState([]);

    const [nameDropDownPerson, setNameDropDownPerson] = useState("Личность");

    const fetchPersons = async () => {
        const response = await getPersons();
        setPersons(response.data);
    }

    const changeNameDropDownPerson = (e) => {
        setNameDropDownPerson(e.target.text);
        setEmployee({...employee, personId : e.target.text.split(' ')[0]});

    }

    const [nameDropDownPosition, setNameDropDownnPosition] = useState("Должность");

    const fetchPositions = async () => {
        const response = await getPositions();
        setPositions(response.data);
    }

    const changeNameDropDownPosition = (e) => {
        setNameDropDownnPosition(e.target.text);
        setEmployee({...employee, positionId : e.target.text.split(' ')[0]});


    }


    return (
        <form>
            <Dropdown onClick={fetchPersons}>
                <Dropdown.Toggle variant="success" id="dropdown-basic">
                    {nameDropDownPerson}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    {persons.map(p => <Dropdown.Item onClick={changeNameDropDownPerson} key = {p.id}>{p.id + ' ' + p.fullName+' '+p.sex + ' ' + p.dateBirth}</Dropdown.Item>)}
                </Dropdown.Menu>
            </Dropdown>
            <Dropdown onClick={fetchPositions}>
                <Dropdown.Toggle variant="success" id="dropdown-basic">
                    {nameDropDownPosition}
                </Dropdown.Toggle>
                <Dropdown.Menu>
                    {positions.map(p => <Dropdown.Item onClick={changeNameDropDownPosition} key = {p.id}>{p.id + ' ' + p.name}</Dropdown.Item>)}
                </Dropdown.Menu>
            </Dropdown>
            <MyInput value={employee.isSignatory} onChange={e => setEmployee({...employee, isSignatory : e.target.value})} type="text" placeholder="Подписант"/>
            <MyInput value={employee.isСoordinating} onChange={e => setEmployee({...employee, isСoordinating : e.target.value})} type="text" placeholder="Согласующий"/>
            <MyInput value={employee.isAddressee} onChange={e => setEmployee({...employee, isAddressee : e.target.value})} type="text" placeholder="Адресат"/>
            <MyButton onClick={addNewEmployee}>Добавить</MyButton>
        </form>
    );
};

export default EmployeeForm;