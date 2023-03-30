using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            ////task array
            //Task[] tasks1 = new Task[3];
            //int j = 1;
            //for (int i = 0; i < tasks1.Length; i++)
            //    tasks1[i] = Task.Factory.StartNew(() => { Task.Delay(1000); Console.WriteLine($"Task {j++}");});
            //Task.WaitAll(tasks1);


            ////task continue
            //Task<int>[] tasks2 = new Task<int>[3];
            //tasks2[0] = Task.Factory.StartNew(() => {return 10; });
            //tasks2[1] = tasks2[0].ContinueWith(t => { return 20; });
            //tasks2[2] = tasks2[1].ContinueWith(t => { return 30; });
            //Task.WaitAll(tasks2);
            //for (int i = 0; i < tasks2.Length; i++)
            //    Console.WriteLine(tasks2[i].Result);
            //Console.ReadLine();
            // метод Parallel.Invoke выполняет три метода

            ////Prallel Ivoke
            //Parallel.Invoke(
            //    Print,
            //    () => Sqr(5)
            //);
            //Console.ReadLine();

            ////Parallel for
            //Parallel.For(1, 5, Sqr);

            //Parallel foreach
            Parallel.ForEach<int>(new List<int>() { 2, 3, 4 ,5,6}, SqrParallelForEach);

            Console.ReadLine();
        }
        static void Print()
        {
            Console.WriteLine($"Print task active {Task.CurrentId}");
            Thread.Sleep(1500);
        }
        static void Sqr(int a)
        {
            Console.WriteLine($"SQR task active {Task.CurrentId}");
            Thread.Sleep(1500);
            Console.WriteLine($"SQR result {a * a}");
        }
        static void SqrParallelForEach(int a, ParallelLoopState state)
        {
            Console.WriteLine($"SQR task active {Task.CurrentId}");
            Thread.Sleep(1500);
            if (a == 5) state.Break();
            Console.WriteLine($"SQR result {a * a}");
        }
    }
}
