import PersonTable from '../components/person/PersonTable'
import EditingPanel from '../components/EditingPanel'
import React, {useEffect, useState} from "react";
import PersonForm from '../components/person/PersonForm';
import {getPersons} from '../API/PersonService';
import MyModal from "../components/UI/modal/MyModal";

const PersonPage = () => {

    const [person, setPerson] = useState([]);
    const [modal, setModal] = useState(false);

    const showModal = () =>
    {
        setModal(true);
    }

    const createPerson = (newPerson) => {
        setPerson([...person, {...newPerson}]);
        setModal(false)
    }

    const removePerson = (position) => {
        setPerson(person.filter(p => p.id !== position.id))
    }

    const fetchPersons = async () => {
        const response = await getPersons();
        setPerson(response.data);
    }

    useEffect(()=> {fetchPersons()},[])

    return (
        <div>
            <EditingPanel showModal={showModal} name={"Список Личностей"}/>
            <MyModal visible={modal} setVisible={setModal}>
                <PersonForm create={createPerson}/>
            </MyModal>
            <PersonTable remove={removePerson} persons={person}/>
        </div>
    );
};

export default PersonPage;