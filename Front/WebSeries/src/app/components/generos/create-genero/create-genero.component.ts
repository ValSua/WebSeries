import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Pais } from '../../../models/Pais/pais';
import { PaisService } from '../../../services/pais/pais.service';
import { CreateGeneroDto } from '../../../models/Genero/updateGeneroDto';
import { GeneroService } from '../../../services/genero/genero.service';

@Component({
  selector: 'app-create-genero',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './create-genero.component.html',
  styleUrl: './create-genero.component.css'
})
export class CreateGeneroComponent implements OnInit {

  loading: boolean = true; 
  listPath = 'generos';
  error: string | null = null;
  createGenero: CreateGeneroDto = { 
    generoId: 0,
    nombre: ''
  };

  constructor(
    public generoService: GeneroService,
    public dialog: MatDialog,
    private router: Router,
    public paisService: PaisService,
  ) { }

  ngOnInit(): void {
    this.loading = false; 
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);

  guardarCambios() {
    this.generoService.createGenero(this.createGenero).subscribe({
      next: () => {
        alert('Genero creado correctamente');
        this.router.navigate(['/generos']);
      },
      error: (err) => {
        this.error = 'Error al crear el genero.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}
