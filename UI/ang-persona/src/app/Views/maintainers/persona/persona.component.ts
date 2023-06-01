import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { PersonaVM, Personas } from 'src/app/Models/Persona';
import { NuevoComponent } from './nuevo/nuevo.component';
import { PersonaService } from 'src/app/Services/persona.service';

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.css']
})
export class PersonaComponent implements OnInit {

  formFilter: FormGroup;
  personas:Personas[] = [];
  modal!: BsModalRef;

  constructor(fb: FormBuilder, private modalService: BsModalService, private personaService: PersonaService) {
    this.formFilter = fb.group({
      buscar: [""]
    });
  }

  ngOnInit(): void {
    
  }

  nuevo(){
    const initialState = { accion: 1, title:'Crear', usuario: new PersonaVM()};
    const modalConfig = { animated: true, keyboard: true, backdrop: true, ignoreBackdropClick: false };    
    this.modal = this.modalService.show(NuevoComponent, Object.assign({}, modalConfig, { class: 'modal-xl', backdrop: 'static', initialState }));
    this.modal.onHidden?.subscribe(()=>{this.buscar();});
  }

  editar(persona:Personas){
    const initialState = { accion: 2, title:'Modificar', usuario: persona};
    const modalConfig = { animated: true, keyboard: true, backdrop: true, ignoreBackdropClick: false };    
    this.modal = this.modalService.show(NuevoComponent, Object.assign({}, modalConfig, { class: 'modal-xl', backdrop: 'static', initialState }));
    this.modal.onHidden?.subscribe(()=>{this.buscar();});
  }

  eliminar(persona:Personas) {
    this.personaService.delete(persona.id).subscribe(
      res => {
        //alert('Se elimino correctamente');
        this.buscar();
      }, 
      error=> {
        console.log(error);
        alert('Algo salio mal');
      }
    )
  }

  buscar() {
    let filter = this.formFilter.value.buscar = '' ? null : this.formFilter.value.buscar;
    this.personaService.get(filter).subscribe( 
      res => {
        this.personas = res;
      }, 
      error=> {
        console.log(error);
        alert('Algo salio mal');
      }
    )
  }

  limpiar() {
    this.formFilter.reset();
    this.personas = [];
  }


}
