import IAddressCreateRequest from "./IAddressCreateRequest";
import ISkillCreateRequest from "./ISkillCreateRequest";

interface IEmployeeCreateRequest {
    firstName: string;
    lastName: string;
    email: string;
    contactNumber: string;
    dateOfBirth: Date;
    address: IAddressCreateRequest;
    skills: ISkillCreateRequest[];
}

export default IEmployeeCreateRequest;