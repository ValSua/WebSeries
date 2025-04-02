import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { PeliculaService } from '../../../services/pelicula/pelicula.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, ActivatedRoute, RouterModule } from '@angular/router';
import { GetPeliculaDto } from '../../../models/Pelicula/getPeliculaDto';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { PaisService } from '../../../services/pais/pais.service';
import { Pais } from '../../../models/Pais/pais';
import { CreatePeliculaDto } from '../../../models/Pelicula/updatePeliculaDto';
import { GetGeneroDto } from '../../../models/Genero/getGeneroDto';
import { GeneroService } from '../../../services/genero/genero.service';
import { Actor } from '../../../models/Actor/actor';
import { GetActorDto } from '../../../models/Actor/getActorDto';
import { ActorService } from '../../../services/actor/actor.service';
import { GetDirectorDto } from '../../../models/Director/getDirectorDto';
import { DirectorService } from '../../../services/director/director.service';
import { MultiSelectModule } from 'primeng/multiselect';

@Component({
  selector: 'app-edit-pelicula',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule,
    MultiSelectModule         
  ],
  templateUrl: './edit-pelicula.component.html',
  styleUrls: ['./edit-pelicula.component.css']
})
export class EditPeliculaComponent implements OnInit {
  loading: boolean = false;
  listPath = 'peliculas';
  error: string | null = null;
  pelicula: GetPeliculaDto | null = null;
  peliculaId!: string;
  createPelicula!: CreatePeliculaDto;

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
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.peliculaId = id;
      this.getPeliculaById(id);
    } else {
      this.error = 'ID del pelicula no proporcionado';
    }

    this.getPaises();
    this.getGeneros();
    this.getActores();
    this.getDirectores();
    this.loading = false;
    this.isLoading.set(false);
  }

  public paises: WritableSignal<Pais[]> = signal([]);
  isLoading: WritableSignal<boolean> = signal(true);
  public generos: WritableSignal<GetGeneroDto[]> = signal([]);
  public actores: WritableSignal<GetActorDto[]> = signal([]);
  public directores: WritableSignal<GetDirectorDto[]> = signal([]);


  getPeliculaById(id: string): void {
    this.loading = true;
    this.error = null;

    this.peliculaService.getPeliculaById(id).subscribe({
      next: (response: GetPeliculaDto) => {
        this.pelicula = response;

        this.peliculaId = response.peliculaId.toString();

        this.createPelicula = {
          peliculaId: response.peliculaId,
          generoId: response.generoId,
          paisId: response.paisId,
          titulo: response.titulo,
          resena: response.resena,
          imagenPortada: response.imagenPortada,
          codigoTrailer: response.codigoTrailer,
          directors: [],
          actors: [],
        };

        this.loading = false;
        this.isLoading.set(false);
      },
      error: (err) => {
        if (err.status === 404) {
          this.error = 'Pelicula no encontrado';
        } else {
          this.error = 'Error al cargar el pelicula';
        }
        this.loading = false;
        this.isLoading.set(false);
        console.error('Error en la solicitud:', err);
      },
    });
  }

  compareActors(a: string, b: string): boolean {
    return a === b;
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
        const actoresArray: Actor[] = Array.isArray(response) ? response : [];

        this.actores.set(actoresArray);
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

        this.directores.set(directoresArray);
        this.isLoading.set(false);
      },
      error: (err) => {
        console.error('Error al obtener los directores', err);
        this.isLoading.set(false);
        this.directores.set([]);
      }
    });
  }

  guardarCambios() {//
    if (!this.peliculaId) {
      this.error = 'ID del pelicula no válido.';
      return;
    }

    this.peliculaService.updatePelicula(this.peliculaId, this.createPelicula).subscribe({
      next: () => {
        alert('Pelicula actualizado correctamente');
        this.router.navigate(['/peliculas']);
      },
      error: (err) => {
        this.error = 'Error al actualizar el pelicula.';
        console.error(err);
      },
    });
  }

  cancelar() {
    this.router.navigate([this.listPath]);
  }
}