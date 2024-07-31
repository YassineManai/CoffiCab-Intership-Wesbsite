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
  processes: Process[] = [];
  constructor(private processService: ProcessService) {}

  ngOnInit(): void {
    this.fetchProcesses();
  }
  fetchProcesses(): void {
    this.processService.getProcesses().subscribe((result: Process[]) => {
      this.processes = result;
    });
  }
  updateProcess(process: Process): void {
    this.processService.updateProcess(process)
      .subscribe(() => this.processUpdated.emit());
  }

  deleteProcess(codeprocess: string): void {
    this.processService.deleteProcess(codeprocess)
      .subscribe(() => this.processUpdated.emit());
  }

  createProcess(process: Process): void {
    if (this.isDuplicateProcess(process)) {
      alert('A process with the same CodeProcess already exists.');
    } else if (this.isValidProcess(process)) {
      this.processService.createProcess(process).subscribe(() => this.processUpdated.emit());
    } else {
      alert('Please fill in all the required fields.');
    }
  }

  isDuplicateProcess(process: Process): boolean {
    const newCodeProcess = process.codeProcess?.toUpperCase();
    return this.processes.some(existingProcess => existingProcess.codeProcess?.toUpperCase() === newCodeProcess);
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
