using System.Text;

Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 3 - Puzzle 1");

//Solution logic goes here
string[] lines = System.IO.File.ReadAllLines("input.txt");

var counts = new Dictionary<int, int>();
for (int i = 0; i < lines.Length; i++)
{
    var split = lines[i].ToArray();
    for (var x = 0; x < split.Length; x++)
    {
        if (split[x] == '1')
        {
            if (counts.ContainsKey(x))
                counts[x] += 1;
            else counts[x] = 1;
        }
    }
}
StringBuilder sbGamma = new StringBuilder();
StringBuilder sbEpsilon = new StringBuilder();

for (var z = 0; z < counts.Count; z++)
{
    if (counts.ContainsKey(z) && counts[z] > lines.Length / 2)
    {
        sbGamma.Append("1");
        sbEpsilon.Append("0");
    }
    else
    {
        sbGamma.Append("0");
        sbEpsilon.Append("1");
    }
}

foreach (var item in counts.OrderBy(x=>x.Key))
{
    Console.WriteLine($"{item.Key}  {item.Value}");
}
Console.WriteLine(sbGamma.ToString());
Console.WriteLine(sbEpsilon.ToString());

var gamma = Convert.ToInt32(sbGamma.ToString(), 2);
var epsilon = Convert.ToInt32(sbEpsilon.ToString(), 2);

Console.WriteLine(gamma);
Console.WriteLine(epsilon);

Console.WriteLine(gamma * epsilon);

//Stop and wait for enter before exiting
Console.ReadLine();