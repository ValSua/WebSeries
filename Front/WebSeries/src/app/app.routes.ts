import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { HomePageComponent } from './components/home-page/home-page.component';
import { DirectoresComponent } from './components/directores/directores.component';
import { GenerosComponent } from './components/generos/generos.component';
import { PaisesComponent } from './components/paises/paises.component';
import { PeliculasComponent } from './components/peliculas/peliculas.component';
import { ActoresComponent } from './components/actores/list-actores/actores.component';
import { EditActorComponent } from './components/actores/edit-actor/edit-actor.component';

export const routes: Routes = [
    {path: '', redirectTo: 'login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent},
    {path: 'home_page', component: HomePageComponent},
    {path: 'actores', component: ActoresComponent},
    {path: 'editActor/:id', component: EditActorComponent},
    {path: 'directores', component: DirectoresComponent},
    {path: 'generos', component: GenerosComponent},
    {path: 'paises', component: PaisesComponent},
    {path: 'peliculas', component: PeliculasComponent},
    {path: '**', component: LoginComponent},

];
