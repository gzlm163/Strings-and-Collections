using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class DirectoryReader {
  public static string[] GetTextFiles(string folderPath) {
    try {
      return Directory.GetFiles(folderPath, "*.txt");
    }
    catch {
      Console.WriteLine("Error: cannot access the specified folder or files.");

      return null;
    }
  }
}