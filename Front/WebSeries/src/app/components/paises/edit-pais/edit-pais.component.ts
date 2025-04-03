import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { GetPaisDto } from '../../../models/Pais/getPaisDto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Pais } from '../../../models/Pais/pais';
import { CreatePaisDto } from '../../../models/Pais/updatePaisDto';
import { PaisService } from '../../../services/pais/pais.service';

@Component({
  selector: 'app-edit-pais',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './edit-pais.component.html',
  styleUrls: ['./edit-pais.component.css']
})
export class EditPaisComponent implements OnInit {
  loading: boolean = false;
  listPath = 'paises';
  error: string | null = null;
  pais: GetPaisDto | null = null;
  paisId!: string;
  createPais!: CreatePaisDto;

  constructor(
    public paisService: PaisService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute
  ) { }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.paisId = id;
      this.getPaisById(id);
    } else {
      this.error = 'ID del pais no proporcionado';
      this.loading = false;
      this.isLoading.set(false);
    }
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);

  getPaisById(id: string): void {
    this.loading = true;
    this.error = null;

    this.paisService.getPaisById(id).subscribe({
      next: (response: GetPaisDto) => {
        this.pais = response;

        this.paisId = response.paisId.toString();

        this.createPais = {
          paisId: response.paisId,
          nombre: response.nombre
        };

        this.loading = false;
        this.isLoading.set(false);
      },
      error: (err) => {
        if (err.status === 404) {
          this.error = 'Pais no encontrado';
        } else {
          this.error = 'Error al cargar el pais';
        }
        this.loading = false;
        this.isLoading.set(false);
        console.error('Error en la solicitud:', err);
      },
    });
  }

  guardarCambios() {
    if (!this.paisId) {   
      this.error = 'ID del pais no válido.';
      return;
    }

    this.paisService.updatePais(this.paisId, this.createPais).subscribe({
      next: () => {
        alert('Pais actualizado correctamente');
        this.router.navigate(['/paises']);
      },
      error: (err) => {
        this.error = 'Error al actualizar el pais.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}