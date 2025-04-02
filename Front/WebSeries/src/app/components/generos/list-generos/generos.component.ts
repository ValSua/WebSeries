import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DeleteResponse } from '../../../models/Actor/delete-response';
import { GeneroService } from '../../../services/genero/genero.service';
import { GetGeneroDto } from '../../../models/Genero/getGeneroDto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-generos',
  imports: [CommonModule],
  templateUrl: './generos.component.html',
  styleUrl: './generos.component.css'
})
export class GenerosComponent implements OnInit{

  edithPath = 'editGenero';
  createPath = 'createGenero';

  constructor(public generoService: GeneroService, public dialog: MatDialog, private router: Router,
  ) {

  }

  ngOnInit(): void {
    this.getAll();
  }
  
  public generos: WritableSignal<GetGeneroDto[]> = signal([]);

  isLoading: WritableSignal<boolean> = signal(true);


  getAll() {
    this.generoService.getGeneros().subscribe({
      next: (response: any) => {
        const generosArray: GetGeneroDto[] = Array.isArray(response) ? response : [];
        
        this.generos.set(generosArray);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los generos', err);
        this.isLoading.set(false);
        this.generos.set([]);
      }
    });
  }

  openGeneroEdit(id: number) {
    this.router.navigate([this.edithPath, id]);
  }

  openGeneroCreate() {
    this.router.navigate([this.createPath]);
  }

  eliminarGenero(id: number) {
    if (confirm('¿Está seguro que desea eliminar este genero?')) {
      this.generoService.deleteGenero(id.toString()).subscribe({
        next: (response: DeleteResponse) => {
          alert(`Genero eliminado con exito`);
          this.getAll();
          if (response.isSuccess) {
            this.getAll();
          } 
        },
        error: (err) => {
          console.error('Error en la solicitud de eliminación:', err);
          alert('Ocurrió un error al intentar eliminar el genero');
        }
      });
    }
  }
}
