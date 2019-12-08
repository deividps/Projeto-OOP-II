using System;
using System.IO;
using System.Text;

namespace Contratar{
  class MainClass {
    public static void Main (string[] args) {
      string cpf;
      string opcaoPerfil;
      string opcaoUsuario;
      string opcaoCpf;
      string empreendedorString;
      bool finded = false;
      StreamReader Autenticador;

      Empreendedor empreendedor = new Empreendedor();
      Comprador comprador = new Comprador();
      EmpreendedorComprador empreendedorComprador = new EmpreendedorComprador();


      Console.WriteLine("Bem vindo ao InvestCity!");
      Console.WriteLine("Encontre ou Divulgue sua Startup!");
      Console.WriteLine("Qual o seu Perfil? ");
      Console.WriteLine("Digite: \n 1 - Empreendedor \n 2 - Investidor \n 0 - Sair");
      opcaoPerfil = Console.ReadLine();
      while(opcaoPerfil != "0" && opcaoPerfil != "1" && opcaoPerfil != "2"){
        Console.WriteLine("Digite: \n 1 - Empreendedor \n 2 - Investidor \n 0 - Sair");
        opcaoPerfil = Console.ReadLine();
      }      

      if(opcaoPerfil == "1"){
        Console.WriteLine("Possui cadastro conosco? ");
        Console.WriteLine("Digite: \n 1 - SIM \n 2 - NÃO");
        opcaoUsuario = Console.ReadLine();
        while(opcaoUsuario != "1" && opcaoUsuario != "2"){
          Console.WriteLine("Digite: \n 1 - SIM \n 2 - NÃO");
          opcaoUsuario = Console.ReadLine();
        }
        if(opcaoUsuario == "1"){
          Autenticador = File.OpenText("./BD/empreendedor.txt");
          Console.WriteLine("Digite seu CPF (Sem pontos): ");
          opcaoCpf = Console.ReadLine();
          while(!empreendedor.ValidaCPF(opcaoCpf)){
            Console.WriteLine("CPF inválido! Digite novamente: ");
            opcaoCpf = Console.ReadLine();
          }
          
          while(Autenticador.EndOfStream != true){
            string linha = Autenticador.ReadLine();
            if(linha.Contains(opcaoCpf)){
              finded = true;
              Console.WriteLine("Usuário encontrado!");
              
              Console.WriteLine("Seus Servicos:");
              empreendedorComprador.listar(opcaoCpf);                
            }
          }
          Autenticador.Close();
          if(!finded){
            Console.WriteLine("Usuário não encontrado!");
          }
          
        }else{
          Console.WriteLine("Nome do Empreendedor: ");
          empreendedor.setNome(Console.ReadLine());
          Console.WriteLine("Cpf do Empreendedor: ");          
          cpf = Console.ReadLine();
          while(!empreendedor.ValidaCPF(cpf)){
            Console.WriteLine("Cpf inválido, digite novamente: ");          
            cpf = Console.ReadLine();
          }
          empreendedor.setCpf(cpf);
          
          Console.WriteLine("Telefone para Contato: ");
          empreendedor.setTelefone(Console.ReadLine());
          Console.WriteLine("Descrição Da Startup: ");
          empreendedor.setTipoServico(Console.ReadLine());
          Console.WriteLine("Cidade da sede: ");
          empreendedor.setCidade(Console.ReadLine());
          Console.WriteLine("Valor desejado para investimento: ");
          empreendedor.setPreco(Double.Parse(Console.ReadLine()));

          empreendedor.insert();
          Console.WriteLine("Startup cadastrada com sucesso!");
        }
      }else if(opcaoPerfil == "2"){
        Console.WriteLine("Possui cadastro conosco? ");
        Console.WriteLine("Digite: \n 1 - SIM \n 2 - NÃO");
        opcaoUsuario = Console.ReadLine();
        if(opcaoUsuario == "1"){
          Autenticador = File.OpenText("./BD/comprador.txt");
          Console.WriteLine("Digite seu CPF (Sem pontos) ");
          opcaoCpf = Console.ReadLine();
          while(Autenticador.EndOfStream != true){
            string linha = Autenticador.ReadLine();
            if(linha.Contains(opcaoCpf)){
              finded = true;
              Console.WriteLine("Usuário encontrado!");
              Console.WriteLine("Serviços disponiveis:");
              empreendedor.listar();
            }
          }
          Autenticador.Close();
          if(finded){
            Console.WriteLine("Selecione uma Startup (Digite o cpf):");
            cpf = Console.ReadLine();
            while(empreendedor.selecionar(cpf) == "false"){
              Console.WriteLine("Cpf inválido, digite novamente: ");          
              cpf = Console.ReadLine();
            }
            empreendedorString = empreendedor.selecionar(cpf);
            string[] empreendedorArray = empreendedorString.Split(";".ToCharArray());

            empreendedorComprador.setCpfEmpreendedor(empreendedorArray[1]);
            empreendedorComprador.setCpfComprador(opcaoCpf);
            empreendedorComprador.setServico(empreendedorArray[4]);
            empreendedorComprador.setValor(Double.Parse(empreendedorArray[6]));

            empreendedorComprador.insert();
            Console.WriteLine("Investimento feito!");

          }else{
            Console.WriteLine("Usuário não encontrado!");
          }
        }else{
          Console.WriteLine("Nome do investidor: ");
          comprador.setNome(Console.ReadLine());
          Console.WriteLine("Cpf do investidor: ");
          cpf = Console.ReadLine();
          while(!comprador.ValidaCPF(cpf)){
            Console.WriteLine("Cpf inválido, digite novamente: ");          
            cpf = Console.ReadLine();
          }
          comprador.setCpf(cpf);
          Console.WriteLine("Telefone para Contato: ");
          comprador.setTelefone(Console.ReadLine());
          Console.WriteLine("Cidade: ");
          comprador.setCidade(Console.ReadLine());
          Console.WriteLine("Valor que deseja investir: ");
          comprador.setValorInvestido(Double.Parse(Console.ReadLine()));

          comprador.insert();
          Console.WriteLine("Cadastro efetuado com sucesso. Parabéns!");
        }
      }else if(opcaoPerfil == "0"){
        Console.WriteLine("Obrigado!");
      }
      
    }
  }
}

