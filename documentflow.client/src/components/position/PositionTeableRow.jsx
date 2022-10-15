import React from 'react';
import MyButton from '../UI/button/MyButton'
import {deletePosition} from '../../API/PositionService'

const PositionTeableRow = (props) => {

    const removePosition = async () => {
        await deletePosition(props.position.id);
        props.remove(props.position);
    }

    const getDetail = () => {
        props.showModalDetail(props.position.id);
    }

    return (
        <tr>
            <td>{props.position.name}</td>
            <td>{props.position.description}</td>
            <td>
                <MyButton onClick ={getDetail}  >Подробнее</MyButton>
            </td>
            <td>
                <MyButton onClick ={removePosition}  >Удалить</MyButton>
            </td>

        </tr>
    );
};

export default PositionTeableRow;