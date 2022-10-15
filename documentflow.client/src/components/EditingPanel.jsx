import React from 'react';

const EditingPanel = (props) => {

    const showModal = () =>{
        props.showModal();
    }

    return (
        <div className="btn-toolbar justify-content-between" role="toolbar" aria-label="Toolbar with button groups">
            <div className="btn-group" role="group" aria-label="First group">
                <button  onClick={showModal} type="button" className="btn btn-secondary">Добавить</button>
            </div>
            <div className="input-group">
                <div className="input-group-prepend">
                    <label className="input-group-text" id="btnGroupAddon2">{props.name}</label>
                </div>
            </div>
        </div>
    );
};

export default EditingPanel;