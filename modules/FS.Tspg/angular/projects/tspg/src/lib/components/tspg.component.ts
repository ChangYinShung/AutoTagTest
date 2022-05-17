import { Component, OnInit } from '@angular/core';
import { TspgService } from '../services/tspg.service';

@Component({
  selector: 'lib-tspg',
  template: ` <p>tspg works!</p> `,
  styles: [],
})
export class TspgComponent implements OnInit {
  constructor(private service: TspgService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
