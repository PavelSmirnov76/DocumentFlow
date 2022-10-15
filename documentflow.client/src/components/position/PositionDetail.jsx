import React from 'react';

const PositionDetail = (props) => {

    return (
            <ul className="list-group">
                <h5>название</h5>
                <li className="list-group-item">{props.position.name}</li>
                <h5>описание</h5>
                <li className="list-group-item">{props.position.description}</li>
            </ul>
    )};

export default PositionDetail;