﻿using Chat.Enums;
using Chat.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Chat.Models.ClientSide.MessageTranslator
{
    /// <summary>Сlass that describes the ability to translate one message to another using some <see cref="Language"/> languages</summary>
    public class Translator : Dictionary<string, string>, IMessageTranslator
    {
        /// <summary>Creates a new instance by filling in the dictionary with the necessary data</summary>
        public Translator()
        {
            Add("а", "a");
            Add("б", "b");
            Add("в", "v");
            Add("г", "g");
            Add("д", "d");
            Add("е", "e");
            Add("ё", "yo");
            Add("ж", "zh");
            Add("з", "z");
            Add("и", "i");
            Add("й", "j");
            Add("к", "k");
            Add("л", "l");
            Add("м", "m");
            Add("н", "n");
            Add("о", "o");
            Add("п", "p");
            Add("р", "r");
            Add("с", "s");
            Add("т", "t");
            Add("у", "u");
            Add("ф", "f");
            Add("х", "h");
            Add("ц", "c");
            Add("ч", "ch");
            Add("ш", "sh");
            Add("щ", "sch");
            Add("ъ", "j");
            Add("ы", "i");
            Add("ь", "j");
            Add("э", "e");
            Add("ю", "yu");
            Add("я", "ya");

            Add("А", "A");
            Add("Б", "B");
            Add("В", "V");
            Add("Г", "G");
            Add("Д", "D");
            Add("Е", "E");
            Add("Ё", "Yo");
            Add("Ж", "Zh");
            Add("З", "Z");
            Add("И", "I");
            Add("Й", "J");
            Add("К", "K");
            Add("Л", "L");
            Add("М", "M");
            Add("Н", "N");
            Add("О", "O");
            Add("П", "P");
            Add("Р", "R");
            Add("С", "S");
            Add("Т", "T");
            Add("У", "U");
            Add("Ф", "F");
            Add("Х", "H");
            Add("Ц", "C");
            Add("Ч", "Ch");
            Add("Ш", "Sh");
            Add("Щ", "Sch");
            Add("Ъ", "J");
            Add("Ы", "I");
            Add("Ь", "J");
            Add("Э", "E");
            Add("Ю", "Yu");
            Add("Я", "Ya");

            Add(".", ".");
            Add("!", "!");
            Add("%", "%");
            Add(" ", " ");
            Add("-", "-");
            Add("/", "/");
            Add("\\", "\\");
            Add(")", ")");
            Add("(", "(");
            Add("{", "{");
            Add("}", "}");
        }

        /// <summary>Detecting the language from an incoming message</summary>
        /// <param name="message">The message to define the language for</param>
        /// <returns>Current language</returns>
        private Language LanguageDefinition(string message) => !Regex.IsMatch(message, @"\P{IsBasicLatin}") ? Language.English : Language.Russian;

        /// <inheritdoc cref="IMessageTranslator.TranslateMessage(string)"/>
        public string TranslateMessage(string message)
        {
            var builderString = new StringBuilder(message);
            var currentLanguage = LanguageDefinition(message);

            foreach (var pair in this)
            {
                builderString = currentLanguage switch
                {
                    Language.English => builderString.Replace(pair.Value, pair.Key),
                    Language.Russian => builderString.Replace(pair.Key, pair.Value),
                    _ => throw new NotSupportedException()
                };
            }
            return builderString.ToString();
        }
    }
}