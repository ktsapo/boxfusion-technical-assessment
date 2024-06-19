import React, { useContext } from 'react';
import { EmployeeContext } from '../context/EmployeeContext';
import EmployeeResponse from '../../models/employees/responses/EmployeeResponse';
import IEmployeeCreateRequest from '../../models/employees/requests/IEmployeeCreateRequest';

export const EmployeeContextProvider: React.FC<{ children: React.ReactNode; }> = ({ children }) => {
    const [employees, setEmployees] = React.useState<EmployeeResponse[]>();

    const saveEmployee = (request: IEmployeeCreateRequest): void => {
        
    }

    return <EmployeeContext.Provider value={{ employees, saveEmployee }}>{children}</EmployeeContext.Provider>;
};

export const useEmployees = () => {
    return useContext(EmployeeContext);
}
