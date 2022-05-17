import { Component, OnInit } from '@angular/core';
import { EntityService } from '../services/entity.service';

@Component({
  selector: 'lib-entity',
  template: ` <p>entity works!</p> `,
  styles: [],
})
export class EntityComponent implements OnInit {
  constructor(private service: EntityService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
