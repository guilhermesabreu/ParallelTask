using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ParallelTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            //Fazendo a Chamada paralela, cada um em sua Thread 
            Parallel.Invoke( () => ImprimirZero(), () => ImprimirUm(), ()=> ImprimirZero());
            stopwatch.Stop();
            Console.WriteLine( );
            System.Console.WriteLine("Parallel.Invoke -> A Tarefa foi finalizada em: {0}", stopwatch.ElapsedMilliseconds / 1000.0 + " segundos");
            
            stopwatch.Reset();
            stopwatch.Start();
            ImprimirZero();
            ImprimirUm();
            ImprimirPonto();
            stopwatch.Stop();
            Console.WriteLine();
            System.Console.WriteLine("Sem Parallel.Invoke -> A Tarefa foi finalizada em: {0}", stopwatch.ElapsedMilliseconds / 1000.0 + " segundos");
        }

        private static void ImprimirPonto()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write(".");
            } 
        }

        private static void ImprimirUm()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write("1");
            } 
        }

        private static void ImprimirZero()
        {
            for (int i = 0; i < 300; i++)
            {
                ExecutarTarefaDemorada();
                Console.Write("0");
            } 
        }


        private static void ExecutarTarefaDemorada()
        {
            Thread.Sleep(10);
        }
    }
}
