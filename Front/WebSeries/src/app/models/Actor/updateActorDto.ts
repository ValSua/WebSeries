export interface CreateActorDto {
    actorId: number;
    nombre: string;
    apellido: string;
    paisId: number| null;
}