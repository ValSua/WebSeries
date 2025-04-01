import { Component,   inject, OnInit, signal, WritableSignal } from '@angular/core';
import { ActorService } from '../../../services/actor/actor.service';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';

@Component({
  selector: 'app-edit-actor',
  imports: [],
  templateUrl: './edit-actor.component.html',
  styleUrl: './edit-actor.component.css'
})
export class EditActorComponent implements OnInit {

  edithPath = 'editActor';
  constructor(public actorService: ActorService, public dialog: MatDialog, private router: Router,
  ) {

  }

  ngOnInit(): void {
    //this.getActorById();
  }
  
  // public actores: WritableSignal<GetActorDto[]> = signal([]);

  isLoading: WritableSignal<boolean> = signal(true);

  // editarActor(id: number) {
  //   // Buscar el actor a editar
  //   const actor = this.actores().find(a => a.actorId === id);
  //   if (actor) {
  //     // Crear el objeto DTO para edición
  //     this.editingActor.set({
  //       nombre: actor.nombre,
  //       apellido: actor.apellido,
  //       paisId: actor.paisId
  //     });
  //     this.editingActorId.set(id.toString());
  //     this.isEditing.set(true);
  //   }
  // }

  guardarCambios() {
    
  }
}
