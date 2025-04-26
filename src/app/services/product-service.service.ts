import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs'
import { Product } from '../models/product';
@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {
  private url = "https://localhost:7248/api/Product";
  constructor(private http: HttpClient) { }
  public getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(this.url);
  }

  public updateProduct(product: Product): Observable<void> {
    return this.http.put<void>(`${this.url}/${product.itemCode}`, product);
  }

  public deleteProduct(itemCode: string): Observable<void> {
    return this.http.delete<void>(`${this.url}/${itemCode}`);
  }

  public createProduct(product: Product): Observable<Product> {  
    return this.http.post<Product>(this.url, product);
  }
  getProductsByProcessCode(codeProcess: string): Observable<Product[]> {
    return this.http.get<Product[]>(`${this.url}/products?codeProcess=${codeProcess}`);
  }
}
