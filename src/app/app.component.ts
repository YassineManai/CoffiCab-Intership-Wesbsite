import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; // Import HttpClientModule
import { ProcessService } from './services/process.service';
import { Process } from './models/process';
import { EditProcessComponent } from './components/edit-process/edit-process.component'; // Import the EditProcessComponent
import { NavbarComponent } from './components/navbar/navbar.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { ProcessComponent } from './components/process/process.component';
@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, CommonModule, HttpClientModule,EditProcessComponent,NavbarComponent
    ,SidebarComponent,ProcessComponent
  ], // Include HttpClientModule here
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'CofiCab.UI';
  processes: Process[] = [];
  processToEdit: Process | null = null;

  constructor(private processService: ProcessService) {}

  ngOnInit(): void {
    this.processService
      .getProcesses()
      .subscribe((result: Process[]) => (this.processes = result));
  }

  updateProcessList(processes: Process[]): void {
   this.processes = processes;
  }







  
  initNewProcess(): void {
    this.processToEdit = new Process(); 
    console.log(this.processToEdit)
  }
  editProcess(process:Process){
    this.processToEdit = process;
  }


 



  
}