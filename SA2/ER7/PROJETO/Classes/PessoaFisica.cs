using PROJETO.Interfaces;

namespace PROJETO.Classes
{
    public class PessoaFisica : Pessoa, IPessoaFisica
    {
        public string ?cpf { get; set; }
        public string ?dataNascimento { get; set; }
        public bool ValidarDataNascimento(string dataNasc)
        {   
            DateTime dataConvertida;
            if(DateTime.TryParse(dataNasc, out dataConvertida)){
                DateTime dataAtual = DateTime.Today;
                double anos = (dataAtual - dataConvertida).TotalDays / 365;
                if (anos >= 18){
                    return true;
                }
                return false;  
            } 
            return false; 
        }
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
    }
}