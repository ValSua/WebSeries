import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './home-page.component.html'
})
export class HomePageComponent {
  title = 'HomePage';
}
