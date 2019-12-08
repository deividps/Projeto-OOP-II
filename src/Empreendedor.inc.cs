using System.IO;
using System.Text;
using System;

class Empreendedor : BaseSombra{
  private string cpf;
  private string nome;
  private string telefone;
  private string tipoServico;
  private string cidade;
  private double preco;

  public void setCpf(string Cpf){
    cpf = Cpf;
  }

  public string getCpf(){
    return cpf;
  }

  public void setNome(string Name){
    nome = Name;
  }

  public string getNome(){
    return nome;
  }

  public void setTelefone(string Tel){
    telefone = Tel;
  }

  public string getTelefone(){
    return telefone;
  }

  public void setTipoServico(string Serv){
    tipoServico = Serv;
  }

  public string getTipoServico(){
    return tipoServico;
  }

  public void setCidade(string City){
    cidade = City;
  }

  public string getCidade(){
    return cidade;
  }

  public void setPreco(double Price){
    preco = Price;
  }

  public double getPreco(){
    return preco;
  }

  public void insert(){
    BaseSombra db = new BaseSombra();

    string query = $"{this.cpf};{this.nome};{this.telefone};{this.tipoServico};{this.cidade};{this.preco}";

    db.insert("./BD/empreendedor.txt",query);

  }
  public void listar(){
    BaseSombra db = new BaseSombra();
    db.listar("empreendedor","./BD/empreendedor.txt");

  }
  
  public string selecionar(string cpf){
    //declarando a variavel do tipo StreamWriter 
    StreamReader x;

    //abrindo um arquivo texto
    x = File.OpenText("./BD/empreendedor.txt");

    while (x.EndOfStream != true){
      string linha = x.ReadLine();

      // string[] array = linha.Split(";".ToCharArray());
      if(linha.Contains(cpf)){
        x.Close();
        return linha;
      }
    }
    x.Close();
    return "false";
    
  }

}