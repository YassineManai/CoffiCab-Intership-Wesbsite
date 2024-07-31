import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Product } from '../../../models/product';
import { ProductServiceService } from '../../../services/product-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Process } from '../../../models/process'; // Import Process model
import { ProcessService } from '../../../services/process.service';
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
  @Output() productUpdated = new EventEmitter<void>();
  processes: Process[] = []; // Add a processes array

  constructor
  (private productService: ProductServiceService,
   private processService: ProcessService
  )
   {}

  ngOnInit(): void { 
    this.fetchProcesses();
   }
   fetchProcesses(): void {
    this.processService.getProcesses().subscribe((result: Process[]) => (this.processes = result));
  }

  updateProduct(product: Product): void {
    console.log(product)
    this.productService.updateProduct(product)
      .subscribe(() => this.productUpdated.emit());
  }

  deleteProduct(itemCode: string): void {
    console.log(itemCode)
    this.productService.deleteProduct(itemCode)
      .subscribe(() => this.productUpdated.emit());
  }

  createProduct(product: Product): void {
  console.log(product)
    
      if (this.isValidProduct(product)) {
        this.productService.createProduct(product)
        .subscribe(() => this.productUpdated.emit());
      
      } else {
        alert('Please fill in all the required fields.');
      }
  }

  isValidProduct(product: Product): boolean {
    const requiredFields = [
     product.typeProduct,
     product.itemCode,
     product.itemDesc,
     product.parentItemCode,
     product.ParentIDProduct,
     product.codeItemModel,
     product.iTemGroup,
     product.warehouse,
     product.consumptionPerOneKM_outPut,
     product.famille,
     product.section,
     product.couleur,
     product.couleurP,
     product.couleurS,
     product.diametre,
     product.poids_Conducteur_Kg_Km,
     product.typeMatiere,
     product.codePAC_DVR,
     product.codePAC,
     product.codeRecette,
     product.codeItemNature,
     product.localItemCode,
     product.m_min_m_sec,
     product.codeItemModel_DVR,
     product.code_Recette_DVR,
     product.inforItem,
     product.warehouse,
     product.resistanceOptimal,
     product.poids_Insolation_Kg_Km,
     product.couleur_Marquage
    ];

    return requiredFields.every(field => field !== undefined && field !== null && field !== '');
  }



}
