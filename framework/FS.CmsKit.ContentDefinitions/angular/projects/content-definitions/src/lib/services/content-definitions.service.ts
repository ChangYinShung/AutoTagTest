import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class ContentDefinitionsService {
  apiName = 'ContentDefinitions';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/ContentDefinitions/sample' },
      { apiName: this.apiName }
    );
  }
}
