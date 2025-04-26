import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { Product } from '../../../models/product';
import { ProductServiceService } from '../../../services/product-service.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Process } from '../../../models/process'; // Import Process model
import { ProcessService } from '../../../services/process.service';
import { Machine } from '../../../models/machine';
import { MachineService } from '../../../services/machine.service';

@Component({
  selector: 'app-edit-machine',
  standalone: true,
  imports: [FormsModule , CommonModule],
  templateUrl: './edit-machine.component.html',
  styleUrl: './edit-machine.component.css'
})
export class EditMachineComponent implements OnInit {
  @Input() machine: Machine | null = null;
  @Output() machineupdated = new EventEmitter<void>();
  processes: Process[] = []; // Add a processes array
  machines:Machine[]=[];

  constructor
  (private machineservice: MachineService,
   private processService: ProcessService
  ){}


  ngOnInit(): void { 
    this.fetchProcesses();
   }
   fetchProcesses(): void {
    this.processService.getProcesses().subscribe((result: Process[]) => (this.processes = result));
    this.machineservice.getMachine().subscribe((result: Machine[]) => (this.machines = result));
  }

  updateMachine(machine: Machine): void {
    console.log(machine)
    this.machineservice.updateMachine(machine)
      .subscribe(() => this.machineupdated.emit());
  }

  deleteMachine(itemCode: string): void {
    console.log(itemCode)
    this.machineservice.deleteMachine(itemCode)
      .subscribe(() => this.machineupdated.emit());
  }
  createMachine(machine: Machine): void {
      console.log(machine)
      if (this.isDuplicateMachine(machine)) {
        alert('A Machine with the same MachineCode already exists.');
      }
       else if (this.isValidMachine(machine)) {
          this.machineservice.createMachine(machine)
          .subscribe(() => this.machineupdated.emit());
        
        } else {
          alert('Please fill in all the required fields.');
        }
    }

    isDuplicateMachine(machine: Machine): boolean {
      const newCodeMachine = machine.machine_Code?.toUpperCase();
      return this.machines.some(existingMachine => existingMachine.machine_Code?.toUpperCase() === newCodeMachine);
    }

    isValidMachine(machine: Machine): boolean {
      const requiredFields = [
        machine.machine_Code,
        machine.description,
        machine.noK_Location,
        machine.noK_Warehouse,
        machine.oK_Location,
        machine.oK_Warehouse,
        machine.nameMachine,
        machine.codeProcess,
        machine.bulding,
        machine.code_Machine_OPC,
        machine.code_Machine_Serial_Number,
        machine.actualUser,
        machine.codeZone,
        machine.type,
        machine.aff_Input_Interface_Prod,
        machine.onlyWithPO,
        machine.actualUser_Qualite,
        machine.repertoireReport,
        machine.repertoireReportArchive,
        machine.repertoireReportRejete,
        machine.plan_Affichage_Interface_Prod,
        machine.startingTimeCalculeStop,
        machine.format_Date_Report,
        machine.readingReport,
        machine.type_Fic,
        machine.grp_Objectif,
        machine.code_Process2,
        machine.unite,
        machine.imprimanteCmes,
        machine.imprimantePanel,
        machine.time_waiting_before_validation_next_report,
        machine.workCenter,
        machine.inc_Warehouse,
        machine.inc_Location,
        machine.setup_Warehouse,
        machine.setup_Location,
        machine.inspection_Warehouse,
        machine.inspection_Location, 
      ];
  
      return requiredFields.every(field => field !== undefined && field !== null && field !== '');
    }


}
