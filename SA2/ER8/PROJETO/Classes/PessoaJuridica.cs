using System.Text.RegularExpressions;
using PROJETO.Interfaces;

namespace PROJETO.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string ?cnpj { get; set; }
        public string ?razaoSocial { get; set;}

        public string caminho { get; private set;} = "Database/PessoaJuridica.csv";
    
        
        public override float PagarImposto(float rendimento)
        {
            /*
                Rendimentos de até 3000 vai pagar 3%
                De 3000 a 6000 vai pagar 5%
                De 6000 a 10000 vai pagar 7%
                Acima de 10000 vai pagar 9%
            */

            if (rendimento <= 3000)
            {
                return rendimento * 0.03f;
            }
            else if(rendimento > 3000 && rendimento <= 6000)
            {
                return rendimento * 0.05f;
            }
            else if(rendimento > 6000 && rendimento <= 10000)
            {
                return rendimento * 0.07f;
            }
            else
            {
                return rendimento * 0.09f;
            }
        }

        public bool ValidarCnpj(string cnpj)
        {
            if (Regex.IsMatch(cnpj, @"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)")) 
            {
                if(cnpj.Length == 18)
                {
                    if(cnpj.Substring(11,4) == "0001")
                    {
                        return true;
                    }  
                }
                else if(cnpj.Length == 14)
                {
                    if(cnpj.Substring(8,4) == "0001")
                    {
                        return true;
                    }
                }  
            }
            return false;
            

            //XX.XXX.XXX/0001-XX
            //XXXXXXXXX0001XX
        }
        
        public void Inserir(PessoaJuridica pj)
        {
            VerificarPastaArquivo(caminho);

            string[] pjString = {$"{pj.nome},{pj.cnpj},{pj.razaoSocial}"};

            File.AppendAllLines(caminho, pjString);
        }

        public List<PessoaJuridica> Ler()
        {
            List<PessoaJuridica> listaPJ = new List<PessoaJuridica>();
            string[] linhas = File.ReadAllLines(caminho);

            foreach (string cadaLinha in linhas)
            {
                string[] atributos = cadaLinha.Split(",");
                PessoaJuridica cadaPj = new PessoaJuridica();
                cadaPj.nome = atributos[0];
                cadaPj.cnpj = atributos[1];
                cadaPj.razaoSocial= atributos[2];

                listaPJ.Add(cadaPj);
            }
            return listaPJ;
        }
    }
}