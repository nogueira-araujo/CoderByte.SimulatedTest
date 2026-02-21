namespace CoderByte.SimulatedTest
{
    
    //classe principal para encontrar a menor substring que contém todos os caracteres do padrão
    internal static class MinWindow
    {
        public static string MinWindowSubstring(string str, string pattern)
        {
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern) || pattern.Length > str.Length)
                return string.Empty;

            var need = BuildNeed(pattern);

            int missing = pattern.Length;
            int startPos = 0;
            int bestLen = int.MaxValue;
            int left = 0;

            // para cada caractere à direita, tenta expandir a janela para cobrir o padrão.
            for (int right = 0; right < str.Length; right++)
            {
                char rightChar = str[right];

                // Se rightChar faz parte do padrão, consome esse "need".
                if (need.ContainsKey(rightChar))
                {
                    // Se rightChar ainda é necessário, decrementa missing.
                    if (need[rightChar] > 0)
                    { missing--; }
                    // Decrementa a contagem de rightChar em "need".
                    need[rightChar] --;
                }

                // Quando missing == 0, a janela atual cobre o padrão.
                while (missing == 0)
                {
                    int len = right - left + 1;
                    if (len < bestLen)
                    {
                        bestLen = len;
                        startPos = left;
                    }

                    char leftChar = str[left];

                    // Tenta encolher pela esquerda: devolve lc para o "need".
                    if(need.ContainsKey(leftChar))
                    {
                        // Se leftChar é parte do padrão, incrementa sua contagem em "need".
                        need[leftChar]++;

                        if(need[leftChar] > 0)
                        {
                            // Se leftChar agora é necessário novamente, incrementa missing.
                            missing++;
                        }
                    }

                    // Move left para tentar encontrar uma janela menor.
                    left++;
                }
            }

            return bestLen == int.MaxValue
                ? string.Empty
                : str.Substring(startPos, bestLen);
        }

        // Constrói o dicionário que conta quantas vezes cada caractere do padrão é necessário.
        private static Dictionary<char, int> BuildNeed(string pattern)
        {
            var need = new Dictionary<char, int>();
            foreach (char c in pattern)
            {
                if (need.ContainsKey(c))
                {
                    need[c]++;
                }
                else
                    need.Add(c, 1);
            }
            return need;
        }
    }
}
