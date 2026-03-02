import { Component, Input } from '@angular/core';
import * as DTO from '../../models/_index'

@Component({
  selector: 'app-grid-project-detail',
  templateUrl: './grid-project-detail.component.html',
  styleUrls: ['./grid-project-detail.component.css']
})
export class GridProjectDetailComponent {

  @Input() public project: DTO.ProjectDTO
}
