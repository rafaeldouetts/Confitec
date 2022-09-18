import { Component, Inject, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { EscolariodadeEnum } from 'src/app/model/enum';
import { Usuario } from 'src/app/model/usuario';
import { UsuarioService } from 'src/app/usuario-service.service';

@Component({
  selector: 'app-modal-atualizar',
  templateUrl: './modal-atualizar.component.html',
  styleUrls: ['./modal-atualizar.component.css']
})
export class ModalAtualizarComponent implements OnInit {

  EscolariodadeEnum = EscolariodadeEnum;
  escolaridade;
  usuario:Usuario;
  atualizarUsuarioForm: FormGroup;

  constructor(
    private _dialogref: MatDialogRef<ModalAtualizarComponent>,
    private _formBuilder: FormBuilder,
    private _usuarioService: UsuarioService,
    @Inject(MAT_DIALOG_DATA) public data: any) { 
      if(data && data.usuario)
      {
        this.usuario = data.usuario;

        this.atualizarUsuarioForm = this._formBuilder.group({
          nome:[null, Validators.required],
          sobrenome: [null, Validators.required],
          email:[null, [Validators.required, Validators.email]],
          dataNascimento:[null, Validators.required],
          id:[null]
        })
      }
    }


  ngOnInit() {
    if(this.usuario)
    {
      this.atualizarUsuarioForm.patchValue(this.usuario);
      this.escolaridade = this.usuario.escolaridade;

    }
  }

  atualizar(){
    this.usuario = this.atualizarUsuarioForm.value;
    this.usuario.escolaridade = this.escolaridade;

    this._usuarioService.putUsuario(this.usuario)
    .subscribe(data => {
      this._dialogref.close(true);
    },
    err => {
      //notificar erro ao atualizar usuario.
    })
  }

  EscolaridadeEvet(event){
    this.escolaridade = this.EscolariodadeEnum[event.value];
  }
}