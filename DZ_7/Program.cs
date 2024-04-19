using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometricFigures
{
    class Triangle
    {
        public int size { get; set; }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size - i - 1; j++)
                {
                    s+= "  ";
                }
                for (int j = 0; j < 2 * i + 1; j++)
                {
                    s += "* ";
                }
                s += '\n';
            }
            return s;
        }
    }

    class Rectangle
    {
        public int width { get; set; }
        public int height { get; set; }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    s += "* ";
                }
                s += '\n';
            }
            return s;
        }
    }

    class Square
    {
        public int size { get; set; }
        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    s += "* ";
                }
                s += '\n';
            }
            return s;
        }
    }
}

namespace GuessTheNumberGame 
{
    class Game 
    {
        public int start_diapozone {  get; set; }
        public int end_diapozone { get;  set; }

        public void Start() 
        {
            int num;
            do
            {
                Console.Write($"Enter random number in diapozone {start_diapozone}, {end_diapozone}: ");
                Int32.TryParse( Console.ReadLine(), out num );
            }while( num > end_diapozone || num < start_diapozone );

            Random random = new Random();
            int BotNum = 0;
            do
            {
                BotNum = random.Next(start_diapozone, end_diapozone+1);
                Console.WriteLine($"Bot Num: {BotNum}");
            } while (BotNum != num);
            Console.WriteLine("Bot guessed right");
        }
    }
}

namespace PseudoTextGenerator 
{
    class WordGenerator
    {
        private static Random random = new Random();

        public string GenerateWord(int vowelsCount, int consonantsCount)
        {
            StringBuilder word = new StringBuilder();
            word.Append("");

            for (int i = 0; i < vowelsCount; i++)
            {
                word.Append(GetRandomVowel());
            }

            for (int i = 0; i < consonantsCount; i++)
            {
                word.Append(GetRandomConsonant());
            }

            return Shuffle(word.ToString());
        }

        private char GetRandomVowel()
        {
            string vowels = "aeiou";
            return vowels[random.Next(vowels.Length)];
        }

        private char GetRandomConsonant()
        {
            string consonants = "bcdfghjklmnpqrstvwxyz";
            return consonants[random.Next(consonants.Length)];
        }

        private string Shuffle(string input)
        {
            char[] characters = input.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                int randomIndex = random.Next(i, characters.Length);
                char temp = characters[i];
                characters[i] = characters[randomIndex];
                characters[randomIndex] = temp;
            }
            return new string(characters);
        }
    }

    class TextGenerator
    {
        private WordGenerator wordGenerator = new WordGenerator();

        public string GenerateText(int maxWordLength, int vowelsCount, int consonantsCount)
        {
            StringBuilder text = new StringBuilder();
            int wordCount = (int)Math.Ceiling((double)((vowelsCount + consonantsCount)/maxWordLength));
            int vovelsInWord = vowelsCount / wordCount; 
            int consonantsInWord = maxWordLength - vovelsInWord;
            int lastVovelsInWord = vowelsCount - vovelsInWord * wordCount;
            int lastConsonantsInWord = consonantsCount - consonantsInWord * wordCount;
            if (lastConsonantsInWord + lastVovelsInWord > maxWordLength)
            {
                lastConsonantsInWord -= (lastVovelsInWord + lastConsonantsInWord) - maxWordLength;
            }

            Random random = new Random();

            for (int i = 0; i < wordCount-1; i++)
            {
                text.Append(wordGenerator.GenerateWord(vovelsInWord, consonantsInWord));
                text.Append(" ");
            }
            text.Append(wordGenerator.GenerateWord(lastVovelsInWord, lastConsonantsInWord));
            return text.ToString().Trim();
        }
    }

}

namespace DZ_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GeometricFigures.Triangle triangle = new GeometricFigures.Triangle {size = 9 };
            Console.WriteLine(triangle);
            GeometricFigures.Rectangle rectangle = new GeometricFigures.Rectangle { width = 4, height = 2 };
            Console.WriteLine(rectangle);
            GeometricFigures.Square square = new GeometricFigures.Square { size = 5 };
            Console.WriteLine(square);

            GuessTheNumberGame.Game game = new GuessTheNumberGame.Game 
            {
                start_diapozone = 0,
                end_diapozone= 6,
            };
            game.Start();

            PseudoTextGenerator.TextGenerator textGenerator = new PseudoTextGenerator.TextGenerator();  
            Console.WriteLine(textGenerator.GenerateText(5, 8, 15));
        }
    }
}
