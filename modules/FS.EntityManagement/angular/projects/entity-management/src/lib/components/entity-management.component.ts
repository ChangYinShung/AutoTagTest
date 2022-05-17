import { Component, OnInit } from '@angular/core';
import { EntityManagementService } from '../services/entity-management.service';

@Component({
  selector: 'lib-entity-management',
  template: ` <p>entity-management works!</p> `,
  styles: [],
})
export class EntityManagementComponent implements OnInit {
  constructor(private service: EntityManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
