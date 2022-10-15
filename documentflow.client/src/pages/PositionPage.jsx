import PositionTable from '../components/position/PositionTable'
import EditingPanel from '../components/EditingPanel'
import React, {useEffect, useState} from "react";
import PositionForm from '../components/position/PositionForm';
import {getPositions, getPosition} from '../API/PositionService';
import MyModal from "../components/UI/modal/MyModal";
import PositionDetail from "../components/position/PositionDetail";

const PositionPage = () => {

    const [positions, setPositions] = useState([]);
    const [position, setDetails] = useState({
        name : "sad",
        description : "asd"
    });

    const [modalCreate, setModalCreate] = useState(false);
    const [modalDetail, setModalDetail] = useState(false);

    const showModalCreate = () =>
    {
        setModalCreate(true);
    }

    const showModalDetail = async (id) =>
    {
        const result = await getPosition(id);
        await setDetails(result.data);
        setModalDetail(true);
    }

    const createPosition = (newPosition) => {
        setPositions([...positions, {...newPosition}]);
        setModalCreate(false)
    }

    const getDetailPosition = () => {
        setModalCreate(false)
        setPositions({
            name : "",
            description : ""
        });
    }

    const removePosition = (position) => {
        setPositions(positions.filter(p => p.id !== position.id))
    }

    const fetchPositions = async () => {
        const response = await getPositions();
        setPositions(response.data);
    }

    useEffect(()=> {fetchPositions()},[])

    return (
        <div>
            <EditingPanel showModal={showModalCreate} name={"Список Должностей"}/>
            <MyModal visible={modalCreate} setVisible={setModalCreate}>
                <PositionForm create={createPosition}/>
            </MyModal>
            <PositionTable showModalDetail={showModalDetail} remove={removePosition} positions={positions}/>
            <MyModal visible={modalDetail} setVisible={setModalDetail}>
                <PositionDetail close={getDetailPosition} position={position}/>
            </MyModal>
        </div>
    );
};

export default PositionPage;
