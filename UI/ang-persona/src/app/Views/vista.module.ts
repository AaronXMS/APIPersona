import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { VistaRoutingModule } from './vista-routing.module';
import { VistaComponent } from './vista.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PersonaComponent } from './maintainers/persona/persona.component';
import { NuevoComponent } from './maintainers/persona/nuevo/nuevo.component';
import { BsModalService, ModalModule } from 'ngx-bootstrap/modal';

@NgModule({
  declarations: [
    VistaComponent,
    PersonaComponent,
    NuevoComponent
  ],
  imports: [
    CommonModule,
    VistaRoutingModule,
    FormsModule, 
    ReactiveFormsModule,
    ModalModule.forRoot()
  ],
  providers: [BsModalService]
})
export class VistaModule { }
