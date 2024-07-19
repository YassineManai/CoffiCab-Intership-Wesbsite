import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Product } from '../../../models/product';
import { ProductServiceService } from '../../../services/product-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-edit-product',
  standalone: true,
  imports: [FormsModule,
    CommonModule],
  templateUrl: './edit-product.component.html',
  styleUrl: './edit-product.component.css'
})
export class EditProductComponent implements OnInit {
  @Input() product: Product | null = null;
  @Output() productUpdated = new EventEmitter<Product[]>();

  constructor(private productService: ProductServiceService) {}

  ngOnInit(): void {
    this.fetchProducts();
  }

  fetchProducts(): void {
    this.productService.getProducts()
      .subscribe((products: Product[]) => this.productUpdated.emit(products));
  }

  updateProduct(product: Product): void {
    this.productService.updateProduct(product)
      .subscribe(() => this.fetchProducts());
  }

  deleteProduct(id: number): void {
    this.productService.deleteProduct(id)
      .subscribe(() => this.fetchProducts());
  }

  createProduct(product: Product): void {
    console.log(product)
    this.productService.createProduct(product)
      .subscribe(() => this.fetchProducts());
  }

}
