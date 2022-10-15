import React, {useState} from 'react';
import MyButton from '../UI/button/MyButton'
import MyInput from '../UI/input/MyInput'
import {postPerson} from '../../API/PersonService'
import PhoneInput from 'react-phone-input-2'

const PersonForm = ({create}) => {

    const defState = {fullName : '', sex : '', dateBirth : '', phoneNumber : ''};
    const [person, setPerson] = useState(defState);
    const [value, setValue] = useState("Мужчина");

    const addNewPerson = async (e) => {
        e.preventDefault();

        const result = await postPerson(person);

        create(result.data);
        setPerson(defState);
    }
    function changeValue(e) {
        setValue(e.target.value);
        setPerson({...person, sex : e.target.value})

    }

    return (
        <form>
            <MyInput value={person.fullName} onChange={e => setPerson({...person, fullName : e.target.value})}
                     type="text" placeholder="ФИО"/>
            <div className="radio">
                <label>
                    <input type="radio" name="radio" value="Мужчина"
                           checked={value === 'Мужчина' ? true : false}
                           onChange={e => changeValue(e)} />
                        Мужчина
                    </label>
                <label>
                    <input type="radio" name="radio" value="Женщина"
                           checked={value === 'Женщина' ? true : false}
                           onChange={e => changeValue(e)} />
                    Женщина
                </label>
            </div>
            <MyInput value={person.dateBirth} onChange={e => setPerson({...person, dateBirth : e.target.value})}
                     type="date"  placeholder="Дата Рождения"/>
            <PhoneInput value={person.phoneNumber} onChange={e => setPerson({...person, phoneNumber : e})}
                     country={'ru'} specialLabel=""/>
            <MyButton onClick={addNewPerson}>Добавить</MyButton>
        </form>
    );
};

export default PersonForm;