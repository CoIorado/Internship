using System;
using System.Collections.Generic;
using System.Text;

namespace Intership
{
    class Cryptography
    {
        public static string Encrypt(string text, int bias = 1)
        {
            if (bias < 1)
            {
                throw new NonNaturalNumberException(nameof(bias));
            }

            for (int i = 0; i < bias; i++)
            {
                text = Encrypt(text);
            }

            return text;
        }

        public static string Decrypt(string text, int bias = 1)
        {
            if (bias < 1)
            {
                throw new NonNaturalNumberException(nameof(bias));
            }

            for (int i = 0; i < bias; i++)
            {
                text = Decrypt(text);
            }

            return text;
        }

        private static string Encrypt(string text)
        {
            List<string> alphabet = new List<string> {"а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й",
                                                      "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф",
                                                      "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"};

            foreach (char letter in text)
            {
                if (alphabet.Contains(letter.ToString().ToLower()))
                    text = text.Replace(letter.ToString(), letter.ToString() + "i");
            }

            while (text.Contains("ii"))
                text = text.Replace("ii", "i");

            text = text.Replace(alphabet[^1] + "i", alphabet[0]);
            text = text.Replace(alphabet[^1].ToUpper() + "i", alphabet[0].ToUpper());

            for (int i = 0; i < alphabet.Count - 1; i++)
            {
                text = text.Replace(alphabet[i] + "i", alphabet[i + 1]);
                text = text.Replace(alphabet[i].ToUpper() + "i", alphabet[i + 1].ToUpper());
            }

            return text;
        }

        private static string Decrypt(string text)
        {
            List<string> alphabet = new List<string> {"а", "б", "в", "г", "д", "е", "ё", "ж", "з", "и", "й",
                                                      "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф",
                                                      "х", "ц", "ч", "ш", "щ", "ъ", "ы", "ь", "э", "ю", "я"};

            foreach (char letter in text)
            {
                if (alphabet.Contains(letter.ToString().ToLower()))
                    text = text.Replace(letter.ToString(), letter.ToString() + "i");
            }

            while (text.Contains("ii"))
                text = text.Replace("ii", "i");

            text = text.Replace(alphabet[0] + "i", alphabet[^1]);
            text = text.Replace(alphabet[0].ToUpper() + "i", alphabet[^1].ToLower().ToUpper());

            for (int i = 1; i < alphabet.Count; i++)
            {
                text = text.Replace(alphabet[i] + "i", alphabet[i - 1]);
                text = text.Replace(alphabet[i].ToUpper() + "i", alphabet[i - 1].ToUpper());
            }

            return text;
        }
    }
}
