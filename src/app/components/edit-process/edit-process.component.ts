import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Process } from '../../models/process';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ProcessService } from '../../services/process.service';

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
  @Output() processUpdated = new EventEmitter<Process[]>();

  constructor(private processService: ProcessService) {}

  ngOnInit(): void {
    this.fetchProcesses();
  }

  fetchProcesses(): void {
    this.processService.getProcesses()
      .subscribe((processes: Process[]) => this.processUpdated.emit(processes));
  }

  updateProcess(process: Process): void {
    this.processService.updateProcess(process)
      .subscribe(() => this.fetchProcesses());
  }

  deleteProcess(processId: number): void {
    this.processService.deleteProcess(processId)
      .subscribe(() => this.fetchProcesses());
  }

  createProcess(process: Process): void {
    console.log(process)
    this.processService.createProcess(process)
      .subscribe(() => this.fetchProcesses());
  }
}
