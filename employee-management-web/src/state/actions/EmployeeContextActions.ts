import IEmployeeCreateRequest from "../../models/employees/requests/IEmployeeCreateRequest";

export type EmployeeContextActions = 
| { type: 'ADD_EMPLOYEE', payload: IEmployeeCreateRequest };