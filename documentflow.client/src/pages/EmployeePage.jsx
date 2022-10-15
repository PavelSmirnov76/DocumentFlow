import EditingPanel from '../components/EditingPanel'
import React, {useEffect, useState} from "react";
import {getEmployees} from '../API/EmployeeService';
import MyModal from "../components/UI/modal/MyModal";
import EmployeeTable from "../components/employee/EmployeeTable";
import EmployeeForm from "../components/employee/EmployeeForm";

const EmployeePage = () => {

    const [employees, setEmployees] = useState([]);
    const [modal, setModal] = useState(false);

    const showModal = () =>
    {
        setModal(true);
    }

    const createEmployee = (newEmployee) => {
        setEmployees([...employees, {...newEmployee}]);
        setModal(false)
    }

    const removeEmployee = (employee) => {
        setEmployees(employees.filter(e => e.id !== employee.id))
    }

    const fetchEmployees = async () => {
        const response = await getEmployees();
        setEmployees(response.data);
    }

    useEffect(()=> {fetchEmployees()},[])

    return (
        <div>
            <EditingPanel showModal={showModal} name={"Список работников"}/>
            <MyModal visible={modal} setVisible={setModal}>
                <EmployeeForm create={createEmployee}/>
            </MyModal>
            <EmployeeTable remove={removeEmployee} employees={employees}/>
        </div>
    );
};

export default EmployeePage;
