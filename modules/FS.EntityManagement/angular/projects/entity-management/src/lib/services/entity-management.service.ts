import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class EntityManagementService {
  apiName = 'EntityManagement';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/EntityManagement/sample' },
      { apiName: this.apiName }
    );
  }
}
