// src/app/components/productos/productos.component.ts

import { Component, OnInit } from '@angular/core';
import { ProductosService } from 'src/services/productos.service'; // Ajusta la ruta si es necesario

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss']
})
export class ProductosService implements OnInit {
  productos: any[] = []; // Define el tipo si tienes una interfaz para los productos

  constructor(private productosService: ProductosService) { }

  ngOnInit(): void {
    this.getProductos();
  }

  getProductos(): void {
    this.productosService.getProductos().subscribe(
      (data: any[]) => {
        this.productos = data;
        console.log('Productos:', this.productos); // Para verificar en la consola
      },
      (error) => {
        console.error('Error al obtener productos', error);
      }
    );
  }
}
