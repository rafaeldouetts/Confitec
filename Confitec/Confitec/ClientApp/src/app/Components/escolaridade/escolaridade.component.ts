import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EscolariodadeEnum, EscolariodadeTextoEnum } from 'src/app/model/enum';

@Component({
  selector: 'app-escolaridade',
  templateUrl: './escolaridade.component.html',
  styleUrls: ['./escolaridade.component.css']
})
export class EscolaridadeComponent implements OnInit {

  EscolariodadeTextoEnum  = EscolariodadeTextoEnum;
  EscolariodadeEnum = EscolariodadeEnum;
  escolaridadeUsuarioForm: FormGroup;
  escolaridades = Object.values(this.EscolariodadeEnum).filter(value => typeof value != 'number');;

  @Output() escolaridadeEvet = new EventEmitter();
  @Input() escolaridadeValue: any;

  constructor(
    private _formBuilder: FormBuilder,
  ) {}

  ngOnInit() {
    this.escolaridadeUsuarioForm = this._formBuilder.group({
      escolaridade:[null, Validators.required]
    });

    if(this.escolaridadeValue != undefined)
      this.escolaridadeUsuarioForm.get('escolaridade').setValue(this.EscolariodadeEnum[this.escolaridadeValue]);
  };

  atualizarEscolaridade(event){
    this.escolaridadeEvet.emit(event);
  }
}
