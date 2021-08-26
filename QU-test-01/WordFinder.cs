using System.Collections.Generic;
using System.Linq;

namespace QU_test_01
{
    public class WordFinder
    {
        private IEnumerable<string> _matrix;
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix;
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            IEnumerable<WordDetailDTO> wordDetails = GetDetailsWords(wordstream);

            IEnumerable<string> top10Words = Enumerable.Empty<string>();

            if (wordDetails.Any())
            {
                top10Words = GetTop10Words(wordDetails.OrderByDescending(w => w.Count), wordstream);
            } 

            return top10Words;
        }

        private IEnumerable<string> GetTop10Words(IEnumerable<WordDetailDTO> wordDetails, IEnumerable<string> wordstream)
        {
            List<string> top10Words = new List<string>();

            for (int i = 0; i < wordDetails.Count(); i++)
            {
                var position = wordDetails.ElementAt(i).Position;
                top10Words.Add(wordstream.ElementAt(position));
            }

            return top10Words;

        }


        private IList<WordDetailDTO> GetDetailsWords(IEnumerable<string> words)
        {
            List<WordDetailDTO> wordDetails = new List<WordDetailDTO>();

            var matixChar = ConvertMatrixToChar(_matrix);

            WordDetailDTO wordDetail = new WordDetailDTO(0, 0);

            for (int i = 0; i< words.Count(); i++)
            {

                if (NewWordToCount(i, words))
                    wordDetail = AddWordCount(words, i, matixChar);

                if (wordDetail.Count > 0)
                    wordDetails.Add(wordDetail);
            }
            return wordDetails;
        }

        private char[][] ConvertMatrixToChar(IEnumerable<string> matrix)
        {
            int MaxRow = 64;
            int MaxCol = 64;

            char[][] charResult = new char[MaxRow][];
            for (int i = 0; i < MaxRow; ++i)
                charResult[i] = new char[MaxCol];

            for (int i = 0; i < matrix.Count(); i++)
            {
                char[] wordChar = matrix.ElementAt(i).ToCharArray();
                for (int j = 0; j < wordChar.Length; j++)
                {
                    charResult[i][j] = wordChar[j];
                };
            }

            return charResult;

        }

        private WordDetailDTO AddWordCount(IEnumerable<string> words, int i, char[][] matixChar)
        {
            var count = CountWord(words.ElementAt(i), matixChar);

            return count > 0 ? new WordDetailDTO(i, count) : new WordDetailDTO(0, 0);
        }

        private bool NewWordToCount(int j, IEnumerable<string> words)
        {
            bool notExist = true;

            for (int i = 0; i <= j-1; i++)
            {
                if (notExist)
                    notExist = words.ElementAt(i) != words.ElementAt(j);
                else
                    return notExist;
                    
            }
            return notExist;
        }

        private int CountWord(string word, char[][] matrixChar)
        {

            var matrixCharTemp = matrixChar;

            int count = 0;
            for (int i = 0; i < matrixChar.Length; i++)
            {
                for (int j = 0; j < matrixChar[i].Length; j++)
                {
                    if (matrixChar[i][j] == word[0] && DepthFirstSearch(matrixCharTemp, i, j, 0, word))
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private bool DepthFirstSearch(char[][] matixChar, int i, int j, int count, string word)
        {
            if (count == word.Length)
            {
                return true;
            }

            if (i < 0 || i >= matixChar.Length || j < 0 || j >= matixChar[i].Length || matixChar[i][j] != word.ElementAt(count))
            {
                return false;
            }

            char temp = matixChar[i][j];
            matixChar[i][j] = ' ';
            bool found = DepthFirstSearch(matixChar, i + 1, j, count + 1, word)
                      || DepthFirstSearch(matixChar, i, j + 1, count + 1, word);

            matixChar[i][j] = temp;
            return found;
        }
    }
}
