import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Pais } from '../../../models/Pais/pais';
import { PaisService } from '../../../services/pais/pais.service';
import { CreateDirectorDto } from '../../../models/Director/updateDirectorDto';
import { DirectorService } from '../../../services/director/director.service';

@Component({
  selector: 'app-create-director',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule
  ],
  templateUrl: './create-director.component.html',
  styleUrl: './create-director.component.css'
})
export class CreateDirectorComponent implements OnInit {

  loading: boolean = true; 
  listPath = 'directores';
  error: string | null = null;
  createDirector: CreateDirectorDto = { 
    directorId: 0,
    nombre: '',
    apellido: '',
    paisId: null
  };

  constructor(
    public directorService: DirectorService,
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
    this.directorService.createDirector(this.createDirector).subscribe({
      next: () => {
        alert('Director creado correctamente');
        this.router.navigate(['/directores']);
      },
      error: (err) => {
        this.error = 'Error al crear el director.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}
