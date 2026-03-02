import { Component, Input } from '@angular/core';
import * as DTO from '../../models/_index'

@Component({
  selector: 'app-grid-network-api-detail',
  templateUrl: './grid-network-api-detail.component.html',
  styleUrls: ['./grid-network-api-detail.component.css']
})
export class GridNetworkAPIDetailComponent {

  @Input() public networkAPI: DTO.NetworkAPIDTO

}
