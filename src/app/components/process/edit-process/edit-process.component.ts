import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Process } from '../../../models/process';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProcessService } from '../../../services/process.service';

@Component({
  selector: 'app-edit-process',
  standalone: true,
  imports: [
    FormsModule,
    CommonModule
  ],
  templateUrl: './edit-process.component.html',
  styleUrls: ['./edit-process.component.css']
})
export class EditProcessComponent implements OnInit {
  @Input() process: Process | null = null;
  @Output() processUpdated = new EventEmitter<void>();

  constructor(private processService: ProcessService) {}

  ngOnInit(): void {}

  updateProcess(process: Process): void {
    this.processService.updateProcess(process)
      .subscribe(() => this.processUpdated.emit());
  }

  deleteProcess(processId: number): void {
    this.processService.deleteProcess(processId)
      .subscribe(() => this.processUpdated.emit());
  }

  createProcess(process: Process): void {
    if (this.isValidProcess(process)) {
      this.processService.createProcess(process)
        .subscribe(() => this.processUpdated.emit());
    } else {
      alert('Please fill in all the required fields.');
    }
  }

  isValidProcess(process: Process): boolean {
    const requiredFields = [
      process.codeProcess,
      process.descProcess,
      process.codeProcessToRework,
      process.returnValidationProfil,
      process.stockName,
      process.plC_Assigned,
      process.img_Process,
      process.long_Machine_Stop_min,
      process.model_Label
    ];

    return requiredFields.every(field => field !== undefined && field !== null && field !== '');
  }
}
