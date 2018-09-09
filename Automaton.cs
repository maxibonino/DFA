using System;
using System.Collections.Generic;
using System.Linq;

namespace Finite_Automaton
{
    public class Automaton
    {
        private String _inputSignals;
        private Dictionary<String, Dictionary<String, String>> _table;
        private SortedSet<String> _s;
        private SortedSet<String> _f;

        public Automaton(String inputSignals, Dictionary<String, Dictionary<String, String>> table,
            SortedSet<String> s, SortedSet<String> f)
        {
            _inputSignals = inputSignals;
            _table = table;
            _s = s;
            _f = f;
        }

        public Tuple<bool, int> MaxString(String inputWord, int k)
        {
            Tuple<bool, int> result = new Tuple<bool, int>(_s.Intersect(_f).Count() == 0 ? false : true, 0);


            SortedSet<String> state = new SortedSet<String>(_s);

            // состояние лучше классом или структурой

            for (int i = k; i < inputWord.Length; i++)
            {
                SortedSet<String> tmp = new SortedSet<String>();
                foreach (var cur_state in state)
                {
                    tmp.Add(_table[cur_state][new String(inputWord[i], 1)]);
                }

                result = new Tuple<bool, int>(_s.Intersect(_f).Count() == 0 ? false : true, i - k);
            }

            return result;
        }
    }
}
