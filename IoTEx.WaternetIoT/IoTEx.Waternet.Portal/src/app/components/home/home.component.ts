import { Component } from '@angular/core';
import * as allIcons from "@progress/kendo-svg-icons";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public icon = allIcons;
  public icons = { chevronRightIcon: this.icon.chevronRightIcon };

}
