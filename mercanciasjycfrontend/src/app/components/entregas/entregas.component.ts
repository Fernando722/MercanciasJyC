import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { EntregasService } from 'src/services/entregas.service'; // Ajusta la ruta si es necesario

@Component({
  selector: 'app-entregas',
  templateUrl: './entregas.component.html',
  styleUrls: ['./entregas.component.css']
})
export class EntregasComponent implements OnInit {
  entregas: any[] = [];
  entregaForm: FormGroup;

  constructor(private entregasService: EntregasService, private fb: FormBuilder) {
    this.entregaForm = this.fb.group({
      pedidoID: [''],
      fechaEntrega: [''],
      estado: ['']
    });
  }

  ngOnInit(): void {
    this.getEntregas();
  }

  getEntregas(): void {
    this.entregasService.getEntregas().subscribe((data: any[]) => {
      this.entregas = data;
    });
  }

  createEntrega(): void {
    const nuevaEntrega = this.entregaForm.value;
    this.entregasService.createEntrega(nuevaEntrega).subscribe(() => {
      this.getEntregas();
    });
  }
}
