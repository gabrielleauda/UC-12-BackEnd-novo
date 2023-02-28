
using PROJETO.Classes;

Console.Clear();
Console.WriteLine(@$"
============================================================
|           Bem vindo ao sistema de cadastro de            |
|              Pessoas Físicas e Jurídicas                 | 
============================================================
");

//gabi//

BarraCarregamento("Carregando",100);

string? opcao;
do
{
    Console.Clear();
    Console.WriteLine(@$"
============================================================
|               Escolha uma das opções abaixo              |
|----------------------------------------------------------|
|               1 - Pessoa Física                          |
|               2 - Pessoa Jurídica                        |
|                                                          |
|               0 - Sair                                   |
============================================================
");

opcao = Console.ReadLine();

switch (opcao)
{
    case "1":

        string? opcaoPf;

        do
        {
            Console.Clear();
            Console.WriteLine(@$"
            ============================================================
            |               Escolha uma das opções abaixo              |
            |----------------------------------------------------------|
            |               1 - Cadastrar Pessoa Física                |
            |               2 - Mostrar Pessoa Fisíca                  |
            |                                                          |
            |               0 - Voltar ao menu anterior                |
            ============================================================
");
            opcaoPf = Console.ReadLine();

            PessoaFisica metodoPf= new PessoaFisica();
            PessoaFisica NovaPf = new PessoaFisica();
            Endereco novoEnd = new Endereco();

            switch (opcaoPf)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine($"Digite o nome da pessoa física que deseja cadastras:");
                    NovaPf.nome = Console.ReadLine();

                    Console.WriteLine($"Digite o número do CPF:");                        
                    NovaPf.cpf = Console.ReadLine();
                       
                   bool dataValida;
                    do
                    {                           
                        Console.WriteLine($"Digite a data de nascimento Ex.: DD/MM/AAAA");
                        string dataNasc = Console.ReadLine();

                        dataValida = metodoPf.ValidarDataNascimento(dataNasc);

                    if (dataValida)
                    {
                         NovaPf.dataNascimento = dataNasc;
                   }

                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"Data digitada é inválida, por favor digite uma data correta.");
                        Console.ResetColor();
                    }
                    } while (dataValida == false );

                        
                        Console.WriteLine($"Digite o rendimento mensal: (apenas números)");
                        NovaPf.rendimento = float.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o logradouro:");
                        novoEnd.Logradouro = Console.ReadLine();

                        Console.WriteLine($"Digite o número:");
                        novoEnd.numero = int.Parse(Console.ReadLine());

                        Console.WriteLine($"Digite o complemento: (aperte ENTER para vazio)");
                        novoEnd.complemento = Console.ReadLine(); 

                        Console.WriteLine($"Este endereço é comercial? S ou N");
                        string endCom = Console.ReadLine().ToUpper();

                        if (endCom == "S")
                        {
                            novoEnd.endComercial = true;
                        } else { 
                            novoEnd.endComercial = false;
                        }                  
                        NovaPf.endereco = novoEnd;
                        metodoPf.Inserir(NovaPf);

        
                        using (StreamWriter sw = new StreamWriter($"{NovaPf.nome}.txt"))
                        {
                           sw.WriteLine(NovaPf.nome); 
                        }


                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine($"Cadastro realizado com sucesso!");
                        Console.ResetColor();
                    break;

                case "2":

                List<PessoaFisica> listaPf = metodoPf.Ler();
                foreach (PessoaFisica cadaItem in listaPf)
                {
                    Console.Clear();
                    Console.WriteLine(@$"
                    Nome: {cadaItem.nome}
                    CPF: {cadaItem.cpf}
                    Data de Nascimento: {cadaItem.dataNascimento}
                    Rendimento: {cadaItem.rendimento.ToString("C")}
                    Logradouro: {cadaItem.endereco.Logradouro}                        
                    Numero: {cadaItem.endereco.numero}
                    Complemento: {cadaItem.endereco.complemento}
                    Endereço Comercial? {((bool)(cadaItem.endereco.endComercial)?"Sim":"Não")}
                    Taxa de Imposto a ser paga: {metodoPf.PagarImposto(cadaItem.rendimento).ToString("C")}

                    ");
                    Console.WriteLine($"Aperte 'Enter'para continuar...");
                    Console.ReadLine();
                    }

                    Console.WriteLine($"Aperte ENTER para continuar...");
                    Console.ReadLine();

                    break;

                case "0":
                    break;

                default:
                Console.Clear();
                Console.WriteLine($"Opção Inválida, por favor digite uma das opções disponiveis.");
                Thread.Sleep(3000);

                    break;
            }
            

        } while (opcaoPf != "0");

        break;
    case "2":
        string? opcaoPj;
        do
        {
            Console.Clear();
            Console.WriteLine(@$"
                    ============================================================
                    |               Escolha uma das opções abaixo              |
                    |----------------------------------------------------------|
                    |               1 - Cadastrar Pessoa Juridica              |
                    |               2 - Mostrar Pessoa Juridica                |
                    |                                                          |
                    |               0 - Voltar ao menu anterior                |
                    ============================================================
        ");
                opcaoPj = Console.ReadLine();  

                PessoaJuridica metodoPj = new PessoaJuridica();
                PessoaJuridica novaPj = new PessoaJuridica();
                Endereco novoEndPj = new Endereco();

        switch (opcaoPj)
        {
            case "1":
                            
                Console.Clear();

                 Console.WriteLine($"Digite o nome da pessoa juridica que deseja cadastrar:");
                novaPj.nome = Console.ReadLine();

                            
                bool cnpjValido;
                 do
                {
                     Console.WriteLine($"Digite o CNPJ:Ex.: 00.000.000/0001-00 ou 00000000000000.");
                    string cnpj = Console.ReadLine();

                    cnpjValido = metodoPj.ValidarCnpj(cnpj);
                     if (cnpjValido)
                    {
                         novaPj.cnpj= cnpj;
                    }

                    else
                    {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"CNPJ digitado é inválido, por favor digite um CNPJ válido.");
                    Console.ResetColor();
                    }
                } while (cnpjValido== false );

                Console.WriteLine($"Digite a razão social:");    
                novaPj.razaoSocial = Console.ReadLine();
                                
                Console.WriteLine($"Digite o rendimento mensal: (apenas números)");
                novaPj.rendimento = float.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o logradouro:");
                novoEndPj.Logradouro = Console.ReadLine();

                Console.WriteLine($"Digite o número:");
                novoEndPj.numero = int.Parse(Console.ReadLine());

                Console.WriteLine($"Digite o complemento: (aperte ENTER para vazio)");
                novoEndPj.complemento = Console.ReadLine(); 

                Console.WriteLine($"Este endereço é comercial? S ou N");
                string endCom = Console.ReadLine().ToUpper();
                if (endCom == "S")
                {
                      novoEndPj.endComercial = true;
                } else { 
                     novoEndPj.endComercial = false;
                }                  
                novaPj.endereco = novoEndPj;
                metodoPj.Inserir(novaPj);

                List<PessoaJuridica> listaPj = metodoPj.Ler();

                foreach (PessoaJuridica cadaPessoa in listaPj)
                {
                        Console.WriteLine(@$"
                        Nome: {novaPj.nome}
                        Razao Social: {novaPj.razaoSocial}
                        CNPJ: {novaPj.cnpj}
                        Rendimento: {novaPj.rendimento}
                        Logradouro: {novaPj.endereco.Logradouro}
                        Numero: {novaPj.endereco.numero}
                        Complemento: {novaPj.endereco.complemento}
                        Taxa de Imposto a ser paga: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}
                        ");
                        Console.WriteLine($"Aperte 'Enter'para continuar...");
                        Console.ReadLine();
                }

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"Cadastro realizado com sucesso!");
                Console.ResetColor();
                break;


            case "0":
                break;

            default:
                Console.Clear();
                Console.WriteLine($"Opção Inválida, por favor digite uma das opções disponiveis.");
                Thread.Sleep(2000);
                break;
        
                 }

        } while (opcaoPj != "0");
        break;

    case "0":
        Console.Clear();
        Console.WriteLine($"Obrigado por utilizar nosso sistema");
        BarraCarregamento("Finalizando", 100);
        break;
    default:
        Console.Clear();
        Console.WriteLine($"Opção Inválida, por favor digite outra opção.");
        Thread.Sleep(3000);
        break;
}

} while (opcao != "0");


static void BarraCarregamento(string texto, int tempo)
{
    Console.BackgroundColor = ConsoleColor.DarkCyan;
    Console.ForegroundColor = ConsoleColor.Red;

    Console.Write($"{texto}");

    for(var contador = 0; contador < 25; contador ++)
    {
        Console.Write(". ");
        Thread.Sleep(tempo);
    }
    Console.ResetColor();  
}