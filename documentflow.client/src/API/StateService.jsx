import axios from "axios";
const url = 'https://localhost:44343/api/States/';

export const getStates = async () => {
    return await axios.get(url);
};