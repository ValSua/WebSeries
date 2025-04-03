import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { ActorService } from '../../../services/actor/actor.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { GetActorDto } from '../../../models/Actor/getActorDto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PaisService } from '../../../services/pais/pais.service';
import { Pais } from '../../../models/Pais/pais';
import { CreateActorDto } from '../../../models/Actor/updateActorDto';

@Component({
  selector: 'app-edit-actor',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './edit-actor.component.html',
  styleUrls: ['./edit-actor.component.css']
})
export class EditActorComponent implements OnInit {
  loading: boolean = false;
  listPath = 'actores';
  error: string | null = null;
  actor: GetActorDto | null = null;
  actorId!: string;
  createActor!: CreateActorDto;

  constructor(
    public actorService: ActorService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute,
    public paisService: PaisService,
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.actorId = id;
      this.getActorById(id);
    } else {
      this.error = 'ID del actor no proporcionado';
      this.loading = false;
      this.isLoading.set(false);
    }
    this.getPaises();
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);

  getActorById(id: string): void {
    this.loading = true;
    this.error = null;

    this.actorService.getActorById(id).subscribe({
      next: (response: GetActorDto) => {
        this.actor = response;

        this.actorId = response.actorId.toString();

        this.createActor = {
          actorId: response.actorId,
          nombre: response.nombre,
          apellido: response.apellido,
          paisId: response.paisId
        };

        this.loading = false;
        this.isLoading.set(false);
      },
      error: (err) => {
        if (err.status === 404) {
          this.error = 'Actor no encontrado';
        } else {
          this.error = 'Error al cargar el actor';
        }
        this.loading = false;
        this.isLoading.set(false);
        console.error('Error en la solicitud:', err);
      },
    });
  }

  getPaises() {
    this.paisService.getPaises().subscribe({
      next: (response: any) => {
        const paisesArray: Pais[] = Array.isArray(response) ? response : [];

        this.paises.set(paisesArray);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los paises', err);
        this.isLoading.set(false);
        this.paises.set([]);
      }
    });
  }

  guardarCambios() {
    if (!this.actorId) {   
      this.error = 'ID del actor no válido.';
      return;
    }

    this.actorService.updateActor(this.actorId, this.createActor).subscribe({
      next: () => {
        alert('Actor actualizado correctamente');
        this.router.navigate(['/actores']);
      },
      error: (err) => {
        this.error = 'Error al actualizar el actor.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}