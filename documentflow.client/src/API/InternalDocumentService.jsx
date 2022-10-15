import axios from "axios";
const url = 'http://smirnovp76.somee.com/api/yaInternalDocuments/';

export const getInternalDocuments = async () => {
    return await axios.get(url);
};
export const getInternalDocument = async (id) => {
    return await axios.get(url + id);
};

export const postInternalDocument = async (internalDocument) => {
    return await axios.post(url, internalDocument);
};

export const deleteInternalDocument = async (id) => {
    return await axios.delete(url + id)
}