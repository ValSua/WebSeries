export interface CreateDirectorDto {
    directorId: number;
    nombre: string;
    apellido: string;
    paisId: number| null;
}