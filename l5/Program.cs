using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


public class Program {
  static void Main(string[] args) {
    Dictionary<string, string[]> misspelledWords = new Dictionary<string, string[]> {
      { "привет", new string[] { "првиет", "пирвет", "приевт"} },
      { "пожалуйста", new string[] { "пожлауйста", "пожалусйта", "пожлуйста" } },
      { "спасибо", new string[] { "спаисбо", "спассбо", "сапсибо"} },
      { "конечно", new string[] { "коенчно", "коненчо", "конеечно"} }
    };

    Console.WriteLine(" Enter the path to folder: ");
    Console.Write(" ");
    string folderPath = Console.ReadLine();

    string[] files = DirectoryReader.GetTextFiles(folderPath);

    if (files == null) {
      return;
    }

    foreach (string filePath in files) {
      try {
        string content = File.ReadAllText(filePath);
        content = TextCorrector.ReplaceMisspelledWords(content, misspelledWords);
        content = TextCorrector.ReplacePhoneNumbers(content);
        File.WriteAllText(filePath, content);
      }
      catch {
        Console.WriteLine(" Error processing file. ");
      }
    }
  }
}


