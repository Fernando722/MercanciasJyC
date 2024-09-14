import { Component, OnInit } from '@angular/core';
import { ProductosService } from 'src/services/productos.service'; 

@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.scss']
})
export class ProductosComponent implements OnInit {
  productos: any[] = [];

  constructor(private productosService: ProductosService) { }

  ngOnInit(): void {
    
  }

  
}
