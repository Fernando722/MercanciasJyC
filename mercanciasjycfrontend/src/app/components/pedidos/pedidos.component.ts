import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { PedidosService } from 'src/services/pedidos.service'; // Ajusta la ruta si es necesario

@Component({
  selector: 'app-pedidos',
  templateUrl: './pedidos.component.html',
  styleUrls: ['./pedidos.component.css']
})
export class PedidosComponent implements OnInit {
  pedidos: any[] = [];
  pedidoForm: FormGroup;

  constructor(private pedidosService: PedidosService, private fb: FormBuilder) {
    this.pedidoForm = this.fb.group({
      clienteID: [''],
      fechaPedido: [''],
      estado: [''],
      fechaEntrega: [''],
      total: ['']
    });
  }

  ngOnInit(): void {
    this.getPedidos();
  }

  getPedidos(): void {
    this.pedidosService.getPedidos().subscribe((data: any[]) => {
      this.pedidos = data;
    });
  }

  createPedido(): void {
    const nuevoPedido = this.pedidoForm.value;
    this.pedidosService.createPedido(nuevoPedido).subscribe(() => {
      this.getPedidos();
    });
  }
}
