using System;
using System.Collections;
using System.Collections.Generic;

namespace Calculadora
{
    class Program
    {
        /* Função criada para imprimir as operações restantes na fila */
        public void imprime_fila(Queue<Operacoes> filaOperacoes)
        {
            if (filaOperacoes.Count > 0) {
                Console.Write("\t• Operações restantes:\t");
                foreach (Operacoes operacao in filaOperacoes) {

                    Console.Write("[ {0} {1} {2} ]  ", operacao.valorA,operacao.operador,operacao.valorB);
                }
                Console.Write("\n");
            }
        }

        /* Função criada para imprimir os resultados na pilha (ordem inversa dos cálculos) */
        public void imprime_stack(Stack<decimal> pilhaResultados)
        {
            if (pilhaResultados.Count > 0) {
                Console.Write("\nRESULTADOS OBTIDOS:  ");
                foreach (decimal resultado in pilhaResultados) {

                    Console.Write("{0}, ", resultado);
                }
                Console.WriteLine("\n");
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            Queue<Operacoes> filaOperacoes = new Queue<Operacoes>();
            filaOperacoes.Enqueue(new Operacoes { valorA = 2, valorB = 3, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 14, valorB = 8, operador = '-' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 5, valorB = 6, operador = '*' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 2147483647, valorB = 2, operador = '+' });
            filaOperacoes.Enqueue(new Operacoes { valorA = 18, valorB = 3, operador = '/' });

            /* Pilha (Stack) criada para armazenar os resultados das operações */
            Stack<decimal> pilhaResultados = new Stack<decimal>();

            Calculadora calculadora = new Calculadora();
            
            //while (filaOperacoes.Count >= 0)
            while (filaOperacoes.Count > 0)
            /* Essa mudança evita que seja feita uma iteração do while com a fila vazia, o que gera erro */
            {
                //Operacoes operacao = filaOperacoes.Peek();
                Operacoes operacao = filaOperacoes.Dequeue();
                /* Essa mudança garante que a operação seja removida da fila após ser calculada,
                impedindo que o programa entre em loop infinito */

                calculadora.calcular(operacao);
                pilhaResultados.Push(operacao.resultado);
                Console.WriteLine("{0} {1} {2} = {3}", operacao.valorA,operacao.operador,operacao.valorB, operacao.resultado);
                p.imprime_fila(filaOperacoes);
            }

            p.imprime_stack(pilhaResultados);

        }
    }
}
