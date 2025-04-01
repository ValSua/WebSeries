import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {
  loaded: boolean = true;

  constructor(
    private router: Router,
  ) {
    this.loaded = true;
  }

  ngOnInit(): void {
    
  }

  login() {
    this.router.navigate(['/home_page'])
  }
}
