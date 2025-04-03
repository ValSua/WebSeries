import { Genero } from "../Genero/genero";
import { Pais } from "../Pais/pais";

export interface Pelicula {
    peliculaId: number;
    generoId: number;
    paisId: number;
    titulo: string;
    reseña?: string;
    imagenPortada?: string;
    codigoTrailer?: string;
    isDeleted: boolean;
    genero: Genero;
    pais: Pais;
  }