import { Component, OnInit } from '@angular/core';
import { ContentDefinitionsService } from '../services/content-definitions.service';

@Component({
  selector: 'lib-content-definitions',
  template: ` <p>content-definitions works!</p> `,
  styles: [],
})
export class ContentDefinitionsComponent implements OnInit {
  constructor(private service: ContentDefinitionsService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
