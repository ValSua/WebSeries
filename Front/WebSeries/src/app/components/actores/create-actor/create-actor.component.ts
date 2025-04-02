import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { GetActorDto } from '../../../models/Actor/getActorDto';
import { CreateActorDto } from '../../../models/Actor/updateActorDto';
import { Pais } from '../../../models/Pais/pais';
import { ActorService } from '../../../services/actor/actor.service';
import { PaisService } from '../../../services/pais/pais.service';

@Component({
  selector: 'app-create-actor',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './create-actor.component.html',
  styleUrl: './create-actor.component.css'
})
export class CreateActorComponent implements OnInit {

  loading: boolean = true; 
  listPath = 'actores';
  error: string | null = null;
  createActor: CreateActorDto = { 
    actorId: 0,
    nombre: '',
    apellido: '',
    paisId: null
  };

  constructor(
    public actorService: ActorService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute,
    public paisService: PaisService,
  ) { }

  ngOnInit(): void {
    this.loading = true; 
    this.getPaises(); 
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);

  getPaises() {
    this.paisService.getPaises().subscribe({
      next: (response: any) => {
        const paisesArray: Pais[] = Array.isArray(response) ? response : [];
        this.paises.set(paisesArray);
        this.isLoading.set(false);
        this.loading = false; 
      },
      error: (err) => {
        console.error('Error al obtener los países', err);
        this.isLoading.set(false);
        this.loading = false;
        this.paises.set([]);
      }
    });
  }

  guardarCambios() {
    this.actorService.createActor(this.createActor).subscribe({
      next: () => {
        alert('Actor creado correctamente');
        this.router.navigate(['/actores']);
      },
      error: (err) => {
        this.error = 'Error al crear el actor.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}
