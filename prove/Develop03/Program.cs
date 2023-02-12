using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureReference
{
    class Program
    {
        static void Main(string[] args)
        {
            // EXCEEDING REQUIREMENT  - Stores a library of scriptures instead of one
            List<ScriptureScripture> scriptureLibrary = new List<ScriptureScripture>();
            scriptureLibrary.Add(new ScriptureScripture(new ReferenceReference("John 3:16"), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."));
            scriptureLibrary.Add(new ScriptureScripture(new ReferenceReference("Matthew 5:16"), "In the same way, let your light shine before others, so that they may see your good works and give glory to your Father in heaven."));
            scriptureLibrary.Add(new ScriptureScripture(new ReferenceReference("Philippians 4:13"), "I can do all things through Christ who gives me strength."));
            
            //Multiple verses
            scriptureLibrary.Add(new ScriptureScripture(new ReferenceReference("Proverbs 3:5-6"), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."));

            //And a scripture is chosen at random from the library of scriptures - Exceeding requirement
            Random random = new Random();
            int scriptureIndex = random.Next(0, scriptureLibrary.Count);
            ScriptureScripture scripture = scriptureLibrary[scriptureIndex];

            // The program continues to hide more words in the scripture until all words are hidden
            while (scripture.GetRemainingWords() > 0)
            {
                scripture.Display();
                Console.WriteLine("Press enter to hide more words or type quit to end the program.");
                string userInput = Console.ReadLine();

                // The user can quit the program by typing "quit"
                if (userInput == "quit")
                {
                    break;
                }

                scripture.HideWords();
                Console.Clear();
            }
        }
    }

    class ReferenceReference
    {
        // Private variable to store the reference
        private string _referenceRef;
        private int _startVerse;
        private int _endVerse;

        // Constructor to initialize the reference for a single verse
        public ReferenceReference(string reference)
        {
            this._referenceRef = reference;
        }

        // Constructor to initialize the reference for a verse range
        public ReferenceReference(string reference, int startVerse, int endVerse)
        {
            this._referenceRef = reference + ":" + startVerse + "-" + endVerse;
            this._startVerse = startVerse;
            this._endVerse = endVerse;
        }

        // Method to return the reference
        public string GetReference()
        {
            return _referenceRef;
        }

        // Method to return the start verse of a verse range
        public int GetStartVerse()
        {
            return _startVerse;
        }

        // Method to return the end verse of a verse range
        public int GetEndVerse()
        {
            return _endVerse;
        }
    }


    class ScriptureScripture
    {
        // Private variables to store the reference and words of the scripture
        private ReferenceReference _referenceScripture;
        private List<WordWorded> _wordsScripture;
        private List<WordWorded> _hiddenWords;

        //The Scripture constructor has one constructor that takes the scripture reference and text as parameters
        public ScriptureScripture(ReferenceReference reference, string text)
        {
            this._referenceScripture = reference;
            this._wordsScripture = text.Split(' ').Select(x => new WordWorded(x)).ToList();
            this._hiddenWords = new List<WordWorded>();
        }

        // New constructor to handle a single verse
        public ScriptureScripture(string reference, string text)
        {
            this._referenceScripture = new ReferenceReference(reference);
            this._wordsScripture = text.Split(' ').Select(x => new WordWorded(x)).ToList();
            this._hiddenWords = new List<WordWorded>();
        }

        // New constructor to handle a verse range
        public ScriptureScripture(string startReference, string endReference, string text)
        {
            this._referenceScripture = new ReferenceReference(startReference + "-" + endReference);
            this._wordsScripture = text.Split(' ').Select(x => new WordWorded(x)).ToList();
            this._hiddenWords = new List<WordWorded>();
        }

        //The GetRemainingWords method returns the number of words in the scripture that have not been hidden
        public int GetRemainingWords()
        {
            return _wordsScripture.Count - _hiddenWords.Count;
        }

        //The Display method displays the scripture reference and text, with hidden words represented by square brackets
        public void Display()
        {
            Console.WriteLine(_referenceScripture.GetReference());
            foreach (WordWorded word in _wordsScripture)
            {
                if (_hiddenWords.Contains(word))
                {
                    Console.Write("___");
                }
                else
                {
                    Console.Write(word.GetWord() + " ");
                }
            }
            Console.WriteLine();
        }

        //The HideWords method hides a random word in the scripture
        public void HideWords()
        {
            Random random = new Random();
            int wordIndex = random.Next(0, _wordsScripture.Count - _hiddenWords.Count);
            int hiddenWordCount = 0;
            for (int i = 0; i < _wordsScripture.Count; i++)
            {
                if (!_hiddenWords.Contains(_wordsScripture[i]))
                {
                    if (hiddenWordCount == wordIndex)
                    {
                        _hiddenWords.Add(_wordsScripture[i]);
                        break;
                    }
                    hiddenWordCount++;
                }
            }
        }
    }





    class WordWorded
    {
        private string _wordWord;


        //The Word class has one constructor that takes the word as a parameter
        public WordWorded(string word)
        {
            this._wordWord = word;
        }

        //The GetWord method returns the word
        public string GetWord()
        {
            return _wordWord;
        }
    }
}