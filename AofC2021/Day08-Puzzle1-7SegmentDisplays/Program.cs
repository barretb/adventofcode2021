Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 8 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

var counts = new Dictionary<int, int>();

foreach (var line in lines)
{
    var split = line.Split('|');
    var wires = split[0].Split(' ');
    var outputs = split[1].Split(' ');

    //focus on easy digits
    foreach (var output in outputs)
    {
        switch (output.Length)
        {
            case 2:
                //can only be a 1
                if (counts.ContainsKey(1))
                {
                    counts[1]++;
                }
                else
                {
                    counts[1] = 1;
                }
                break;
            case 3:
                //can only be a 7
                if (counts.ContainsKey(7))
                {
                    counts[7]++;
                }
                else
                {
                    counts[7] = 1;
                }
                break;
            case 4:
                //can only be a 4
                if (counts.ContainsKey(4))
                {
                    counts[4]++;
                }
                else
                {
                    counts[4] = 1;
                }
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                //can only be an 8
                if (counts.ContainsKey(8))
                {
                    counts[8]++;
                }
                else
                {
                    counts[8] = 1;
                }

                break;
            default:
                //should not get here
                break;
        }

    }
}

Console.WriteLine($"Total times we see 1, 4, 7 or 8: {counts[1] + counts[4] + counts[7] + counts[8] }");


//Stop and wait for enter before exiting
Console.ReadLine();

