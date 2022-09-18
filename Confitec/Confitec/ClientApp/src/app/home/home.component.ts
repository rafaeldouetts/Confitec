import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { EscolariodadeEnum, EscolariodadeTextoEnum } from '../model/enum';
import { Usuario } from '../model/usuario';
import { UsuarioService } from '../usuario-service.service';
import { ModalAdicionarComponent } from './modal-adicionar/modal-adicionar.component';
import { ModalAtualizarComponent } from './modal-atualizar/modal-atualizar.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls : ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  displayedColumns: string[] = ['Nome', 'Sobrenome', 'Email', 'DataNascimento', 'Escolaridade', 'Acoes'];
  date = new Date();
  
  EscolaridadeEnum = EscolariodadeEnum;
  EscolariodadeTextoEnum = EscolariodadeTextoEnum;

  dataSource: Usuario[];

  constructor(private _matDialog: MatDialog,
    private _usuarioServiceService: UsuarioService){}
    

  ngOnInit(): void {
    this.carregarUsuarios();
  }

  carregarUsuarios(){
    this._usuarioServiceService.getUsuarios()
    .subscribe((data : Usuario[]) => {
      this.dataSource = data;
    },
    err => {
      //notificar erro ao carregar os usuarios 
    })
  }

  removerUsuario(usuario:Usuario){
    this._usuarioServiceService.deleteUsuario(usuario.id)
    .subscribe((data : number) => {
      this.carregarUsuarios();
    },
    err => {
      //notificar erro ao remover um usuario. 
    })
  }

  Adicionar()
  {
   this._matDialog.open(ModalAdicionarComponent, {
      width: '50%',
      maxHeight: '50%'
    }).afterClosed()
    .subscribe(data => {
      if(data)
        this.carregarUsuarios();
    });
  }

  Editar(usuario:Usuario){
    const dialogRef = this._matDialog.open(ModalAtualizarComponent, {
      width: '50%',
      maxHeight: '50%',
      data:{
        usuario: usuario
      }
    }).afterClosed()
    .subscribe(data => {
      if(data)
        this.carregarUsuarios();
    });;
  }
}
