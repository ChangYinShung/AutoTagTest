import { Component, OnInit } from '@angular/core';
import { EShopManagementService } from '../services/e-shop-management.service';

@Component({
  selector: 'lib-e-shop-management',
  template: ` <p>e-shop-management works!</p> `,
  styles: [],
})
export class EShopManagementComponent implements OnInit {
  constructor(private service: EShopManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
