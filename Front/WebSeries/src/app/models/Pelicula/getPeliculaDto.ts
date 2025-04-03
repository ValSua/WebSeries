export interface GetPeliculaDto {
    peliculaId: number;
    generoId: number;
    generoNombre: string;
    paisId: number;
    paisNombre: string;
    titulo: string;
    resena?: string;
    imagenPortada?: string;
    codigoTrailer?: string;
    isDeleted: boolean;
    directors: number[] ;
    actors: number[] ;
  }