using System;
using System.Collections.Generic;
using System.Text;

namespace SpellChecker
{
    interface IMethodsCompare
    {
        public string OneDeletingOrOneInserting(string ItemInputWord, string ItemLibrary);
        public string OneDeletingAndOneInserting(string ItemInputWord, string ItemLibrary);
        public string OneDeleteAndOneInsertForEqualLenght(string ItemInputWord, string ItemLibrary);
        public string TwoDeletingOrTwoInserting(string ItemInputWord, string ItemLibrary);

    }
}
