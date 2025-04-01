import { Actor } from "./actor";

export interface ActoresResponse {
    isSuccess: boolean;
    result: Actor[];
    message: string;
}
