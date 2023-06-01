import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VistaComponent } from './vista.component';
import { PersonaComponent } from './maintainers/persona/persona.component';

const routes: Routes = [{
  path: '',
  component: VistaComponent,
  children: [
    { path: 'personas', component: PersonaComponent },
    { path: '', redirectTo: 'personas', pathMatch: 'prefix' }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VistaRoutingModule { }
