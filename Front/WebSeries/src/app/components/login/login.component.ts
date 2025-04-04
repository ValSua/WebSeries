import { CommonModule } from '@angular/common';
import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { Router, RouterModule } from '@angular/router';
import { UsuarioService } from '../../services/usuario/usuario.service';
import { Usuario } from '../../models/Usuario/usuario';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  imports: [    CommonModule,
    FormsModule,
    RouterModule,
    MatDialogModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  loaded: boolean = true;
  errorMessage: string = '';
  loginInput: string = '';   
  passwordInput: string = '';

  constructor(
    private router: Router,
    public usuarioService: UsuarioService, 
    public dialog: MatDialog, 
  ) {
    this.loaded = true;
  }

  ngOnInit(): void {
    this.getAll()
  }

  public usuarios: WritableSignal<Usuario[]> = signal([]);

  isLoading: WritableSignal<boolean> = signal(true);

  login() {
    this.errorMessage = '';
    
    // Validar campos vacíos
    if (!this.loginInput || !this.passwordInput) {
      this.errorMessage = 'Por favor, complete todos los campos';
      return;
    }

    console.log("llegó")
    // Buscar usuario por login (como es único)
    const usuarioEncontrado = this.usuarios().find(
      user => user.login.toLowerCase() === this.loginInput.toLowerCase()
    );

    if (!usuarioEncontrado) {
      alert('Usuario o contraseña incorrecta');
      return;
    }

    // Llamada al backend para validar la contraseña
    this.isLoading.set(true);
    this.usuarioService.validatePassword(usuarioEncontrado.usuarioId, this.passwordInput)
      .subscribe({
        next: (response: any) => {
          this.isLoading.set(false);
          console.log(response)
          if (response) {  // Asumiendo que el backend devuelve un boolean
            this.router.navigate(['home_page']);
          } else {
            alert('Usuario o contraseña incorrecta');
          }
        },
        error: (err) => {
          this.isLoading.set(false);
          this.errorMessage = 'Error al validar las credenciales';
          console.error('Error en validación', err);
        }
      });
  }

    getAll() {
      this.usuarioService.getUsuarios().subscribe({
        next: (response: any) => {
          const usuariosArray: Usuario[] = Array.isArray(response) ? response : [];
          
          this.usuarios.set(usuariosArray);
          this.isLoading.set(false);
        },
        error: (err) => {
          console.error('Error al obtener los usuarios', err);
          this.isLoading.set(false);
          this.usuarios.set([]);
        }
      });
    }
}
