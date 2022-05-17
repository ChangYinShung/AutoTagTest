import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class EmailingManagementService {
  apiName = 'EmailingManagement';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/EmailingManagement/sample' },
      { apiName: this.apiName }
    );
  }
}
