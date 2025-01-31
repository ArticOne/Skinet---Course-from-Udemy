import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { IPagination } from '../shared/models/pagination';
import { IBrand } from '../shared/models/brand';
import { IType } from '../shared/models/productType';
import { map } from 'rxjs/operators';
import { ShopParams } from '../shared/models/shopParams';
import { IProduct } from '../shared/models/product';

@Injectable({
  providedIn: 'root',
})
export class ShopService {
  baseUrl = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) {}

  // tslint:disable-next-line: typedef
  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if (shopParams.brandId !== 0) {
      params = params.append('BrandId', shopParams.brandId.toString());
    }
    if (shopParams.typeId !== 0) {
      params = params.append('TypeId', shopParams.typeId.toString());
    }
    params = params.append('sort', shopParams.sort);

    params = params.append('pageIndex', shopParams.pageNumber.toString());
    params = params.append('pageSize', shopParams.pageSize.toString());

    if (shopParams.search) {
      params = params.append('search', shopParams.search);
    }

    return this.http
      .get<IPagination>(this.baseUrl + 'products', {
        observe: 'response',
        params,
      })
      .pipe(
        map((response) => {
          return response.body;
        })
      );
  }

  getProduct(id: number) {
    return this.http.get<IProduct>(this.baseUrl + 'products/' + id);
  }

  // tslint:disable-next-line: typedef
  getBrands() {
    return this.http.get<IBrand[]>(this.baseUrl + 'products/brands');
  }
  // tslint:disable-next-line: typedef
  getTypes() {
    return this.http.get<IType[]>(this.baseUrl + 'products/types');
  }
}
