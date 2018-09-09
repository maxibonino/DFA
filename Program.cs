using System;
using System.IO;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finite_Automaton
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Automaton a = new Automaton();

            //String sigma = "abcdef";
            //int nstate = 8; // кол-во состояний (т.е. мощность множества Q)

            //Dictionary<string, Dictionary<string, string>> delta; // таблица состояний автомата
            // первый ключ - состояний
            // второй ключ - сигнал
            // значение словаря - новое состояние автомата

            //SortedSet<string> S; // множество начальных состояний автомата
            //SortedSet<string> F; // множество конечных состоний

            using (StreamReader inp = new StreamReader(@"C:\Users\Morpheus\source\repos\Finite_Automaton\Finite_Automaton\input.txt"))
            {
                char[] delim = { ' ' };

                String sigma = inp.ReadLine().Trim();

                int nstate = int.Parse(inp.ReadLine());
                // skip
                inp.ReadLine();

                var delta = new Dictionary<string, Dictionary<string, string>>();
                for (int i = 0; i < nstate; i++)
                {
                    String[] line = inp.ReadLine().Split(delim, StringSplitOptions.RemoveEmptyEntries);
                    delta.Add(line[0], new Dictionary<string, string>());

                    for (int j = 0; j < sigma.Length; j++)
                    {
                        delta[line[0]].Add(new String(sigma[j], 1), line[j]);
                    }
                }

                inp.ReadLine(); // blank line

                SortedSet<String> S = new SortedSet<string>();
                foreach (var q in inp.ReadLine().Split(delim, StringSplitOptions.RemoveEmptyEntries))
                {
                    S.Add(q);
                }


                SortedSet<String> F = new SortedSet<string>();
                foreach (var q in inp.ReadLine().Split(delim, StringSplitOptions.RemoveEmptyEntries))
                {
                    F.Add(q);
                }


                int k = int.Parse(inp.ReadLine());


                String input_word = inp.ReadLine().Trim();

                Automaton a = new Automaton(sigma, delta, S, F);

                Tuple<bool, int> res = a.MaxString(input_word, k);

                if (res.Item1)
                {
                    Console.WriteLine($"Answer is: <True, {res.Item2}>");
                }
                else
                {
                    Console.WriteLine("Answer is: <False, 0>");
                }
            }
        }
    }
}
