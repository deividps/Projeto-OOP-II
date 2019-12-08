class Comprador : BaseSombra {
  private string cpf;
  private string nome;
  private string telefone;
  private string cidade;
  private double valorInvestido;

  public void setCpf(string Cpf){
    cpf = Cpf;
  }

  public string getCpf(){
    return cpf;
  }

  public void setNome(string n){
    nome = n;
  }

  public string getNome(){
    return nome;
  }

  public void setTelefone(string t){
    telefone = t;
  }

  public string getTelefone(){
    return telefone;
  }

  public void setCidade(string ct){
    cidade = ct;
  }

  public string getCidade(){
    return cidade;
  }

  public void setValorInvestido(double vl){
    valorInvestido = vl;
  }

  public double getValorInvestido(){
    return valorInvestido;
  }

  // public Comprador(string c, string n, string t, string ct, double vl){
  //   cpf = c;
  //   nome = n;
  //   telefone = t;
  //   cidade = ct;
  //   valorInvestido = vl;
  // }

  public void insert(){
    BaseSombra db = new BaseSombra();

    string query = $"{this.cpf};{this.nome};{this.telefone};{this.cidade};{this.valorInvestido}";

    db.insert("./BD/comprador.txt",query);

  }
  public void listar(){
    BaseSombra db = new BaseSombra();
    db.listar("comprador","./BD/comprador.txt");

  }
}