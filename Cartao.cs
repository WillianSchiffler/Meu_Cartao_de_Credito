using System;
using System.Collections.Generic;
using System.IO;

namespace cards{

class Cartao {
  private double limite_card;
  private double total_fatura;
  private List<double> compras;
  private List<string> locais;

  public Cartao (cliente c) {
    limite_card = c.getlimite();
    total_fatura = 0;
    compras = new List<double>();
    locais = new List<string>();
  }

  public bool comprar (double valor, string local, string senha){
    bool compra_permitida = true;
    if(((total_fatura+valor) > limite_card) || (val_senha(senha) == false)){
      Console.WriteLine("Compra bloqueada!");
      Console.WriteLine("Fatura está em: {0}", valor_fatura());
    }
    else{
      total_fatura = total_fatura + valor;
      Console.WriteLine("Compra Aprovada!");
      compras.Add(valor);
      locais.Add(local);
      Console.WriteLine("Fatura está em: {0}", valor_fatura());

    if((total_fatura) == limite_card){
      compra_permitida = false;
      Console.WriteLine("Fatura fechada!");
    }
    }
    return compra_permitida;
  }
  
  public double valor_fatura(){
    double total_fatura = 0;
    foreach(double v in compras){
      total_fatura = total_fatura + v;
    }
    return total_fatura;
  }

  public bool pagar_fatura(double v){
    StreamWriter hist = File.AppendText("Histórico.txt");
    for(int i=0; i<compras.Count; i++)
    {
      hist.WriteLine("{0} : {1}", locais[i], compras[i]);
    }
    hist.Close();
    
    total_fatura = (total_fatura - v);
    if(total_fatura > 0){
      Console.WriteLine("Você ainda deve! Pague primeiro antes de comprar...");
      return false;
    }
    else{
      compras.Clear();
      locais.Clear();
      Console.WriteLine("Fatura paga!");
      return true;
    }
  }
  
  public void ver_fatura(){
    Console.WriteLine("A fatura tem {0} compras", compras.Count);
    int índice = 1;
    foreach (int i in compras){
      Console.WriteLine("Compra: {0}  Valor: {1}", índice, i);
      índice++;
    }
  }

  public void ver_hist(){
    StreamReader historico = File.OpenText("Histórico.txt");
    string linha = "";
    while ((linha = historico.ReadLine()) != null) {
      Console.WriteLine(linha);
    }
    historico.Close();
  }

  public bool val_senha(string senha){
  StreamReader arquivo = File.OpenText("senha.txt");
  if(senha == (arquivo.ReadLine())){
    arquivo.Close();
    return true;
    }
    else{
      arquivo.Close();
      return false;
    }
  }
}
}