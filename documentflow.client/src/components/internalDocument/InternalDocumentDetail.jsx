import React from 'react';

const InternalDocumentDetail = (props) => {

    const downloadFile = async (e) => {
        if(props.internalDocument.file.path === '#')
            e.preventDefault();
    }
    const downloadSign = async (e) => {

        if(props.internalDocument.file.signPath === '#')
            e.preventDefault();
    }

    return (
        <ul className="list-group">
            <h5>Заголовок</h5>
            <li className="list-group-item">{props.internalDocument.header}</li>
            <h5>описание</h5>
            <li className="list-group-item">{props.internalDocument.description}</li>
            <h5>Автор</h5>
            <h6>Фио</h6>
            <li className="list-group-item">{props.internalDocument.author.person.fullName}</li>
            <h5>Состояние</h5>
            <li className="list-group-item">{props.internalDocument.state.name}</li>
            <h5>файл</h5>
            <a onClick={downloadFile} href={'https://localhost:44343/api' + props.internalDocument.file.filePath} className="list-group-item">{props.internalDocument.file.fileName}</a>
            <a onClick={downloadSign} href={'https://localhost:44343/api' + props.internalDocument.file.filePath + '_подпись.txt'} className="list-group-item">{props.internalDocument.file.signName}</a>
        </ul>
    )};

export default InternalDocumentDetail;