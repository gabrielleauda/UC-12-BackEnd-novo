using System.Text.RegularExpressions;
using PROJETO.Interfaces;

namespace PROJETO.Classes
{
    public class PessoaJuridica : Pessoa, IPessoaJuridica
    {
        public string ?cnpj { get; set; }
        public string ?razaoSocial { get; set;}
        
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
    }
}