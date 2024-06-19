import EmployeeResponse from "../../models/employees/responses/EmployeeResponse";
import { EmployeeContextActions } from "../actions/EmployeeContextActions";

export const EmployeeReducer = (state: EmployeeResponse[], action: EmployeeContextActions): EmployeeResponse[] => {
    switch(action.type){
        case 'ADD_EMPLOYEE':
            return [...state]

    }
}