export interface GetActorDto {
    actorId: number;
    nombre: string;
    apellido: string;
    paisId: number;
    isDeleted: boolean;
    paisNombre: string;
    peliculasTitulo: string[];

    // constructor() {
    //     this.peliculasTitulo = [];
    // }
}