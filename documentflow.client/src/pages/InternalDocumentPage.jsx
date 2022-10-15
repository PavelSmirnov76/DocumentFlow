import EditingPanel from '../components/EditingPanel'
import React, {useEffect, useState} from "react";
import {getInternalDocuments, getInternalDocument} from '../API/InternalDocumentService';
import MyModal from "../components/UI/modal/MyModal";
import InternalDocumentTable from "../components/internalDocument/InternalDocumentTable";
import InternalDocumentForm from "../components/internalDocument/InternalDocumentForm";
import InternalDocumentDetail from "../components/internalDocument/InternalDocumentDetail";

const InternalDocumentPage = () => {

    const [internalDocuments, setInternalDocuments] = useState([]);
    const defDoc = {
        id: 0,
        header: '',
        description: '',
        authorId: 0,
        author: {
            id: 0,
            personId: 0,
            person: {
                id: 0,
                fullName: '',
                sex: '',
                dateBirth: '',
                phoneNumber: ''
            },
            positionId: 0,
            position: {
                id: 0,
                name: '',
                description: ''
            },
            isSignatory: false,
            isСoordinating: false,
            isAddressee: false
        },
        stateId: 0,
        state: {
            id: 0,
            name: ''
        },
        created: null,
        fileId: 0,
        file: {
            id: 0,
            fileName: '',
            filePath: '',
            signName: '',
            signPath: ''
        }
    };
    const [internalDocument, setInternalDocument] = useState(defDoc);

    const [modalCreate, setModalCreate] = useState(false);
    const [modalDetail, setModalDetail] = useState(false);

    const showModalCreate = () =>
    {
        setModalCreate(true);
    }

    const showModalDetail = async (id) =>
    {

        const result = await getInternalDocument(id);

        if(result.data.file == null)
        {
            result.data.file = { fileName : "Файл не найден", path : "#"}
        }
        if(result.data.file.signPath == null)
        {
            result.data.file.signName = 'Подпись не найдена'
            result.data.file.signPath = "#";
        }

        await setInternalDocument({...result.data});

        await setModalDetail(true);
    }

    const createInternalDocument = (newInternalDocument) => {
        setInternalDocuments([...internalDocuments, {...newInternalDocument}]);
        setModalCreate(false)
    }

    const removeInternalDocument = (internalDocument) => {
        setInternalDocuments(internalDocuments.filter(e => e.id !== internalDocument.id))
    }

    const fetchInternalDocument = async () => {
        const response = await getInternalDocuments();
        setInternalDocuments(response.data);
    }

    useEffect(()=> {fetchInternalDocument()},[])

    return (
        <div>
            <EditingPanel showModal={showModalCreate} name={"Список внутренних документов"}/>
            <MyModal visible={modalCreate} setVisible={setModalCreate}>
                <InternalDocumentForm create={createInternalDocument}/>
            </MyModal>
            <InternalDocumentTable remove={removeInternalDocument} showModalDetail={showModalDetail} internalDocuments={internalDocuments}/>
            <MyModal visible={modalDetail} setVisible={setModalDetail}>
                <InternalDocumentDetail internalDocument={internalDocument}/>
            </MyModal>
        </div>
    );
};

export default InternalDocumentPage;
