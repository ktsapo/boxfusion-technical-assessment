import { client } from "../config/api";
import IEmployeeCreateRequest from "../models/employees/requests/IEmployeeCreateRequest";
import EmployeeResponse from "../models/employees/responses/EmployeeResponse";
import { EMPLOYEE_GET_URL } from "../utils/constants";


const CreateEmployee = (request: IEmployeeCreateRequest): void => {
   
}

const GetEmployees = async (): Promise<EmployeeResponse[]> => {
    const { data } = await client.get<EmployeeResponse[]>(EMPLOYEE_GET_URL);
    return data;
}

export {
    CreateEmployee,
    GetEmployees
};