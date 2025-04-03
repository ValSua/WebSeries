export interface GetActorDto {
    actorId: number;
    nombre: string;
    apellido: string;
    nombreCompletoActor?: string;
    paisId: number;
    isDeleted: boolean;
    paisNombre: string;
    peliculasTitulo: string[];

}