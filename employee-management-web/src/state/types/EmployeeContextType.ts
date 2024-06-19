import IEmployeeCreateRequest from "../../models/employees/requests/IEmployeeCreateRequest";
import EmployeeResponse from "../../models/employees/responses/EmployeeResponse"

export type EmployeeContextType = {
    employees: EmployeeResponse[] | undefined;
    saveEmployee: (request: IEmployeeCreateRequest) => void;
}