import { CreateActorDto } from "./updateActorDto";

export interface EditResponse {
    isSuccess: boolean;
    result: CreateActorDto;
    message: string;
}
