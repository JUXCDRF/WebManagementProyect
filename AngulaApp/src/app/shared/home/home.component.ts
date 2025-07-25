import { Component } from '@angular/core';
import { SidebarComponent } from "../sidebar/sidebar.component";
import { RouterOutlet } from '@angular/router';
import { FooterComponent } from "../footer/footer.component";

@Component({
  selector: 'app-home',
  imports: [
    RouterOutlet,
    SidebarComponent,
],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  logo:string="assets/imagenes/stelarlogo.png";
}
