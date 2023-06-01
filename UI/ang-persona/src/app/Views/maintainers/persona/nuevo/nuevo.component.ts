import { Component, OnInit } from '@angular/core';
import { BsModalService, ModalOptions } from 'ngx-bootstrap/modal';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { PersonaVM, Personas } from 'src/app/Models/Persona';
import { PersonaService } from 'src/app/Services/persona.service';

@Component({
  selector: 'app-nuevo',
  templateUrl: './nuevo.component.html',
  styleUrls: ['./nuevo.component.css']
})
export class NuevoComponent implements OnInit {

  data:any;
  title = '';
  formPersona: FormGroup;
  constructor(private fb: FormBuilder, options: ModalOptions, private modalService: BsModalService, private personaService: PersonaService) {
    this.formPersona = fb.group({
      nombre: ["", Validators.required],
      apellido: ["", Validators.required],
      edad: ["", Validators.required]
    });
    this.data = options.initialState;
  }

  ngOnInit(): void {
    let formobj = { id: '', nombre:'', apellido:'', edad: '' };
    if(this.data.accion == 2) {
      formobj.id = this.data.usuario.id;
      formobj.nombre = this.data.usuario.nombre;
      formobj.apellido = this.data.usuario.apellido;
      formobj.edad = this.data.usuario.edad;
    }
    this.formPersona = this.fb.group(formobj);
  }

  guardar(){  
    if(this.formPersona.valid){
      switch (this.data.accion) {
        case 1:
          this.crear(Object.assign(this.formPersona.value));
          break;
        case 2:
          this.editar(Object.assign(this.formPersona.value));
          break;
      }
    }
    else{
      alert("Debe completar todos los campos requeridos");
    }
  }

  crear(model:PersonaVM) {
    this.personaService.post(model).subscribe(res => {
      this.formPersona.reset();
      //alert('Se registro correctamente');
      this.doHide();
    });
  }

  editar(model:Personas) {
    this.personaService.put(model).subscribe(res => {
      this.formPersona.reset();
      //alert('Se modifico correctamente');
      this.doHide();
    });
  }

  doHide() {
    this.modalService.hide();
  }
}
