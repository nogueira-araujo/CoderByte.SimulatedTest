using System;
using System.Collections.Generic;
using System.Text;

namespace CoderByte.SimulatedTest
{
    //classe auxiliar para manter o estado da janela deslizante
    internal sealed class MinWindowAux
    {
        public int Left;
        public int Right;
        public int RequiredChars;
        public int MinLength;
        public int StartIndex;
        public Dictionary<char, int> PatternCount;
        public MinWindowAux(int requiredChars, Dictionary<char, int> patternCount)
        {
            Left = 0;
            Right = 0;
            RequiredChars = requiredChars;
            MinLength = int.MaxValue;
            StartIndex = 0;
            PatternCount = patternCount;
        }
    }

    //classe principal para encontrar a menor substring que contém todos os caracteres do padrão
    internal static class MinWindow
    {
        //metodo principal que implementa a lógica da janela deslizante
        public static string MinWindowSubstring(string str, string pattern)
        {
            // verifica casos de borda
            if (string.IsNullOrEmpty(str) || string.IsNullOrEmpty(pattern) || pattern.Length > str.Length)
                return string.Empty;

            // constrói o dicionário de contagem de caracteres do padrão
            var patternCount = BuildPatternCount(pattern);
            // inicializa o estado da janela deslizante
            var state = new MinWindowAux(pattern.Length, patternCount);

            // enquanto a janela direita não ultrapassar o final da string
            while (state.Right < str.Length)
            {
                char rightChar = str[state.Right];
                //se o caractere da direita estiver no dicionário de contagem do padrão, atualiza a contagem e o número de caracteres necessários
                if (state.PatternCount.ContainsKey(rightChar))
                {
                    if (state.PatternCount[rightChar] > 0)
                    {
                        // se o caractere ainda é necessário, decrementa o número de caracteres necessários
                        state.RequiredChars--;
                    }
                    // decrementa a contagem do caractere no dicionário
                    state.PatternCount[rightChar]--;
                }

                // enquanto a janela atual contém todos os caracteres necessários, tenta reduzir a janela pela esquerda
                while (state.RequiredChars == 0)
                {
                    // atualiza a melhor janela encontrada até agora
                    UpdateBestWindow(state);

                    char leftChar = str[state.Left];
                    if(state.PatternCount.ContainsKey(leftChar))
                    {
                        // se o caractere da esquerda estiver no dicionário, incrementa a contagem do caractere
                        state.PatternCount[leftChar]++;
                        // se a contagem do caractere for maior que zero, significa que ele é necessário novamente, então incrementa o número de caracteres necessários
                        if (state.PatternCount[leftChar] > 0)
                            state.RequiredChars++;
                    }

                    // move a janela pela esquerda para tentar encontrar uma janela menor
                    state.Left++;
                }

                // move a janela pela direita para expandir a janela
                state.Right++;
            }

            // se a menor janela encontrada for maior que a string original, significa que não foi encontrada uma janela válida, então retorna string vazia
            return state.MinLength > str.Length
                ? string.Empty
                : str.Substring(state.StartIndex, state.MinLength);
        }

        //metodo auxiliar para construir o dicionário de contagem de caracteres do padrão
        private static Dictionary<char, int> BuildPatternCount(string pattern)
        {
            var patternCount = new Dictionary<char, int>();

            foreach (char character in pattern)
            {
                if (patternCount.TryGetValue(character, out int count))
                    patternCount[character] = count + 1;
                else
                    patternCount[character] = 1;
            }

            return patternCount;
        }

        //metodo auxiliar para atualizar a melhor janela encontrada
        private static void UpdateBestWindow(MinWindowAux state)
        {
            int currentLength = state.Right - state.Left + 1;
            if (currentLength < state.MinLength)
            {
                state.MinLength = currentLength;
                state.StartIndex = state.Left;
            }
        }
    }
}
