import SeniorityRating from "../../enums/SeniorityRating";

interface ISkillCreateRequest {
    name: string;
    yearsOfExperience: number;
    rating: SeniorityRating;
}

export default ISkillCreateRequest;