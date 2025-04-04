import { Component,   inject, OnInit, signal, WritableSignal } from '@angular/core';
import { PeliculaService } from '../../../services/pelicula/pelicula.service';
import { GetPeliculaDto } from '../../../models/Pelicula/getPeliculaDto';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DeleteResponse } from '../../../models/Actor/delete-response';

@Component({
  selector: 'app-peliculas',
  imports: [CommonModule],
  templateUrl: './peliculas.component.html',
  styleUrl: './peliculas.component.css'
})
export class PeliculasComponent implements OnInit {

  edithPath = 'editPelicula';
  createPath = 'createPelicula';

  constructor(public peliculaService: PeliculaService, public dialog: MatDialog, private router: Router,
  ) {

  }

  ngOnInit(): void {
    this.getAll();
  }
  
  public peliculas: WritableSignal<GetPeliculaDto[]> = signal([]);

  isLoading: WritableSignal<boolean> = signal(true);


  getAll() {
    this.peliculaService.getPeliculas().subscribe({
      next: (response: any) => {
        const peliculasArray: GetPeliculaDto[] = Array.isArray(response) ? response : [];
        
        this.peliculas.set(peliculasArray);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los peliculas', err);
        this.isLoading.set(false);
        this.peliculas.set([]);
      }
    });
  }

  openPeliculaEdit(id: number) {
    this.router.navigate([this.edithPath, id]);
  }

  openPeliculaCreate() {
    this.router.navigate([this.createPath]);
  }

  eliminarPelicula(id: number) {
    if (confirm('¿Está seguro que desea eliminar este pelicula?')) {
      this.peliculaService.deletePelicula(id.toString()).subscribe({
        next: (response: DeleteResponse) => {
          alert(`Pelicula eliminada con exito`);
          this.getAll();
          if (response.isSuccess) {
            this.getAll();
          } 
        },
        error: (err) => {
          console.error('Error en la solicitud de eliminación:', err);
          alert('Ocurrió un error al intentar eliminar el pelicula');
        }
      });
    }
  }
}
