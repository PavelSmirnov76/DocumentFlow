import axios from "axios";
const url = 'https://localhost:44343/api/Employees/';

export const getEmployees = async () => {
    return await axios.get(url);
};

export const postEmployee = async (employee) => {
    return await axios.post(url, employee);
};

export const deleteEmployee = async (id) => {
    return await axios.delete(url + id)
}