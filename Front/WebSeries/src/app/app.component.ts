import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, RouterOutlet, NavigationEnd } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [
  RouterOutlet,
  CommonModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  
  title = 'WebSeries';

  datosMenu=[
  {
    'titulo': 'Home',
    'url': 'home_page'
  },
  {
    'titulo': 'Directores',
    'url': 'directores'
  },
  {
    'titulo': 'Generos',
    'url': 'generos'
  },
  {
    'titulo': 'Paises',
    'url': 'paises'
  },
  {
    'titulo': 'Actores',
    'url': 'actores'
  },
  {
    'titulo': 'Peliculas',
    'url': 'peliculas'
  },
  {
    'titulo': 'Cerrar sesión',
    'url': 'login'
  }]

  showNavbar: boolean = true;

  constructor(private router: Router) {}

  ngOnInit() {
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {

        this.showNavbar = this.router.url !== '/login';
      }
    });
  }
}
