import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class UnifyThemeService {
  apiName = 'UnifyTheme';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/UnifyTheme/sample' },
      { apiName: this.apiName }
    );
  }
}
