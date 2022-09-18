import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { EscolariodadeEnum, EscolariodadeTextoEnum } from 'src/app/model/enum';
import { Usuario } from 'src/app/model/usuario';
import { UsuarioService } from 'src/app/usuario-service.service';

@Component({
  selector: 'app-modal-adicionar',
  templateUrl: './modal-adicionar.component.html',
  styleUrls: ['./modal-adicionar.component.css']
})
export class ModalAdicionarComponent implements OnInit{

  adicionarUsuarioForm: FormGroup;
  escolaridade = null;
  usuario:Usuario = new Usuario(); 
  EscolariodadeTextoEnum = EscolariodadeTextoEnum;
  EscolariodadeEnum = EscolariodadeEnum;

  constructor(
    private _dialogref: MatDialogRef<ModalAdicionarComponent>,
    private _formBuilder: FormBuilder,
    private _usuarioService: UsuarioService,
    @Inject(MAT_DIALOG_DATA) public data: any) { }

  ngOnInit() {
    this.adicionarUsuarioForm = this._formBuilder.group({
      nome:[null, Validators.required],
      sobrenome: [null, Validators.required],
      email:[null, [Validators.required, Validators.email]],
      dataNascimento:[null, Validators.required]
    });
  }

  adicionar(){
    if(this.adicionarUsuarioForm.valid && this.escolaridade != undefined)
    {
      this.usuario = this.adicionarUsuarioForm.value;
      this.usuario.escolaridade = this.escolaridade;

      this._usuarioService.postUsuario(this.usuario)
      .subscribe(data => {
        this._dialogref.close(true)
      },
      err => {
        //notificar erro ao tentar cadastrar usuario. 
      })
    }
  }

  escolaridadeEvet(event:any){
    this.escolaridade =  this.EscolariodadeEnum[event.value];
  }
}

