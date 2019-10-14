using System;
using System.Collections.Generic;
using System.IO;

namespace cards{

class MainClass {
  public static void Main () {
    double valor_da_compra = 0;
    string senha_digitada;
    bool fatura_aberta = true;
    bool compra_permitida = true;
    double renda;
    string nome;
    
    Console.WriteLine("Qual seu nome?");
    nome = Console.ReadLine();
    Console.WriteLine("Qual sua renda?");
    renda = int.Parse(Console.ReadLine());

    cliente novo_cliente = new cliente (nome, renda);
    Cartao meuCard = new Cartao(novo_cliente);
    Maquina minha_maq = new Maquina("shopping");
    
  while(compra_permitida == true){
    do{
      if(fatura_aberta == true){
      Console.WriteLine("Qual o valor da próxima compra?");
      valor_da_compra = int.Parse(Console.ReadLine());
      Console.WriteLine("Qual a senha?");
      senha_digitada = Console.ReadLine();
      fatura_aberta = minha_maq.inserirCartao(valor_da_compra, senha_digitada, meuCard);
      }
    } while(fatura_aberta == true);
      
    Console.WriteLine("Deseja ver a fatura? s ou n");
    if(char.Parse(Console.ReadLine()) == 's'){
      meuCard.ver_fatura();
    }

    do{
    Console.WriteLine("Qual o valor deseja pagar?");
    compra_permitida = meuCard.pagar_fatura(double.Parse(Console.ReadLine()));
    } while(compra_permitida == false);

    Console.WriteLine("Deseja ver o histórico? s ou n");
    if(char.Parse(Console.ReadLine()) == 's'){
      meuCard.ver_hist();
    }

    fatura_aberta = true;
  }
}
}
}