import { Component, OnInit } from '@angular/core';
import { EcPayService } from '../services/ec-pay.service';

@Component({
  selector: 'lib-ec-pay',
  template: ` <p>ec-pay works!</p> `,
  styles: [],
})
export class EcPayComponent implements OnInit {
  constructor(private service: EcPayService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
