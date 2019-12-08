using System;
using System.IO;
using System.Text;

class BaseSombra { 
  public void insert(string caminho, string conteudo){
    
    var lineCount = (File.ReadAllLines(caminho).Length)+1;
    var text = lineCount.ToString()+";"+conteudo;
    using (StreamWriter sw = File.AppendText(caminho)) {
      sw.WriteLine(text);
    }	
    
  
  }

  public void listar(string tp,string caminho){
    //declarando a variavel do tipo StreamWriter 
    StreamReader x;

    //abrindo um arquivo texto
    x = File.OpenText(caminho);

                                  //enquanto nao retornar valor booleano true 
    while (x.EndOfStream != true){//quer dizer que não chegou no fim do  arquivo
        string linha = x.ReadLine();

        string[] array = linha.Split(";".ToCharArray());
        //escreve na tela o conteúdo da linha
        if(tp == "empreendedor"){
          Console.WriteLine($"
            Cpf: {array[1]} \n
            Nome: {array[2]} \n
            Telefone: {array[3]} \n
            Servico: {array[4]} \n
            Cidade: {array[5]} \n
            Preco: {array[6]}
          ");
        }else if(tp == "comprador"){
          Console.WriteLine($"
            Cpf: {array[1]} \n
            Nome: {array[2]} \n
            Telefone: {array[3]} \n
            Cidade: {array[4]} \n
            Valor investido: {array[5]}
          ");
        }else{
          if(linha.Contains(tp)){
            Console.WriteLine($"
              Cpf Empreendedor: {array[1]} \n
              Cpf Comprador: {array[2]} \n
              Servico: {array[3]} \n
              Valor: {array[4]}
            ");
          }
        }
    }
    //após sair do while, é porque leu todo o conteúdo, então
    //temos que fechar o arquivo texto que está aberto
    x.Close();

    
  }

  public bool ValidaCPF(string valor){
    if (valor.Length != 11)
      return false;
    
    bool igual = true;
    
    for (int i = 1; i < 11 && igual; i++)
      if (valor[i] != valor[0])
        igual = false;



    if (igual || valor == "12345678909")
        return false;

    int[] numeros = new int[11];

    for (int i = 0; i < 11; i++)
      numeros[i] = int.Parse(valor[i].ToString());

    int soma = 0;

    for (int i = 0; i < 9; i++)
      soma += (10 - i) * numeros[i];

    int resultado = soma % 11;

    if (resultado == 1 || resultado == 0){
      if (numeros[9] != 0)
        return false;
    }else if (numeros[9] != 11 - resultado)
      return false;

    soma = 0;
    
    for (int i = 0; i < 10; i++)
        soma += (11 - i) * numeros[i];

    resultado = soma % 11;

    if (resultado == 1 || resultado == 0){
      if (numeros[10] != 0)
        return false;
    }else
      if (numeros[10] != 11 - resultado)
        return false;
        
    return true;

  }
}