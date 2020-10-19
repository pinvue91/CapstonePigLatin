using System;
using System.Collections.Generic;
using System.Linq;

namespace CapstonePigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;

            while (runProgram)
            {

                string userWord;
                do
                {
                    Console.Clear();
                    Console.Write("Hello. Welcome to the Pig Latin Translator.\nPlease enter a word or sentence to be translated: ");
                    userWord = Console.ReadLine().ToLower().Trim();
                }
                while (string.IsNullOrEmpty(userWord));

                List<string> newWords = new List<string>();

                Console.WriteLine();

                foreach (string word in userWord.Split(' '))
                {
                    string pigLatinWord = PigLatinTranslator(word);
                    newWords.Add(pigLatinWord);
                }

                string result = string.Join(" ", newWords);

                Console.WriteLine(result);

                Console.WriteLine();


                //ask user if they want to continue?

                bool yesNoValid = false;
                while (yesNoValid == false)
                {

                    Console.Write("Would you like to translate another word (y/n)? ");
                    string yesNo = Console.ReadLine().ToLower();

                    if (yesNo == "y")
                    {
                        Console.Clear();
                        yesNoValid = true;
                    }
                    else if (yesNo == "n")
                    {
                        Console.Clear();
                        Console.WriteLine("Thank you. Have a nice day!");
                        yesNoValid = true;
                        runProgram = false;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Invalid Input!");
                    }


                }


            }   
        }

        

        //method to see if char is a vowel
        public static bool IsVowel (char wordArray)
        {

        bool isVowel = "aeiou".IndexOf(wordArray) >= 0;

        return isVowel;

        }


        //method to translate to pig latin

        public static string PigLatinTranslator(string userWord)
        {
            char[] wordArray = userWord.ToCharArray();
            char firstLetterChar = char.Parse(userWord.Substring(0, 1)); //converting 1st letter of word to char
            string[] vowels = { "a", "e", "i", "o", "u" };
            List<int> posOfVowels = new List<int>();

            //if first letter is vowel, just add "way" to end
                if (IsVowel(firstLetterChar) == true)
            {
                string newWord = userWord + "way";
                return newWord;

            }

            //if first letter is not vowel, then cut off word until you get to a vowel, add that to end, and also add "ay" to end
            else if (IsVowel(firstLetterChar) == false)
            {
                foreach (var letter in vowels)
                {

                    int vowelPosition = userWord.IndexOf(letter);

                    if (vowelPosition > 0)
                    {
                        posOfVowels.Add(vowelPosition);
                    }

                }

                int[] posOfVowelsArray = posOfVowels.ToArray();

                //if no vowels, return userWord & "ay"
                if (posOfVowelsArray.Length == 0)
                {
                    string newWord = userWord + "ay";
                    return newWord;
                }

                string firstConsonants = userWord.Substring(0, posOfVowelsArray.Min());

                string remainingWord = userWord.Substring(posOfVowelsArray.Min(), userWord.Length - posOfVowelsArray.Min());

                string pigLatinWord = remainingWord + firstConsonants + "ay";

                return pigLatinWord;

            }

            else
            {
                return userWord;
            }

        }


    }
}
