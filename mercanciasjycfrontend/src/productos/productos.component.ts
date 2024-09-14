import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ProductosService } from '../api/productos.service';

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})
export class ProductosComponent implements OnInit {
  productoForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private productosService: ProductosService
  ) {
    this.productoForm = this.fb.group({
      nombre: ['', Validators.required],
      // Otros campos con validaciones
    });
  }

  ngOnInit(): void {
    // Inicialización si es necesario
  }

  onSubmit(): void {
    if (this.productoForm.valid) {
      this.productosService.createProducto(this.productoForm.value).subscribe(response => {
        // Manejar la respuesta
      });
    }
  }
}
