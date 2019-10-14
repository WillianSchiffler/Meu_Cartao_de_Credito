using System;
using System.Collections.Generic;
using System.IO;

namespace cards{

class cliente{
  private string nome;
  private double limite;

  public cliente(string n, double rend){
    nome = n;
    limite = 1.5*rend;
  }

  public string getnome(){
    return nome;
  }
  public double getlimite(){
    return limite;
  }
}
}