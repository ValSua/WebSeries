import { GetGeneroDto } from "./getGeneroDto";

export interface GenerosResponse {
        isSuccess: boolean;
        result: GetGeneroDto[];
        message: string;
}
