import { Pais } from "./pais";

export interface PaisesResponse {
    isSuccess: boolean;
    result: Pais[];
    message: string;
}
