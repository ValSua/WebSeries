import { Component,   inject, OnInit, signal, WritableSignal } from '@angular/core';
import { ActorService } from '../../../services/actor/actor.service';
import { GetActorDto } from '../../../models/Actor/getActorDto';
import { CommonModule } from '@angular/common';
import { Actor } from '../../../models/Actor/actor';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DeleteResponse } from '../../../models/Actor/delete-response';

@Component({
  selector: 'app-actores',
  imports: [CommonModule],
  templateUrl: './actores.component.html',
  styleUrl: './actores.component.css'
})
export class ActoresComponent implements OnInit {

  edithPath = 'editActor';
  constructor(public actorService: ActorService, public dialog: MatDialog, private router: Router,
  ) {

  }

  ngOnInit(): void {
    this.getAll();
  }
  
  public actores: WritableSignal<GetActorDto[]> = signal([]);

  isLoading: WritableSignal<boolean> = signal(true);


  getAll() {
    this.actorService.getActores().subscribe({
      next: (response: any) => {
        const actoresArray: Actor[] = Array.isArray(response) ? response : [];
        
        this.actores.set(actoresArray);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los actores', err);
        this.isLoading.set(false);
        this.actores.set([]);
      }
    });
  }

  openActorEdit(id: number) {
    this.router.navigate([this.edithPath, id]);
  }

  eliminarActor(id: number) {
    if (confirm('¿Está seguro que desea eliminar este actor?')) {
      this.actorService.deleteActor(id.toString()).subscribe({
        next: (response: DeleteResponse) => {
          alert(`Actor eliminado con exito`);
          this.getAll();
          if (response.isSuccess) {
            this.getAll();
          } 
        },
        error: (err) => {
          console.error('Error en la solicitud de eliminación:', err);
          alert('Ocurrió un error al intentar eliminar el actor');
        }
      });
    }
  }
}
