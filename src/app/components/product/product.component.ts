import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EditProductComponent } from './edit-product/edit-product.component';
import { Product } from '../../models/product';
import { ProductServiceService } from '../../services/product-service.service';
@Component({
  selector: 'app-product',
  standalone: true,
  imports: [CommonModule, EditProductComponent],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit{
 products: Product[] = [];
 productToEdit: Product | null = null;

  
  constructor(private productService: ProductServiceService) {}
  ngOnInit(): void {
    this.fetchProcesses();
  }

  fetchProcesses(): void {
    this.productService.getProducts().subscribe((result: Product[]) => (this.products = result));
  }

  updateProductList(products: Product[]): void {
    this.products = products;
   }
 
   
   initNewProduct(): void {
     this.productToEdit = new Product(); 
     console.log(this.productToEdit)
   }
   editProduct(product:Product){
     this.productToEdit = product;
   }
   handleProcessUpdated(): void {
    this.fetchProcesses();
    this.productToEdit = null;
   }
}
