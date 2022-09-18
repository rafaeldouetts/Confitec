import { EscolariodadeEnum } from "./enum";

export class Usuario {
    id:number;
    nome: string;
    sobrenome: string;
    email: string;
    dataNascimento: Date;
    escolaridade :EscolariodadeEnum;
  }