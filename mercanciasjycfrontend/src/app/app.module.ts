import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module'; // O './app.routes.ts' dependiendo de tu estructura
import { AppComponent } from './app.component';

// Asegúrate de importar los componentes desde la ruta correcta
import { HomeComponent } from './components/home/home.component';
import { ProductosComponent } from './components/productos/productos.component';
import { PedidosComponent } from './components/pedidos/pedidos.component';
import { EntregasComponent } from './components/entregas/entregas.component';
import { ProductosService } from 'src/services/productos.service';
import { ReactiveFormsModule } from '@angular/forms'; // Importa ReactiveFormsModule
import { FormularioProductoComponent } from './components/formulario-producto/formulario-producto.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ProductosComponent,
    PedidosComponent,
    EntregasComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
