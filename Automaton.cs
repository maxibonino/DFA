using System;
using System.Collections.Generic;
using System.Linq;

namespace Finite_Automaton
{
    public class Automaton
    {
        private String[] _inputSignals;
        private Dictionary<String, Dictionary<String, List<string>>> _table;
        private SortedSet<String> _s;
        private SortedSet<String> _f;

        public Automaton(String[] inputSignals, Dictionary<String, Dictionary<String, List<string>>> table,
            SortedSet<String> s, SortedSet<String> f)
        {
            _inputSignals = inputSignals;
            _table = table;
            _s = s;
            _f = f;
        }

        public Tuple<bool, int> MaxString(String[] inputWord, int k)
        {
            Tuple<bool, int> result = new Tuple<bool, int>(_s.Intersect(_f).Count() == 0 ? false : true, 0);


            SortedSet<String> state = new SortedSet<String>(_s);

            // состояние лучше классом или структурой
            Console.WriteLine(inputWord.Length);
            for (int i = k; i < inputWord.Length; i++)
            {
                SortedSet<String> tmp = new SortedSet<String>();
                foreach (var cur_state in state)
                {
                    try
                    {
                        foreach (var next_state in _table[cur_state][inputWord[i]])
                        {
                            tmp.Add(next_state);
                        }
                    }
                    catch
                    {
                        //Console.WriteLine(inputWord[i]);
                    }
                }
                state = tmp;
                //////////////////////////////////////////////////////////////////////////////////////////////////////////
                /*foreach (var q in state)
                    Console.Write(q + " ");
                Console.WriteLine();*/

                bool isAnswer = state.Intersect(_f).Count() == 0 ? false : true;

                //Console.WriteLine(isAnswer);

                if (isAnswer)
                    result = new Tuple<bool, int>(true, i - k + 1);

                
            }

            return result;
        }
    }
}
