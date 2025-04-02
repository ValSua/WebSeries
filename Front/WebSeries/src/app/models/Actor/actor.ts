export interface Actor {
    actorId: number;  
    nombre: string;
    apellido: string;
    paisId: number;
    isDeleted: boolean;
    paisNombre: string;  
    peliculasTitulo: string[]; 
  }