import React, {useState} from 'react';
import MyButton from '../UI/button/MyButton'
import MyInput from '../UI/input/MyInput'
import {postInternalDocument} from '../../API/InternalDocumentService'
import Dropdown from 'react-bootstrap/Dropdown';
import {getEmployees} from "../../API/EmployeeService";
import {getStates} from "../../API/StateService";
import {postFile} from "../../API/FileService";

const InternalDocumentForm = ({create}) => {

    const defState = {
        header : "",
        description : "",
        authorId : 0,
        stateId : 0
    };

    const [file, setFile] = useState();
    const [cert, setCert] = useState();

    const uploadFile = (event) => {
        event.preventDefault();
        if (event.target.files[0]) {
            setFile(event.target.files[0]);
        }
    };

    const uploadCert = (event) => {
        event.preventDefault();
        if (event.target.files[0]) {
            setCert(event.target.files[0]);
        }
    };

    const [internalDocument, setInternalDocument] = useState(defState);

    const addNewInternalDocument = async (e) => {
        e.preventDefault();

        if(file != null) {
            const formData = new FormData();
            formData.append('file', file);
            formData.append('cert', cert);

            const result = await postFile(formData);

            internalDocument.fileId = result.data;
        }
        const result = await postInternalDocument(internalDocument);

        create(result.data);
        setInternalDocument(defState);
    }

    const [authors, setAuthors] = useState([]);
    const [states, setStates] = useState([]);

    const [nameDropDownAuthor, setNameDropDownAuthor] = useState("Автор");

    const fetchAuthors = async () => {
        const response = await getEmployees();
        setAuthors(response.data);
    }

    const changeNameDropDownAuthors = (e) => {
        setNameDropDownAuthor(e.target.text);
        setInternalDocument({...internalDocument, authorId : e.target.text.split(' ')[0]});

    }

    const [nameDropDownState, setNameDropDownState] = useState("Состояние");

    const fetchStates = async () => {
        const response = await getStates();
        setStates(response.data);
    }

    const changeNameDropDownState = (e) => {
        setNameDropDownState(e.target.text);
        setInternalDocument({...internalDocument, stateId : e.target.text.split(' ')[0]});
    }

    const [x, setX] = useState(false);

    const soldCheckbox = ({ target: { checked } }) => {
        console.log(x, checked);
        setX(checked);
    };

    return (
        <form>
            <MyInput value={internalDocument.header} onChange={e => setInternalDocument({...internalDocument, header : e.target.value})} type="text" placeholder="Заголовок"/>
            <MyInput value={internalDocument.description} onChange={e => setInternalDocument({...internalDocument, description : e.target.value})} type="text" placeholder="Описание"/>

            <Dropdown onClick={fetchAuthors}>
                <Dropdown.Toggle variant="success" id="dropdown-basic">
                    {nameDropDownAuthor}
                </Dropdown.Toggle>

                <Dropdown.Menu>
                    {authors.map(a => <Dropdown.Item onClick={changeNameDropDownAuthors} key = {a.id}>{a.id + ' ' + a.person.fullName}</Dropdown.Item>)}
                </Dropdown.Menu>
            </Dropdown>
            <Dropdown onClick={fetchStates}>
                <Dropdown.Toggle variant="success" id="dropdown-basic">
                    {nameDropDownState}
                </Dropdown.Toggle>
                <Dropdown.Menu>
                    {states.map(p => <Dropdown.Item onClick={changeNameDropDownState} key = {p.id}>{p.id + ' ' + p.name}</Dropdown.Item>)}
                </Dropdown.Menu>
            </Dropdown>

            <h5>Файл</h5>
            <MyInput onChange={uploadFile} type="file" placeholder="Описание"/>
            <h5>Сертификат для подписания файла</h5>
            <MyInput type="checkbox" checked={x} onChange={soldCheckbox}/>

            <MyInput onChange={uploadCert} type="file" placeholder="Описание" disabled={!x}/>


            <MyButton onClick={addNewInternalDocument}>Добавить</MyButton>
        </form>
    );
};

export default InternalDocumentForm;