import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  imports: [],
  templateUrl: './home-page.component.html',
  styleUrl: './home-page.component.css'
})
export class HomePageComponent {
  loaded: boolean = true;

  constructor(
    private router: Router,
  ) {
    this.loaded = true;
  }

  ngOnInit(): void {
    
  }

  actores() {
    this.router.navigate(['/actores'])
  }

  directores() {
    this.router.navigate(['/directores'])
  }

  paises() {
    this.router.navigate(['/paises'])
  }

  peliculas() {
    this.router.navigate(['/actores'])
  }

  generos() {
    this.router.navigate(['/generos'])
  }
}
