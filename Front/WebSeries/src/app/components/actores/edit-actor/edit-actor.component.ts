import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { ActorService } from '../../../services/actor/actor.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { GetActorDto } from '../../../models/Actor/getActorDto';
import { ActorResponse } from '../../../models/Actor/actor-response';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common'; // Para NgIf, NgFor, etc.

@Component({
  selector: 'app-edit-actor',
  standalone: true, // Indica que es un componente standalone
  imports: [
    CommonModule, // Reemplaza BrowserModule
    FormsModule,  // Para ngModel
    RouterModule, // Para router y ActivatedRoute
    MatDialogModule // Si usas MatDialog
  ],
  templateUrl: './edit-actor.component.html',
  styleUrls: ['./edit-actor.component.css']
})
export class EditActorComponent implements OnInit {
  loading: boolean = false;
  listPath = 'actores';
  error: string | null = null;
  actor: GetActorDto | null = null;

  constructor(
    public actorService: ActorService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.getActorById(id);
    } else {
      this.error = 'ID del actor no proporcionado';
      this.loading = false;
      this.isLoading.set(false);
    }
  }

  isLoading: WritableSignal<boolean> = signal(true);

  getActorById(id: string): void {
    this.loading = true;
    this.error = null;
    console.log('Haciendo solicitud para ID:', id);

    this.actorService.getActorById(id).subscribe({
      next: (response: GetActorDto) => {
        console.log('Respuesta del servicio:', response);
        this.actor = response; // Asigna directamente la respuesta
        this.loading = false;
        this.isLoading.set(false);
        console.log('Actor asignado:', this.actor);
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
      complete: () => {
        console.log('Carga completada');
      }
    });
  }

  guardarCambios() {
    console.log('Datos a guardar:', this.actor);
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}