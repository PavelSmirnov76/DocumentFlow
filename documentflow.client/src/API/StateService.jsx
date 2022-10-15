import axios from "axios";
const url = 'http://smirnovp76.somee.com/api/States/';

export const getStates = async () => {
    return await axios.get(url);
};