using PROJETO.Interfaces;

namespace PROJETO.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string ?cpf { get; set; }
        public string ?dataNascimento { get; set; }
        public string caminho { get; private set; } = "Database/PessoaFisica.csv";

    
        public override float PagarImposto(float rendimento)
        {
            /*
                Até 1500 isento
                De 1500,01 a 3500 vai pagar 2% de impostos
                Entre 3500,01 e 6000 vai pagar 3,5% de impostos
                Acima de 6000 vai pagar 5% de impostos
            */
            /*
    	        Tabela Verdade
                Operador E (&&)
                V && V = V
                V && F = F
                F && V = F
                F && F = F
                Quando utilizo o operador E apenas terei respostas verdadeiras
                quando as duas proposicoes analisadas forem verdadeiras

                Operador OU (||)
                V || V = V
                V || F = V
                F || V = V
                F || F = F

                Quando utilizo o operador OU apenas terrei respostas falsas
                quando as duas proposicoes analisadas forem falsas
            */

            if(rendimento <= 1500)
            {
                return 0;
            }
            else if(rendimento > 1500 && rendimento <= 3500)
            {
                return (rendimento / 100) * 2;
            }
            else if(rendimento > 3500 && rendimento <= 6000)
            {
                return (rendimento / 100) * 3.5f;
            }
            else
            {
                return (rendimento / 100) * 5;
            }
        }
         public bool ValidarDataNascimento(DateTime dataNasc)
        {
            DateTime dataAtual= DateTime.Today;
            double anos = (dataAtual - dataNasc).TotalDays /365;
            if(anos >= 18){
                return true;
            }
            return false;
        }
        

        public bool ValidarDataNascimento(string dataNasc)
        {
            DateTime dataConvertida;
            //verificar se a string esta em um fomato valido
            if(DateTime.TryParse(dataNasc, out dataConvertida)){//TryParse tenta converter e coloca na saida out
                //Console.WriteLine($"{dataConvertida}");
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays /365;
                if(anos >= 18){
                    return true;
                }
                return false;
            }
            return false;  
        }

        public void Inserir(PessoaFisica pf)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pf.nome},{pf.cpf},{pf.dataNascimento},{pf.rendimento},{pf.endereco.Logradouro},{pf.endereco.numero},{pf.endereco.complemento},{pf.endereco.endComercial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaFisica> Ler()
        {
            VerificarPastaArquivo(caminho);

            List<PessoaFisica> listaPf = new List<PessoaFisica>();

            string[] linhas = File.ReadAllLines(caminho);


            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");

                PessoaFisica cadaPf = new PessoaFisica();
                Endereco cadaEnd = new Endereco();

                cadaPf.nome = atributos[0];
                cadaPf.cpf = atributos[1];
                cadaPf.dataNascimento = atributos[2];
                cadaPf.rendimento = float.Parse(atributos[3]);
                cadaEnd.Logradouro = atributos[4];
                cadaEnd.numero = int.Parse(atributos[5]);
                cadaEnd.complemento = atributos[6];
                cadaEnd.endComercial = bool.Parse(atributos[7]);
                cadaPf.endereco = cadaEnd;
                listaPf.Add(cadaPf);
            }
            return listaPf;
        }
    }
}