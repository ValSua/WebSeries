import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { DirectoresComponent } from './components/directores/list-directores/directores.component';
import { GenerosComponent } from './components/generos/list-generos/generos.component';
import { PeliculasComponent } from './components/peliculas/list-peliculas/peliculas.component';
import { ActoresComponent } from './components/actores/list-actores/actores.component';
import { EditActorComponent } from './components/actores/edit-actor/edit-actor.component';
import { CreateActorComponent } from './components/actores/create-actor/create-actor.component';
import { PaisesComponent } from './components/paises/list-paises/paises.component';
import { CreateDirectorComponent } from './components/directores/create-director/create-director.component';
import { EditDirectorComponent } from './components/directores/edit-director/edit-director.component';
import { CreateGeneroComponent } from './components/generos/create-genero/create-genero.component';
import { EditGeneroComponent } from './components/generos/edit-genero/edit-genero.component';
import { CreatePaisComponent } from './components/paises/create-pais/create-pais.component';
import { EditPaisComponent } from './components/paises/edit-pais/edit-pais.component';
import { CreatePeliculaComponent } from './components/peliculas/create-pelicula/create-pelicula.component';
import { EditPeliculaComponent } from './components/peliculas/edit-pelicula/edit-pelicula.component';
import { AppComponent } from './app.component';

export const routes: Routes = [
    {path: 'app-root', component: AppComponent},
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent},
    {path: 'home_page', component: HomePageComponent},
    {path: 'actores', component: ActoresComponent},
    {path: 'editActor/:id', component: EditActorComponent},
    {path: 'createActor', component: CreateActorComponent},
    {path: 'directores', component: DirectoresComponent},
    {path: 'createDirector', component: CreateDirectorComponent},
    {path: 'editDirector/:id', component: EditDirectorComponent},
    {path: 'generos', component: GenerosComponent},
    {path: 'createGenero', component: CreateGeneroComponent},
    {path: 'editGenero/:id', component: EditGeneroComponent},
    {path: 'paises', component: PaisesComponent},
    {path: 'editPais/:id', component: EditPaisComponent},
    {path: 'createPais', component: CreatePaisComponent},
    {path: 'peliculas', component: PeliculasComponent},
    {path: 'createPelicula', component: CreatePeliculaComponent},
    {path: 'editPelicula/:id', component: EditPeliculaComponent},
    {path: '**', component: LoginComponent},

];
