import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { GeneroService } from '../../../services/genero/genero.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { GetGeneroDto } from '../../../models/Genero/getGeneroDto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PaisService } from '../../../services/pais/pais.service';
import { Pais } from '../../../models/Pais/pais';
import { CreateGeneroDto } from '../../../models/Genero/updateGeneroDto';

@Component({
  selector: 'app-edit-genero',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './edit-genero.component.html',
  styleUrls: ['./edit-genero.component.css']
})
export class EditGeneroComponent implements OnInit {
  loading: boolean = false;
  listPath = 'generos';
  error: string | null = null;
  genero: GetGeneroDto | null = null;
  generoId!: string;
  createGenero!: CreateGeneroDto;

  constructor(
    public generoService: GeneroService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute,
    public paisService: PaisService,
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.generoId = id;
      this.getGeneroById(id);
    } else {
      this.error = 'ID del genero no proporcionado';
      this.loading = false;
      this.isLoading.set(false);
    }
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);

  getGeneroById(id: string): void {
    this.loading = true;
    this.error = null;

    this.generoService.getGeneroById(id).subscribe({
      next: (response: GetGeneroDto) => {
        this.genero = response;

        this.generoId = response.generoId.toString();

        this.createGenero = {
          generoId: response.generoId,
          nombre: response.nombre
        };

        this.loading = false;
        this.isLoading.set(false);
      },
      error: (err) => {
        if (err.status === 404) {
          this.error = 'Genero no encontrado';
        } else {
          this.error = 'Error al cargar el genero';
        }
        this.loading = false;
        this.isLoading.set(false);
        console.error('Error en la solicitud:', err);
      },
    });
  }

  guardarCambios() {
    if (!this.generoId) {   
      this.error = 'ID del genero no válido.';
      return;
    }

    this.generoService.updateGenero(this.generoId, this.createGenero).subscribe({
      next: () => {
        alert('Genero actualizado correctamente');
        this.router.navigate(['/generos']);
      },
      error: (err) => {
        this.error = 'Error al actualizar el genero.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}