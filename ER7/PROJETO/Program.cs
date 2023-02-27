
using PROJETO.Classes;

Console.Clear();
Console.WriteLine(@$"
============================================================
|           Bem vindo ao sistema de cadastro de            |
|              Pessoas Físicas e Jurídicas                 |
============================================================
");

BarraCarregamento("Carregando",300);

List<PessoaFisica> listaPF = new List<PessoaFisica>();
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
        PessoaFisica metodoPf = new PessoaFisica();

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

            switch (opcaoPf)
            {
                case "1":
                      
                        Console.Clear();
                        PessoaFisica NovaPf = new PessoaFisica();
                        Endereco novoEnd = new Endereco();
                            
                        Console.WriteLine($"Digite o nome da pessoa física que deseja cadastras:");
                        NovaPf.nome = Console.ReadLine();

                       
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

                        Console.WriteLine($"Digite o número do CPF:");                        
                        NovaPf.cpf = Console.ReadLine();
                        
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
                        listaPF.Add(NovaPf);
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                         Console.WriteLine($"Cadastro realizado com sucesso!");
                         Console.ResetColor();
                    break;

                case "2":
                        Console.Clear();
                        if(listaPF.Count > 0)
                        {
                            foreach (PessoaFisica cadaPessoa in listaPF)
                            {
                                Console.Clear();
                                 Console.WriteLine(@$"
                                Nome: {cadaPessoa.nome}
                                Data de Nascimento: {cadaPessoa.dataNascimento}
                                CPF: {cadaPessoa.cpf}
                                Rendimento: {cadaPessoa.rendimento.ToString("C")}
                                Logradouro: {cadaPessoa.endereco.Logradouro}
                                Numero: {cadaPessoa.endereco.numero}
                                Complemento: {cadaPessoa.endereco.complemento}
                                Endereço Comercial? {((bool)(cadaPessoa.endereco.endComercial)?"Sim":"Não")}
                                Taxa de Imposto a ser paga: {metodoPf.PagarImposto(cadaPessoa.rendimento).ToString("C")}

                        ");
                        Console.WriteLine($"Aperte 'Enter'para continuar...");
                        Console.ReadLine();
                            }
                        } 
                        else
                        {
                            Console.WriteLine($"Lista vazia!");
                            Thread.Sleep(3000);
                        }

                       

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
        Console.Clear();
        PessoaJuridica metodoPj = new PessoaJuridica();
        PessoaJuridica novaPj = new PessoaJuridica();
        Endereco novoEndPj = new Endereco();
        novaPj.nome = "Nome PJ";
        novaPj.cnpj = "00.000.000/0001-00";
        novaPj.razaoSocial = "Razao Social Pj";
        novaPj.rendimento = 8000.5f;
        novoEndPj.Logradouro = "Rua Niteroi";
        novoEndPj.numero = 180;
        novoEndPj.complemento = "Senai de Informática";
        novoEndPj.endComercial = true;
        novaPj.endereco = novoEndPj;
        Console.WriteLine(@$"
        Nome: {novaPj.nome}
        Razao Social: {novaPj.razaoSocial}
        CNPJ: {novaPj.cnpj}
        Rendimento: {novaPj.rendimento}
        Logradouro: {novaPj.endereco.Logradouro}
        Numero: {novaPj.endereco.numero}
        Complemento: {novaPj.endereco.complemento}
        Endereço Comercial? {((bool)(novaPj.endereco.endComercial)?"Sim":"Não")}
        CNPJ é valido? {(metodoPj.ValidarCnpj(novaPj.cnpj)?"Sim": "Não")}
        Taxa de Imposto a ser paga: {metodoPj.PagarImposto(novaPj.rendimento).ToString("C")}

        ");
        Console.WriteLine($"Aperte 'Enter'para continuar");
        Console.ReadLine();
        break;
    case "0":
        Console.Clear();
        Console.WriteLine($"Obrigado por utilizar nosso sistema");
        BarraCarregamento("Finalizando", 200);
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











/*



*/






