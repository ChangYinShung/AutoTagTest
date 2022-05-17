import { Component, OnInit } from '@angular/core';
import { ContentCompositesService } from '../services/content-composites.service';

@Component({
  selector: 'lib-content-composites',
  template: ` <p>content-composites works!</p> `,
  styles: [],
})
export class ContentCompositesComponent implements OnInit {
  constructor(private service: ContentCompositesService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
