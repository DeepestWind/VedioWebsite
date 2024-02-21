import { Component } from '@angular/core';
import { HeaderModule } from '../header/header.module';
import { TesthttpComponent } from '../testhttp/testhttp.component';
@Component({
  selector: 'app-home',
  standalone: true,
  imports: [HeaderModule,TesthttpComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
