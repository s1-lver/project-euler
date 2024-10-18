using System.Collections;

namespace _22_Names_Scores;

class Program
{
    static void Main(string[] args)
    {
        List<string> names = new List<string>();
        LoadNames(ref names, "C:\\Users\\angel\\Documents\\ProjectEuler\\22_Names_Scores\\names.txt");

        int totalScore = 0;
        for (int i = 0; i < names.Count; i++)
        {
            string name = names[i];
            Console.WriteLine(name);
            int subScore = 0;
            foreach (var letter in name)
            {
                
                subScore += letter;
                Console.WriteLine(subScore);
            }

            totalScore = subScore * (i + 1);
        }

        Console.WriteLine(totalScore);
    }

    static void LoadNames(ref List<string> names, string PATH)
    {
        string text = File.ReadAllText(PATH);
        text.Replace("\"", string.Empty);
        string[] splitText = text.Split(',');

        foreach (string name in splitText)
        {
            names.Add(name);
        }
        
        names.Sort();
        
    }
}