import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { GetActorDto } from '../../../models/Actor/getActorDto';
import { GetDirectorDto } from '../../../models/Director/getDirectorDto';
import { GetGeneroDto } from '../../../models/Genero/getGeneroDto';
import { Pais } from '../../../models/Pais/pais';
import { GetPeliculaDto } from '../../../models/Pelicula/getPeliculaDto';
import { CreatePeliculaDto } from '../../../models/Pelicula/updatePeliculaDto';
import { ActorService } from '../../../services/actor/actor.service';
import { DirectorService } from '../../../services/director/director.service';
import { GeneroService } from '../../../services/genero/genero.service';
import { PaisService } from '../../../services/pais/pais.service';
import { PeliculaService } from '../../../services/pelicula/pelicula.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-create-pelicula',
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule,
    MultiSelectModule         
  ],
  templateUrl: './create-pelicula.component.html',
  styleUrl: './create-pelicula.component.css'
})
export class CreatePeliculaComponent implements OnInit{

  loading: boolean = false;
  listPath = 'peliculas';
  error: string | null = null;
  pelicula: GetPeliculaDto | null = null;
  peliculaId!: string;
  createPelicula: CreatePeliculaDto = { 
    peliculaId: 0,
    generoId: null,
    paisId: null,
    titulo: '',
    resena: '',
    imagenPortada: '',
    codigoTrailer: '',
    directors: [],
    actors: [],
    };

  constructor(
    public peliculaService: PeliculaService,
    public dialog: MatDialog,
    private router: Router,
    private route: ActivatedRoute,
    public paisService: PaisService,
    public generoService: GeneroService,
    public actorService: ActorService,
    public directorService: DirectorService,
  ) { }

  ngOnInit(): void {
    this.getActores();
    this.getPaises();
    this.getGeneros();
    this.getDirectores();
    this.loading = false;
    this.isLoading.set(false);
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);
  public generos: WritableSignal<GetGeneroDto[]> = signal([]);
  public actores: WritableSignal<GetActorDto[]> = signal([]);
  public directores: WritableSignal<GetDirectorDto[]> = signal([]);

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

  getGeneros() {
    this.generoService.getGeneros().subscribe({
      next: (response: any) => {
        const generosArray: GetGeneroDto[] = Array.isArray(response) ? response : [];

        this.generos.set(generosArray);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los generos', err);
        this.isLoading.set(false);
        this.generos.set([]);
      }
    });
  }

  getActores() {
    this.actorService.getActores().subscribe({
      next: (response: any) => {
        const actoresArray: GetActorDto[] = Array.isArray(response) ? response : [];
        const actoresConNombreCompleto = actoresArray.map(actor => ({
          ...actor,
          nombreCompletoActor: `${actor.nombre} ${actor.apellido}`
        }));

        this.actores.set(actoresConNombreCompleto);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los actores', err);
        this.isLoading.set(false);
        this.actores.set([]);
      }
    });
  }

  getDirectores() {
    this.directorService.getDirectores().subscribe({
      next: (response: any) => {
        const directoresArray: GetDirectorDto[] = Array.isArray(response) ? response : [];
        const directoresConNombreCompleto = directoresArray.map(director => ({
          ...director,
          nombreCompletoDirector: `${director.nombre} ${director.apellido}`
        }));

        this.directores.set(directoresConNombreCompleto);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los directores', err);
        this.isLoading.set(false);
        this.directores.set([]);
      }
    });
  }

  guardarCambios() {

    this.peliculaService.createPelicula(this.createPelicula).subscribe({
      next: () => {
        alert('Pelicula creada correctamente');
        this.router.navigate(['/peliculas']);
      },
      error: (err) => {
        this.error = 'Error al crear la pelicula.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}
