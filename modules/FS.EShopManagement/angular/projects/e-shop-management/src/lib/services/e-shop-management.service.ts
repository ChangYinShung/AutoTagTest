import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class EShopManagementService {
  apiName = 'EShopManagement';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/EShopManagement/sample' },
      { apiName: this.apiName }
    );
  }
}
