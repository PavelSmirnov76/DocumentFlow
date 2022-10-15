import React from 'react';
import MyButton from '../UI/button/MyButton'
import {deleteInternalDocument} from '../../API/InternalDocumentService'

const InternalDocumentItem = (props) => {

    const removePerson = async () => {
        await deleteInternalDocument(props.internalDocument.id);
        props.remove(props.internalDocument);
    }

    return (
        <tr>
            <td>{props.internalDocument.header}</td>
            <td>{props.internalDocument.state.name}</td>
            <td>
                <MyButton onClick ={removePerson}>Удалить</MyButton>
            </td>
        </tr>
    );
};

export default InternalDocumentItem;