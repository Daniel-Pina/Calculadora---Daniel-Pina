using System;
namespace Calculadora
{
    public class Calculadora
    {
        
        public Operacoes calcular(Operacoes operacao)
        {
            switch(operacao.operador)
            {
                case '+': operacao.resultado= soma(operacao);break;
                case '-': operacao.resultado = subtracao(operacao);break;
                case '*': operacao.resultado = multiplicacao(operacao);break;
                /* Incluindo a operação de divisão */
                case '/': operacao.resultado = divisao(operacao);break;
                default: operacao.resultado = 0; break;
            }
            return operacao;
        }
        /* A penúltima linha não está sendo calculada cooretamente pois ocorre um overflow do tipo int
           Por isso, os tipos int foram substituídos por long nas operações */
        public long soma(Operacoes operacao)
        {
            return (long) operacao.valorA + operacao.valorB;
        }
        public long subtracao(Operacoes operacao)
        {
            return (long) operacao.valorA - operacao.valorB;
        }
        public long multiplicacao(Operacoes operacao)
        {
            return (long) operacao.valorA * operacao.valorB;
        }

        /* Implementa a operação de divisão, considerando casos especiais */
        public decimal divisao(Operacoes operacao)
        {
            if (operacao.valorB == 0) {
                return -1;
            }
            else {
                return operacao.valorA / operacao.valorB;
            }
        }
        
       
    }
}
