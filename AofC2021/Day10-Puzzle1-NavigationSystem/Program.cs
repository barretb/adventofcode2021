using System.Text.RegularExpressions;

Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 10 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");
var points = 0;
for(int i = 0; i < lines.Length; i++)
{
    var line = lines[i];

    //first, clean out all possible matches
    var foundMatches = true;
    while(foundMatches)
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
        //CORRUPTED
        Match match = Regex.Match(line, @"[\]\}\)\>]", RegexOptions.None);
        if (match.Success)
        {
            var m = match.Groups[0].Value;
            if (m == ")") points += 3;
            if (m == "]") points += 57;
            if (m == "}") points += 1197;
            if (m == ">") points += 25137;            
        }
    }
    //Otherwise it's incomplete. Do nothing for now
}

Console.WriteLine($"Total Points: {points}");

//Stop and wait for enter before exiting
Console.ReadLine();