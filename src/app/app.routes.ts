import { Routes } from '@angular/router';
import { MachineComponent } from './components/machine/machine.component';
import { ProcessComponent } from './components/process/process.component';
import { ProfilUsersComponent } from './components/profil-users/profil-users.component';
import { ProgProfilesComponent } from './components/prog-profiles/prog-profiles.component';
import { ProductComponent } from './components/product/product.component';
import { CaracterStartofshiftvaluesComponent } from './components/caracter-startofshiftvalues/caracter-startofshiftvalues.component';

export const routes: Routes = [
    {path: 'Machine',component: MachineComponent },
    {path: 'Process',component: ProcessComponent},
    {path: 'ProfilUsers',component: ProfilUsersComponent},
    {path: 'ProgProfiles',component: ProgProfilesComponent},
    {path: 'Product',component: ProductComponent},
    {path: 'CaractersStartofShiftValues',component: CaracterStartofshiftvaluesComponent},





];
