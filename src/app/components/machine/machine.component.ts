import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';
import { EditMachineComponent } from './edit-machine/edit-machine.component';
import { Machine } from '../../models/machine';
import { MachineService } from '../../services/machine.service';



@Component({
  selector: 'app-machine',
  standalone: true,
  imports: [CommonModule , EditMachineComponent],
  templateUrl: './machine.component.html',
  styleUrl: './machine.component.css'
})
export class MachineComponent implements OnInit {
  machines: Machine[] = [];
  machineToEdit: Machine | null = null;


  constructor(private machineservice : MachineService) { }
  ngOnInit(): void {
    this.fetchMachine();
  }

  fetchMachine(): void {
    this.machineservice.getMachine().subscribe((result: Machine[]) => (this.machines = result));
  }

  updateMachines(machines: Machine[]): void {
    this.machines = machines;
  }


  initNewMachine(): void {
    this.machineToEdit = new Machine();
    console.log(this.machineToEdit)
  }
  editMachine(machine: Machine) {
    this.machineToEdit = machine;
  }
  handleMachineUpdated(): void {
    this.fetchMachine();
    this.machineToEdit = null; // Hide the edit component after create/update/delete
  }





}
