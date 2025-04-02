import { Component, OnInit, signal, WritableSignal } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { DeleteResponse } from '../../../models/Actor/delete-response';
import { PaisService } from '../../../services/pais/pais.service';
import { GetPaisDto } from '../../../models/Pais/getPaisDto';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-paises',
  imports: [CommonModule],
  templateUrl: './paises.component.html',
  styleUrl: './paises.component.css'
})
export class PaisesComponent implements OnInit{

  edithPath = 'editPais';
  createPath = 'createPais';

  constructor(public paisService: PaisService, public dialog: MatDialog, private router: Router,
  ) {

  }

  ngOnInit(): void {
    this.getAll();
  }
  
  public paises: WritableSignal<GetPaisDto[]> = signal([]);

  isLoading: WritableSignal<boolean> = signal(true);


  getAll() {
    this.paisService.getPaises().subscribe({
      next: (response: any) => {
        const paisesArray: GetPaisDto[] = Array.isArray(response) ? response : [];
        
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

  openPaisEdit(id: number) {
    this.router.navigate([this.edithPath, id]);
  }

  openPaisCreate() {
    this.router.navigate([this.createPath]);
  }

  eliminarPais(id: number) {
    if (confirm('¿Está seguro que desea eliminar este pais?')) {
      this.paisService.deletePais(id.toString()).subscribe({
        next: (response: DeleteResponse) => {
          alert(`Pais eliminado con exito`);
          this.getAll();
          if (response.isSuccess) {
            this.getAll();
          } 
        },
        error: (err) => {
          console.error('Error en la solicitud de eliminación:', err);
          alert('Ocurrió un error al intentar eliminar el pais');
        }
      });
    }
  }
}
