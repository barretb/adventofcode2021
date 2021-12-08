using System.Text;

Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 8 - Puzzle 2");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

var counts = new Dictionary<int, int>();

var total = 0;
foreach (var line in lines)
{
    var split = line.Split('|');
    var wires = split[0].Trim().Split(' ');
    var outputs = split[1].Trim().Split(' ');
    var conversion = new Dictionary<string, string>();

    //sort letters in pattern
    for (int i = 0; i < 10; i++)
    {
        wires[i] = String.Concat(wires[i].OrderBy(x => x));
    }

    for (int j = 0; j < 4; j++)
    {
        outputs[j] = String.Concat(outputs[j].OrderBy(x => x));
    }

    //Start identifying segments
    Array.Sort(wires, (x, y) => x.Length.CompareTo(y.Length));

    //start with known values
    conversion["1"] = wires[0];
    conversion["4"] = wires[2];
    conversion["7"] = wires[1];
    conversion["8"] = wires[9];


    var fiveSegs = new List<string>() { wires[3], wires[4], wires[5] };
    //pick 3 - it's the only 5 count segment with both elements of 1
    if (wires[3].Contains(wires[0].Substring(0, 1)) && wires[3].Contains(wires[0].Substring(1, 1)) && fiveSegs.Contains(wires[3]))
    {
        conversion["3"] = wires[3];
        fiveSegs.Remove(wires[3]);
    }
    else if (wires[4].Contains(wires[0].Substring(0, 1)) && wires[4].Contains(wires[0].Substring(1, 1)) && fiveSegs.Contains(wires[4]))
    {
        conversion["3"] = wires[4];
        fiveSegs.Remove(wires[4]);
    }
    else
    {
        conversion["3"] = wires[5];
        fiveSegs.Remove(wires[5]);
    }

    //pick 5 - it's the only 5 count segment that will have both the middelAndTopLeft values
    //First, grab the two segments in a 4 that aren't in a 1
    var middleAndTopLeft = wires[2].Except(wires[0]).ToList();
    if (wires[3].Contains(middleAndTopLeft[0]) && wires[3].Contains(middleAndTopLeft[1]))
    {
        conversion["5"] = wires[3];
        fiveSegs.Remove(wires[3]);
    }
    else if (wires[4].Contains(middleAndTopLeft[0]) && wires[4].Contains(middleAndTopLeft[1]))
    {
        conversion["5"] = wires[4];
        fiveSegs.Remove(wires[4]);
    }
    else
    {
        conversion["5"] = wires[5];
        fiveSegs.Remove(wires[5]);
    }

    //pick 2 - it's what's left of the 5 segment numbers
    conversion["2"] = fiveSegs.First();

    var sixSegs = new List<string>() { wires[6], wires[7], wires[8] };
    //pick 6 - it won't match both elements of 1
    if (wires[6].Except(wires[0]).Count() == 5)
    {
        conversion["6"] = wires[6];
        sixSegs.Remove(wires[6]);
    }
    else if (wires[7].Except(wires[0]).Count() == 5)
    {
        conversion["6"] = wires[7];
        sixSegs.Remove(wires[7]);
    }
    else
    {
        conversion["6"] = wires[8];
        sixSegs.Remove(wires[8]);
    }

    //pick 9 - it will match all elements of 4
    if (wires[6].Except(wires[2]).Count() == 2 && sixSegs.Contains(wires[6]))
    {
        conversion["9"] = wires[6];
        sixSegs.Remove(wires[6]);
    }
    else if (wires[7].Except(wires[2]).Count() == 2 && sixSegs.Contains(wires[7]))
    {
        conversion["9"] = wires[7];
        sixSegs.Remove(wires[7]);
    }
    else
    {
        conversion["9"] = wires[8];
        sixSegs.Remove(wires[8]);
    }

    //pick 0 - it's what's left
    conversion["0"] = sixSegs.First();

    StringBuilder answer = new StringBuilder();
    for (var z = 0; z < 4; z++)
    {
        if (conversion.ContainsValue(outputs[z]))
        {
            answer.Append(conversion.FirstOrDefault(x => x.Value == outputs[z]).Key);
        }
        else
        {
            throw new Exception("No match found");
        }
    }

    total += Convert.ToInt32(answer.ToString());
}

Console.WriteLine($"Total sum of outputs: {total}");

//Stop and wait for enter before exiting
Console.ReadLine();