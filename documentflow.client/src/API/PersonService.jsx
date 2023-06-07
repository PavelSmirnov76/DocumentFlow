import axios from "axios";
const url = 'https://smirnovp76.somee.com/api/Persons/';

export const getPersons = async () => {
    return await axios.get(url);
};

export const postPerson = async (person) => {
    return await axios.post(url, person);
};

export const deletePerson = async (id) => {
    return await axios.delete(url + id)
}