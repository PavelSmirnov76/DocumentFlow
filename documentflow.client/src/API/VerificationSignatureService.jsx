import axios from "axios";
const url = 'http://smirnovp76.somee.com/api/VerificationSignature/';

export const postVerificationSignature = async (files) => {
    return await axios.post(url, files);
};