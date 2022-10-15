import React from 'react';
import InternalDocumentTableRow from "./InternalDocumentTableRow";

const InternalDocumentTable = (props) => {

    return (
        <div>
            <table className="table table-striped">
                <thead>
                <tr>
                    <th scope="col">Заголовок</th>
                    <th scope="col">Состояние</th>
                </tr>
                </thead>
                <tbody>
                {props.internalDocuments.map(internalDocument => <InternalDocumentTableRow remove={props.remove}  showModalDetail={props.showModalDetail} internalDocument={internalDocument} key = {internalDocument.id}/>)}
                </tbody>
            </table>
        </div>
    );
};

export default InternalDocumentTable;