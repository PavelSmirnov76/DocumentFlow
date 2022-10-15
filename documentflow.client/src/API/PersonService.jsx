import axios from "axios";
const url = 'https://localhost:44343/api/Persons/';

export const getPersons = async () => {
    return await axios.get(url);
};

export const postPerson = async (person) => {
    return await axios.post(url, person);
};

export const deletePerson = async (id) => {
    return await axios.delete(url + id)
}