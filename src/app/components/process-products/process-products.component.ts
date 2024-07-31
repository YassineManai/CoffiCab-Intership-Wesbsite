import { Component,OnInit } from '@angular/core';
import { Product } from '../../models/product';
import { ProductServiceService } from '../../services/product-service.service';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-process-products',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './process-products.component.html',
  styleUrl: './process-products.component.css'
})
export class ProcessProductsComponent {
  products: Product[] = [];
  codeProcess: string | null = null;

  constructor(private route: ActivatedRoute, private productService: ProductServiceService) {}

  ngOnInit(): void {
    this.codeProcess = this.route.snapshot.paramMap.get('codeProcess');
    if (this.codeProcess) {
      this.fetchProducts();
    }
  }

  fetchProducts(): void {
    this.productService.getProductsByProcessCode(this.codeProcess!).subscribe((result: Product[]) => {
      this.products = result;
    });
  }

}
