import { Usuario } from "./usuario";

export interface UsuariosResponse {
    isSuccess: boolean;
    result: Usuario[];
    message: string;
}
