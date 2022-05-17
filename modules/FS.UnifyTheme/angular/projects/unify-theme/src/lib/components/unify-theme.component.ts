import { Component, OnInit } from '@angular/core';
import { UnifyThemeService } from '../services/unify-theme.service';

@Component({
  selector: 'lib-unify-theme',
  template: ` <p>unify-theme works!</p> `,
  styles: [],
})
export class UnifyThemeComponent implements OnInit {
  constructor(private service: UnifyThemeService) {}

  ngOnInit(): void {
    this.service.sample().subscribe(console.log);
  }
}
