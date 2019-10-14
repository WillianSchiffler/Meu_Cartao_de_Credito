using System;
using System.Collections.Generic;
using System.IO;

namespace cards{

class Maquina {

private string estabelecimento;

public Maquina (string e){
  estabelecimento = e;
}

public bool inserirCartao(double v, string senha, Cartao c){
   if (c.comprar(v, estabelecimento, senha)==true){
      return true;
   }
   else{
     return false;
   }
}

public static double juros(){
  return 0.01;
}
}
}