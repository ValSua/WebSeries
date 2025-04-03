import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { DirectorService } from '../../../services/director/director.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { GetDirectorDto } from '../../../models/Director/getDirectorDto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PaisService } from '../../../services/pais/pais.service';
import { Pais } from '../../../models/Pais/pais';
import { CreateDirectorDto } from '../../../models/Director/updateDirectorDto';

@Component({
  selector: 'app-edit-director',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './edit-director.component.html',
  styleUrls: ['./edit-director.component.css']
})
export class EditDirectorComponent implements OnInit {
  loading: boolean = false;
  listPath = 'directores';
  error: string | null = null;
  director: GetDirectorDto | null = null;
  directorId!: string;
  createDirector!: CreateDirectorDto;

  constructor(
    public directorService: DirectorService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute,
    public paisService: PaisService,
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.directorId = id;
      this.getDirectorById(id);
    } else {
      this.error = 'ID del director no proporcionado';
      this.loading = false;
      this.isLoading.set(false);
    }
    this.getPaises();
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);

  getDirectorById(id: string): void {
    this.loading = true;
    this.error = null;

    this.directorService.getDirectorById(id).subscribe({
      next: (response: GetDirectorDto) => {
        this.director = response;

        this.directorId = response.directorId.toString();

        this.createDirector = {
          directorId: response.directorId,
          nombre: response.nombre,
          apellido: response.apellido,
          paisId: response.paisId
        };

        this.loading = false;
        this.isLoading.set(false);
      },
      error: (err) => {
        if (err.status === 404) {
          this.error = 'Director no encontrado';
        } else {
          this.error = 'Error al cargar el director';
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
    if (!this.directorId) {   
      this.error = 'ID del director no válido.';
      return;
    }

    this.directorService.updateDirector(this.directorId, this.createDirector).subscribe({
      next: () => {
        alert('Director actualizado correctamente');
        this.router.navigate(['/directores']);
      },
      error: (err) => {
        this.error = 'Error al actualizar el director.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}