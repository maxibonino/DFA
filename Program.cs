using System;
using System.IO;
using System.Collections.Generic;

namespace Finite_Automaton
{
    public class Program
    {
        static void Main(string[] args)
        {
            #region
            //Automaton a = new Automaton();

            //String sigma = "abcdef";
            //int nstate = 8; // кол-во состояний (т.е. мощность множества Q)

            //Dictionary<string, Dictionary<string, string>> delta; // таблица состояний автомата
            // первый ключ - состояний
            // второй ключ - сигнал
            // значение словаря - новое состояние автомата

            //SortedSet<string> S; // множество начальных состояний автомата
            //SortedSet<string> F; // множество конечных состоний
            #endregion

            using (StreamReader inp = new StreamReader(@"C:\Users\TEMP\Downloads\DFA-last-version\input_non_determined.txt"))
            {
                char[] delim = { ',', ' ', '\t' };

                String[] sigma = inp.ReadLine().Trim().Split(delim);

                int nstate = int.Parse(inp.ReadLine());
                
                inp.ReadLine(); // skip


                var delta = new Dictionary<string, Dictionary<string, List<string>>>();
                for (int i = 0; i < nstate; i++)
                {
                    String[] line = inp.ReadLine().Split(delim, StringSplitOptions.RemoveEmptyEntries);
                    delta.Add(line[0], new Dictionary<string, List<string>>());

                    for (int j = 0; j < sigma.Length - 1; j++)
                    {
                        delta[line[0]].Add(sigma[j], new List<string>());

                        foreach (var next_state in line[j + 1].Split('/'))
                            delta[line[0]][sigma[j]].Add(next_state);

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


                String[] input_word = inp.ReadLine().Trim().Split();

                Automaton a = new Automaton(sigma, delta, S, F);

                Tuple<bool, int> res = a.MaxString(input_word, k); //  <----- ответ здесь

                if (res.Item1)
                {
                    Console.WriteLine($"Answer is: <True, {res.Item2}>");
                }
                else
                {
                    Console.WriteLine("Answer is: <False, 0>");
                }
                Console.ReadLine();
            }
        }
    }
}
