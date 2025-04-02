import { GetPeliculaDto } from "./getPeliculaDto";

export interface PeliculasResponse {
    isSuccess: boolean;
    result: GetPeliculaDto[];
    message: string;
}
