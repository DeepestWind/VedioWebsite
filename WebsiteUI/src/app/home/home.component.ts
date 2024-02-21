import { Component } from '@angular/core';
import { HeaderModule } from '../header/header.module';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
