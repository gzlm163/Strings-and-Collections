using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.IO;

public static class TextCorrector {
  public static string ReplaceMisspelledWords(string originalText, Dictionary<string, string[]> misspelledWords) {
    string modifiedText = originalText;

    foreach (string correctWord in misspelledWords.Keys) {
      string[] wrongVariants = misspelledWords[correctWord];

      foreach (string wrongWord in wrongVariants) {
        modifiedText = modifiedText.Replace(wrongWord, correctWord);
      }
    }

    return modifiedText;
  }

  public static string ReplacePhoneNumbers(string originalText) {
    string phonePattern = @"\(0(\d{2})\) (\d{3})-(\d{2})-(\d{2})";
    string newPhoneFormat = "+380 $1 $2 $3 $4";

    return Regex.Replace(originalText, phonePattern, newPhoneFormat);
  }

}
