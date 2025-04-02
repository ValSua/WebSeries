import { Component, signal, WritableSignal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DeleteResponse } from '../../../models/Actor/delete-response';
import { DirectorService } from '../../../services/director/director.service';
import { GetDirectorDto } from '../../../models/Director/getDirectorDto';

@Component({
  selector: 'app-directores',
  imports: [],
  templateUrl: './directores.component.html',
  styleUrl: './directores.component.css'
})
export class DirectoresComponent {

  edithPath = 'editDirector';
  createPath = 'createDirector';

  constructor(public directorService: DirectorService, public dialog: MatDialog, private router: Router,
  ) {

  }

  ngOnInit(): void {
    this.getAll();
  }
  
  public directores: WritableSignal<GetDirectorDto[]> = signal([]);

  isLoading: WritableSignal<boolean> = signal(true);


  getAll() {
    this.directorService.getDirectores().subscribe({
      next: (response: any) => {
        const directoresArray: GetDirectorDto[] = Array.isArray(response) ? response : [];
        
        this.directores.set(directoresArray);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los directores', err);
        this.isLoading.set(false);
        this.directores.set([]);
      }
    });
  }

  openDirectorEdit(id: number) {
    this.router.navigate([this.edithPath, id]);
  }

  openDirectorCreate() {
    this.router.navigate([this.createPath]);
  }

  eliminarDirector(id: number) {
    if (confirm('¿Está seguro que desea eliminar este director?')) {
      this.directorService.deleteDirector(id.toString()).subscribe({
        next: (response: DeleteResponse) => {
          alert(`Director eliminado con exito`);
          this.getAll();
          if (response.isSuccess) {
            this.getAll();
          } 
        },
        error: (err) => {
          console.error('Error en la solicitud de eliminación:', err);
          alert('Ocurrió un error al intentar eliminar el director');
        }
      });
    }
  }
}
