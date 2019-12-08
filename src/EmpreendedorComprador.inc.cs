using System.IO;
using System.Text;

class EmpreendedorComprador : BaseSombra{
  private string cpfEmpreendedor;
  private string cpfComprador;
  private string servico;
  private double valor;

  public void setCpfEmpreendedor(string Cpf){
    cpfEmpreendedor = Cpf;
  }

  public string getCpfEmpreendedor(){
    return cpfEmpreendedor;
  }

  public void setCpfComprador(string Cpf){
    cpfComprador = Cpf;
  }

  public string getCpfComprador(){
    return cpfComprador;
  }

  public void setServico(string Servico){
    servico = Servico;
  }

  public string getServico(){
    return servico;
  }

  public void setValor(double Valor){
    valor = Valor;
  }

  public double getValor(){
    return valor;
  }

  public void insert(){
    BaseSombra db = new BaseSombra();

    string query = $"{this.cpfEmpreendedor};{this.cpfComprador};{this.servico};{this.valor}";

    db.insert("./BD/empreendedor_comprador.txt",query);

  }

  public void listar(string cpf){
    BaseSombra db = new BaseSombra();
    db.listar(cpf,"./BD/empreendedor_comprador.txt");

  }
}