using System.Text;
using System.Text.RegularExpressions;

Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 10 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");
var points = new List<ulong>();
for (int i = 0; i < lines.Length; i++)
{
    var line = lines[i];
    var fixedline = new StringBuilder();
    fixedline.Append(line);

    //first, clean out all possible matches
    var foundMatches = true;
    while (foundMatches)
    {
        foundMatches = false;

        if (line.Contains("<>") || line.Contains("[]") || line.Contains("{}") || line.Contains("()")) foundMatches = true;
        line = line.Replace("<>", "");
        line = line.Replace("[]", "");
        line = line.Replace("{}", "");
        line = line.Replace("()", "");
    }

    if (line.Contains(">") || line.Contains("]") || line.Contains("}") || line.Contains(")"))
    {
        //CORRUPTED - discard
    }
    else
    {
        ulong linepoints = 0;
        //Otherwise it's incomplete. Fix the line
        for (var j = line.Length - 1; j >= 0; j--)
        {
            switch (line[j])
            {
                case '(':
                    fixedline.Append(")");
                    linepoints = (linepoints * 5) + 1;
                    break;
                case '[':
                    fixedline.Append("]");
                    linepoints = (linepoints * 5) + 2;
                    break;
                case '{':
                    fixedline.Append("}");
                    linepoints = (linepoints * 5) + 3;
                    break;
                case '<':
                    fixedline.Append(">");
                    linepoints = (linepoints * 5) + 4;
                    break;
            }
        }

        points.Add(linepoints);
    }
}

//Find the middle points
var score = points.OrderBy(x => x).Skip((points.Count / 2)).First();

Console.WriteLine($"Total Points: {score}");

//Stop and wait for enter before exiting
Console.ReadLine();