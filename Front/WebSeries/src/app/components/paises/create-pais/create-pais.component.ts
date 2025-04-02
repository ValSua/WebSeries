import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Pais } from '../../../models/Pais/pais';
import { PaisService } from '../../../services/pais/pais.service';
import { CreatePaisDto } from '../../../models/Pais/updatePaisDto';

@Component({
  selector: 'app-create-pais',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './create-pais.component.html',
  styleUrl: './create-pais.component.css'
})
export class CreatePaisComponent implements OnInit {

  loading: boolean = true; 
  listPath = 'paises';
  error: string | null = null;
  createPais: CreatePaisDto = { 
    paisId: 0,
    nombre: ''
  };

  constructor(
    public paisService: PaisService,
    public dialog: MatDialog,
    private router: Router,
  ) { }

  ngOnInit(): void {
    this.loading = false; 
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);

  guardarCambios() {
    this.paisService.createPais(this.createPais).subscribe({
      next: () => {
        alert('Pais creado correctamente');
        this.router.navigate(['/paises']);
      },
      error: (err) => {
        this.error = 'Error al crear el pais.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}
