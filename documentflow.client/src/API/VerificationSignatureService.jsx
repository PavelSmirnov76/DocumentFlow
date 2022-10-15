import axios from "axios";
const url = 'https://localhost:44343/api/VerificationSignature/';

export const postVerificationSignature = async (files) => {
    return await axios.post(url, files);
};