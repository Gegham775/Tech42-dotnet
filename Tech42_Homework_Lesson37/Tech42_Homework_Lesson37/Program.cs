using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tech42_Homework_Lesson37
{
    class Program
    {
        static void Main(string[] args)
        {
             ArmenianPlates.GetPlates("licenseplates.txt");
             Passport.ReplaceSerialNumber("userdata.txt");
            MathProblems.FindMathExpression("math.txt");
        }
    }
    public class ArmenianPlates
    {
        public static void GetPlates(string path)
        {
            string text = File.ReadAllText(path);
            var pattern = "\\d{2}[A-Z]{2}\\d{3}";
            var regex = new Regex(pattern);
            Console.WriteLine("Armenian License Plates:");
            foreach (Match match in regex.Matches(text))
            {
                Console.WriteLine(match.Value);
            }
        }
    }
    public class Passport
    {
        public static void ReplaceSerialNumber(string path)
        {
            string fileText = File.ReadAllText(path);
            var pattern = "([A-Z]{2})(\\d{7})";
            var regex = new Regex(pattern);
            foreach (Match match in regex.Matches(fileText))
            {
                fileText = fileText.Replace(match.Groups[2].Value, "*******");
            }
            Console.WriteLine($"\nPassports:\n{fileText}");
        }
    }
    public class MathProblems
    {
        public static void FindMathExpression(string path)
        {
            string fileText = File.ReadAllText(path);
            var pattern = "(\\d+)(\\+|\\-|\\/|\\*)(\\d+)";
            var regex = new Regex(pattern);
            int a = 0;
            string expression = null;
            foreach (Match match in regex.Matches(fileText))
            {
                expression = match.Groups[2].Value;
                switch (expression)
                {
                    case "+":
                        a = int.Parse(match.Groups[1].Value) + int.Parse(match.Groups[3].Value);
                        fileText = fileText.Replace(match.Groups[0].Value, $"{match.Groups[0].Value}={a}");
                        break;
                    case "-":
                        a = int.Parse(match.Groups[1].Value) - int.Parse(match.Groups[3].Value);
                        fileText = fileText.Replace(match.Groups[0].Value, $"{ match.Groups[0].Value}={a}");
                        break;
                    case "/":
                        a = int.Parse(match.Groups[1].Value) / int.Parse(match.Groups[3].Value);
                        fileText = fileText.Replace(match.Groups[0].Value, $"{ match.Groups[0].Value}={a}");
                        break;
                    case "*":
                        a = int.Parse(match.Groups[1].Value) * int.Parse(match.Groups[3].Value);
                        fileText = fileText.Replace(match.Groups[0].Value, $"{ match.Groups[0].Value}={a}");       
                        break;
                }        
            }
            Console.WriteLine(fileText);
        }
    }
}
