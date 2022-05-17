import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class ContentCompositesService {
  apiName = 'ContentComposites';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/ContentComposites/sample' },
      { apiName: this.apiName }
    );
  }
}
