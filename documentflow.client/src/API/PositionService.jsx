import axios from "axios";
const url = 'http://smirnovp76.somee.com/api/Positions/';

export const getPositions = async () => {
    return await axios.get(url);
};

export const getPosition = async (id) => {
    return await axios.get(url + id);
};

export const postPosition = async (position) => {
    return await axios.post(url, position);
};

export const deletePosition = async (id) => {
    return await axios.delete(url + id)
}