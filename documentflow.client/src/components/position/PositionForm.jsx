import React, {useState} from 'react';
import MyButton from '../UI/button/MyButton'
import MyInput from '../UI/input/MyInput'
import {postPosition} from '../../API/PositionService'

const PositionForm = ({create}) => {

    const [position, setPosition] = useState({name : '', description : ''})

    const addNewPosition = async (e) => {
        e.preventDefault();

        const result = await postPosition(position)

        create(result.data);
        setPosition({name : '', description : ''});
    }

    return (
        <form>
            <MyInput value={position.name} onChange={e => setPosition({...position, name : e.target.value})} type="text" placeholder="Название должности"/>
            <MyInput value={position.description} onChange={e => setPosition({...position, description : e.target.value})} type="text" placeholder="Описание"/>
            <MyButton onClick={addNewPosition}>Добавить</MyButton>
        </form>
    );
};

export default PositionForm;