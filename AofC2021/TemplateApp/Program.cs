Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 1 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

var counts = new Dictionary<int, int>();
for (int i = 0; i < lines.Length; i++)
{
    var split = lines[i].Split();
    for(var x= 0; x<split.Length; x++)
    {
        var val = 0;
        if (split[x] == "1")
        {
            counts.TryGetValue(x, out val);
            counts[x] += val;
        }
    }
}

foreach (var item in counts)
{
    Console.WriteLine($"{item.Key}  {item.Value}");
}


//Stop and wait for enter before exiting
Console.ReadLine();