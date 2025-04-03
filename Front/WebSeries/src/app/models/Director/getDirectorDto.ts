export interface GetDirectorDto {
    directorId: number;
    nombre: string;
    nombreCompletoDirector?: string;
    apellido: string;
    paisId: number;
    isDeleted: boolean;
    paisNombre: string;
    peliculasTitulo: string[];
}