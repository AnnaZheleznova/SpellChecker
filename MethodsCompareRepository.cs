using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpellChecker
{
    class MethodsCompareRepository : IMethodsCompare
    {
        public string OneDeleteAndOneInsertForEqualLenght(string ItemInputWord, string ItemLibrary)
        {
            string inputWords = ItemInputWord.ToLower();
            string library = ItemLibrary.ToLower();
            int count = 0;
            int indexOfInputWord;

            for (int i = 0; i < library.Length; i++) //check each letter in word for dictionary
            {
                char elementOfLibrary = library.ElementAt(i);
                indexOfInputWord = inputWords.IndexOf(elementOfLibrary);

                if (indexOfInputWord >= 0)
                {
                    count += 1;//if there is the letter  in "InputWord"  - count increases 

                    if (count == library.Length && inputWords.Length == library.Length)  //one deleting and one inserting
                    {
                        return ItemLibrary;
                    }
                }
            }
            return null;
        }

        public string OneDeletingAndOneInserting(string ItemInputWord, string ItemLibrary)
        {
            string inputWords = ItemInputWord.ToLower();
            string library = ItemLibrary.ToLower();
            int count = 0;
            int indexOfInputWord;

            for (int i = 0; i < library.Length; i++) //check each letter in word for dictionary
            {
                char elementOfLibrary = library.ElementAt(i);
                indexOfInputWord = inputWords.IndexOf(elementOfLibrary);

                if (indexOfInputWord >= 0) 
                {
                    count += 1;//if there is the letter  in "InputWord"  - count increases 

                    if ((count == library.Length - 1 && inputWords.Length == library.Length) ||
                        (count == library.Length && inputWords.Length == library.Length))  //one deleting and one inserting
                    {
                        return ItemLibrary;
                    }
                }
            }
            return null;
        }

        public string OneDeletingOrOneInserting(string ItemInputWord, string ItemLibrary)
        {
            string inputWords = ItemInputWord.ToLower();
            string library = ItemLibrary.ToLower();
            int count = 0;
            int indexOfInputWord;

            for (int i = 0; i < library.Length; i++) //check each letter in word for dictionary
            {
                char elementOfLibrary = library.ElementAt(i);
                indexOfInputWord = inputWords.IndexOf(elementOfLibrary);

                if (indexOfInputWord >= 0)
                {
                    count += 1;//if there is the letter  in "InputWord"  - count increases 

                    if ((count == library.Length && inputWords.Length == library.Length + 1) ||
                        (count == library.Length - 1 && inputWords.Length == library.Length - 1))
                    {
                        return ItemLibrary;
                    }
                }
            }
            return null;
        }

        public string TwoDeletingOrTwoInserting(string ItemInputWord, string ItemLibrary)
        {
            string inputWords = ItemInputWord.ToLower();
            string library = ItemLibrary.ToLower();
            int count = 0;
            int indexOfLibrary;
            char elementOfInputWord;

            for (int i = 0; i < inputWords.Length; i++)//check each letter in word for "InputWord"
            {
                elementOfInputWord = inputWords.ElementAt(i);
                indexOfLibrary = library.IndexOf(elementOfInputWord);

                if (indexOfLibrary < 0)
                {
                    count += 1;//if there is no letter  in dictionary(library) - count increases 

                    if (count == inputWords.Length - library.Length && count == 2 && inputWords.Length == library.Length + 2)  //two inserting or two inserting
                    {
                        char elementOfInputWordTwo = inputWords.ElementAt(i - 1);
                        indexOfLibrary = library.IndexOf(elementOfInputWordTwo);
                        if (indexOfLibrary > 0)
                        {
                            return ItemLibrary;
                        }
                    }

                }
            }

            for (int i = 0; i < library.Length; i++)//check each letter in word for dictionary
            {
                char elementOfLibrary = library.ElementAt(i);
                int indexOfInputWord = inputWords.IndexOf(elementOfLibrary);

                if (indexOfInputWord < 0)
                {
                    count += 1;//if there is no letter  in "InputWord"  - count increases 

                    if (count == library.Length - inputWords.Length && count == 2 && inputWords.Length == library.Length - 2)
                    {
                        char elementOfLibraryTwo = library.ElementAt(i - 1);
                        indexOfInputWord = library.IndexOf(elementOfLibraryTwo);
                        if (indexOfInputWord > 0)
                        {
                            return ItemLibrary;
                        }

                    }

                }
            }

            return null;
        }
    }
}
