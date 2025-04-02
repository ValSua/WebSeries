import { Actor } from "./actor";

export interface CreateResponse {
    isSuccess: boolean;
    result: Actor;
    message: string;
}
