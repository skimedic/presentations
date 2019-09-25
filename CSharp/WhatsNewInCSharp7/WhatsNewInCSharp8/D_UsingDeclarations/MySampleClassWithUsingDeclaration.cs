using System.Collections.Generic;

namespace WhatsNewInCSharp8.D_UsingDeclarations
{
    public class MySampleClassWithUsingDeclaration
    {
        static void WriteLinesToFile(IEnumerable<string> lines)
        {
            using var file = new System.IO.StreamWriter("WriteLines1.txt");
            foreach (string line in lines)
            {
                // If the line doesn't contain the word 'Second', write the line to the file.
                if (!line.Contains("Second"))
                {
                    file.WriteLine(line);
                }
            }
            // file variable is disposed here
        }
        static void WriteLinesToFileOldWay(IEnumerable<string> lines)
        {
            using (var file = new System.IO.StreamWriter("WriteLines2.txt"))
            {
                foreach (string line in lines)
                {
                    // If the line doesn't contain the word 'Second', write the line to the file.
                    if (!line.Contains("Second"))
                    {
                        file.WriteLine(line);
                    }
                }
            } // file variable is disposed here
        }
    }
}
