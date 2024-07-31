
import { Component, OnInit } from '@angular/core';
import { Process } from '../../models/process';
import { ProcessService } from '../../services/process.service';
import { CommonModule } from '@angular/common';
import { EditProcessComponent } from './edit-process/edit-process.component';
import { Router } from '@angular/router'; // Import Router

@Component({
  selector: 'app-process',
  standalone: true,
  imports: [CommonModule, EditProcessComponent],
  templateUrl: './process.component.html',
  styleUrl: './process.component.css'
})
export class ProcessComponent implements OnInit {
  processes: Process[] = [];
  processToEdit: Process | null = null;


  constructor(private processService: ProcessService,private router: Router) { }
  ngOnInit(): void {
    this.fetchProcesses();
  }

  fetchProcesses(): void {
    this.processService.getProcesses().subscribe((result: Process[]) => (this.processes = result));
  }

  updateProcessList(processes: Process[]): void {
    this.processes = processes;
  }


  initNewProcess(): void {
    this.processToEdit = new Process();
    console.log(this.processToEdit)
  }
  editProcess(process: Process) {
    this.processToEdit = process;
  }
  handleProcessUpdated(): void {
    this.fetchProcesses();
    this.processToEdit = null; // Hide the edit component after create/update/delete
  }
  navigateToProcessProducts(codeProcess: string): void {
    this.router.navigate(['/process-product', codeProcess]);
  }


}
