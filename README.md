# Project

The project has 2 classes and the main program
- WordFinder
- WordDetailDTO

## Clases
### WordFinder
This class is in charge of returning the words found in the array, otherwise it returns empty.
This class has 8 methods:
- Find
- GetTop10Words
- GetDetailsWords
- ConvertMatrixToChar
- AddWordCount
- NewWordToCount
- CountWord
- DepthFirstSearch

### Methods:
```c#
public IEnumerable<string> Find(IEnumerable<string> wordstream)
```
This public method is the main method of the class and returns the list of words found. It has as parameter the list of words to search.

```c#
private IEnumerable<string> GetTop10Words(IEnumerable<WordDetailDTO> wordDetails, IEnumerable<string> wordstream)
```
This private method returns the list of words sorted by number of times found. It has as parameter an IEnumerable of the WordDetailDTO where the positions of the words in the main array and the number of times that word is repeated are found.

```c#
private IList<WordDetailDTO> GetDetailsWords(IEnumerable<string> words)
```
This private method returns to the Find method the DTO List with the data of the words found (Position and quantity).
It has as parameter the words to search for.

```c#
private char[][] ConvertMatrixToChar(IEnumerable<string> matrix)
```
This private method returns the main array converted to char. This conversion makes it easier to search the array for each character that makes up a word.

```c#
private WordDetailDTO AddWordCount(IEnumerable<string> words, int i, char[][] matixChar)
```
This private method returns a WordDetailDTo where if it found any word it returns the position and the amount, otherwise it returns the DTO with 0 and 0.
It has as parameter the words to search, the current position index and the main array.

```c#
private bool NewWordToCount(int j, IEnumerable<string> words)
```
This private method. It returns a boolean value depending if the word to search for has been searched before or it is the first time.
It has as parameter an index to know where the search is and the IEnumerable with the words to search.

```c#
private int CountWord(string word, char[][] matrixChar)
```
This private method. Returns an int with the number of words found in the array.
It has as parameters the word to search and the array converted to char array.

```c#
private bool DepthFirstSearch(char[][] matixChar, int i, int j, int count, string word)
```
This private method. This recursive search method returns a boolean, where if the value is true, it means that there is a match, otherwise it is false.
It has as parameters the main array in char, the indexes i and j, counter and searched word.
