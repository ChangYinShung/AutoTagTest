import { Injectable } from '@angular/core';
import { RestService } from '@abp/ng.core';

@Injectable({
  providedIn: 'root',
})
export class PaymentServiceService {
  apiName = 'PaymentService';

  constructor(private restService: RestService) {}

  sample() {
    return this.restService.request<void, any>(
      { method: 'GET', url: '/api/PaymentService/sample' },
      { apiName: this.apiName }
    );
  }
}
