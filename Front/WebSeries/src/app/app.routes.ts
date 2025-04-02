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

export const routes: Routes = [
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
    {path: 'paises', component: PaisesComponent},
    {path: 'peliculas', component: PeliculasComponent},
    {path: '**', component: LoginComponent},

];
