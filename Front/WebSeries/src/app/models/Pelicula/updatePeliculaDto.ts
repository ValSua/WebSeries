export interface CreatePeliculaDto {
    peliculaId: number;
    generoId: number| null;
    paisId: number| null;
    titulo: string;
    resena?: string;
    imagenPortada?: string;
    codigoTrailer?: string;
    directors: number[];
    actors: number[];
  }