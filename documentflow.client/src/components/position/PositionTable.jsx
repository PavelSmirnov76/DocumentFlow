import React from 'react';
import PositionTeableRow from './PositionTeableRow'

const PositionTable = (props) => {

    return (
        <div>
            <table className="table table-striped">
                <thead>
                <tr>
                    <th scope="col">Название</th>
                    <th scope="col">Описание</th>
                    <th scope="col"></th>
                </tr>
                </thead>
                <tbody>
                {props.positions.map(position => <PositionTeableRow showModalDetail={props.showModalDetail} remove={props.remove} position={position} key = {position.id}/>)}
                </tbody>
            </table>
        </div>
    );
};

export default PositionTable;