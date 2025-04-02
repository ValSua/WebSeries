export interface CreatePeliculaDto {
    peliculaId: number;
    generoId: number;
    paisId: number;
    titulo: string;
    resena?: string;
    imagenPortada?: string;
    codigoTrailer?: string;
    directors: [];
    actors: [];
  }