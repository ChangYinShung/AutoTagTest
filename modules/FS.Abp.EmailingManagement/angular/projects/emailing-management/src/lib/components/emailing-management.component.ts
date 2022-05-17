import { Component, OnInit } from '@angular/core';
import { EmailingManagementService } from '../services/emailing-management.service';

@Component({
  selector: 'lib-emailing-management',
  template: ` <p>emailing-management works!</p> `,
  styles: [],
})
export class EmailingManagementComponent implements OnInit {
  constructor(private service: EmailingManagementService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
