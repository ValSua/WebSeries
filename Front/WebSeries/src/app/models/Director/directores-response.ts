import { GetDirectorDto } from "./getDirectorDto";

export interface DirectoresResponse {
    isSuccess: boolean;
    result: GetDirectorDto[];
    message: string;
}
