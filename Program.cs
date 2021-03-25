using System;
using System.Collections.Generic;
using System.Linq;
namespace SpellChecker
{
    public class Program
    {
        private readonly IMethodsCompare _methodsCompare;

        public Program()
        {
            _methodsCompare = new MethodsCompareRepository();
        }
        public static void Main(string[] args)
        {
            Program program = new Program();
            program.Compare();
        }
        private void Compare() 
        {
            List<string> libraryInput = new List<string>();//list of input dictionary lines
            List<string> library = new List<string>(); //list of split dictionary by word

            List<string> inputWordInput = new List<string>(); //list of input text lines
            List<string> inputWord = new List<string>();//list of splic text lines by word

            List<string> compare = new List<string>(); //list of finding words

            string oneDeletingOrOneInserting;  //finding word by method OneDeletingOrOneInserting
            string oneDeletingAndOneInserting; //finding word by method OneDeletingAndOneInserting
            string twoDeletingOrTwoInserting; //finding word by method TwoDeletingOrTwoInserting
            string oneDeleteAndOneInsertForEqualLenght; //finding word by method OneDeleteAndOneInsertForEqualLenght


            foreach (var libr in CreateList(libraryInput))// initialize list "Dictionary"  
            {
                string[] words = libr.Split(" ");
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length <= 50)
                    {
                        library.Add(words[i]);
                    }
                    else
                    {
                        Console.WriteLine($"'{words[i]}' - more then 50 characters");
                    }
                }
            }
            foreach (var input in CreateList(inputWordInput)) //initialize list "Input words"
            {
                string[] words = input.Split(" ");
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length <= 50)
                    {
                        inputWord.Add(words[i]);
                    }
                    else
                    {
                        Console.WriteLine($"'{words[i]}' - more then 50 characters");
                    }
                }
                Compare(library, inputWord, compare, out oneDeletingOrOneInserting, out oneDeletingAndOneInserting, out twoDeletingOrTwoInserting, out oneDeleteAndOneInsertForEqualLenght);
                Console.WriteLine();
                inputWord.Clear();
            }
        }

        private void Compare(List<string> library, List<string> inputWord, List<string> compare, out string oneDeletingOrOneInserting, out string oneDeletingAndOneInserting, out string twoDeletingOrTwoInserting, out string oneDeleteAndOneInsertForEqualLenght)
        {
            oneDeletingOrOneInserting = "";
            oneDeletingAndOneInserting = "";
            twoDeletingOrTwoInserting = "";
            oneDeleteAndOneInsertForEqualLenght = "";

            foreach (var ItemInputWord in inputWord) //check foreach input word 
            {
                if (library.Any(l => l.ToLower() == ItemInputWord.ToLower()))//correct word
                {
                    Console.Write(ItemInputWord + " ");
                }
                else
                {
                    foreach (var ItemLibrary in library) //correct word by finding words in the dictionary equals lenght  and equals character
                    {
                        if (ItemInputWord.Length == ItemLibrary.Length)
                        {
                            oneDeleteAndOneInsertForEqualLenght = _methodsCompare.OneDeleteAndOneInsertForEqualLenght(ItemInputWord, ItemLibrary);

                            if (oneDeleteAndOneInsertForEqualLenght != null)
                            {
                                compare.Add(oneDeleteAndOneInsertForEqualLenght);
                            }
                        }
                    }

                    if (compare.Count == 0)
                    {
                        foreach (var ItemLibrary in library) //correct word by finding words in the dictionary difference by 1 character
                        {
                            if ((ItemInputWord.Length == ItemLibrary.Length + 1) || (ItemInputWord.Length == ItemLibrary.Length - 1))
                            {
                                oneDeletingOrOneInserting = _methodsCompare.OneDeletingOrOneInserting(ItemInputWord, ItemLibrary);

                                if (oneDeletingOrOneInserting != null)
                                {
                                    compare.Add(oneDeletingOrOneInserting);
                                }
                            }
                        }
                    }
                    if (compare.Count == 0)
                    {
                        foreach (var ItemLibrary in library) //correct word by finding words in the dictionary equals lenght  and difference by 1 character
                        {
                            if (ItemInputWord.Length == ItemLibrary.Length)
                            {
                                oneDeletingAndOneInserting = _methodsCompare.OneDeletingAndOneInserting(ItemInputWord, ItemLibrary);

                                if (oneDeletingAndOneInserting != null)
                                {
                                    compare.Add(oneDeletingAndOneInserting);
                                }
                            }
                        }
                    }
                    if (compare.Count == 0)
                    {
                        foreach (var ItemLibrary in library) //correct word by finding words in the dictionary difference by 2 character
                        {
                            if ((ItemInputWord.Length == ItemLibrary.Length + 2) || (ItemInputWord.Length == ItemLibrary.Length - 2))
                            {
                                twoDeletingOrTwoInserting = _methodsCompare.TwoDeletingOrTwoInserting(ItemInputWord, ItemLibrary);

                                if (twoDeletingOrTwoInserting != null)
                                {
                                    compare.Add(twoDeletingOrTwoInserting);
                                }
                            }
                        }
                    }
                    if (compare.Count > 1)
                    {
                        Console.Write("{ ");
                        foreach (var item in compare) //print if finding more 1 variations of word
                        {
                            Console.Write(item + " ");
                        }
                        Console.Write("} ");
                    }
                    if (compare.Count == 1)
                    {
                        foreach (var item in compare) //print if finding 1 word
                        {
                            Console.Write(item + " ");
                        }
                    }
                    if (compare.Count == 0) //print if not finding word
                    {
                        Console.Write("{ " + ItemInputWord + "?} ");
                    }
                    compare.Clear();

                }
            }
        }

        public static List<string> CreateList(List<string> Input)
        {
            string line;
            do
            {
                line = Console.ReadLine();
                if (line != "===")
                {
                    Input.Add(line);
                }
            }
            while (line != "===");
            return Input;
        }
    }
}