import axios from "axios";
const url = 'http://smirnovp76.somee.com/api/Files/';

export const postFile = async (file) => {
    const config = { headers: { 'Content-Type': 'multipart/form-data' } };

    return await axios.post(url, file, config);
};

export const getFile = async (filePath) => {
    return await axios.get(url + filePath);
};
