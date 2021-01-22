using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1
{

    public class InputText
    {
        protected List<char> InputTextInChars { get; set; }

        public InputText(string input)
        {
            AddTextToCharArray(input);
        }

        public void DisplayOutput()
        {

            OrderChars(); /*Orders chars*/

            Console.Write("output: ");
            InputTextInChars.ForEach(chhar => { Console.Write($"{chhar}"); });

            Console.ReadKey();
        }

        private void OrderChars()
        {
            InputTextInChars = InputTextInChars.OrderBy(c => c).ToList();
        }

        private void AddTextToCharArray(string input)
        {
            InputTextInChars = new List<char>();

            input.SplitTextToListOfStrings().ForEach(
                str =>
                  {
                      InputTextInChars.AddRange(str.RemoveSpecialCharacters().ToCharArray());
                  });
        }

    }

    public static class Extensions
    {
        public static string RemoveSpecialCharacters(this string input)
        {
            return Regex.Replace(input, @"[^0-9a-zA-Z\._]", string.Empty);
        }

        public static List<string> SplitTextToListOfStrings(this string input)
        {
            return input.ToLower().Split(' ').ToList();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your input");

            string inputText = Console.ReadLine();

            var obj = new InputText(inputText);

            obj.DisplayOutput();
        }
    }
}
