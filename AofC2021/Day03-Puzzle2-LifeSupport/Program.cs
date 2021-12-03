Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 3 - Puzzle 1");

//Solution logic goes here
string[] lines = System.IO.File.ReadAllLines("input.txt");

var oxyLines = lines.ToList();
for (var a = 0; a < 12; a++)
{
    if (oxyLines.Count > 1)
    {
        var count = oxyLines.Count(x => x.Substring(a, 1) == "1");
        if (count >= oxyLines.Count/2)
        {
            oxyLines = oxyLines.Where(x => x.Substring(a, 1) == "1").ToList();
        } else
        {
            oxyLines = oxyLines.Where(x => x.Substring(a, 1) == "0").ToList();
        }
    }
}
var oxy = 0;
if(oxyLines.Count == 1)
{
    oxy = Convert.ToInt32(oxyLines[0], 2);
} else
{
    throw new Exception("Didn't end with just one row");
}



var co2Lines = lines.ToList();
for (var b = 0; b < 12; b++)
{
    if (co2Lines.Count > 1)
    {
        var count = co2Lines.Count(x => x.Substring(b, 1) == "0");
        if (count <= co2Lines.Count / 2)
        {
            co2Lines = co2Lines.Where(x => x.Substring(b, 1) == "0").ToList();
        }
        else
        {
            co2Lines = co2Lines.Where(x => x.Substring(b, 1) == "1").ToList();
        }
    }
}
var co2 = 0;
if (co2Lines.Count == 1)
{
    co2 = Convert.ToInt32(co2Lines[0], 2);
}
else
{
    throw new Exception("Didn't end with just one row");
}

Console.WriteLine($"{oxy} * {co2} = {oxy * co2}");

//Stop and wait for enter before exiting
Console.ReadLine();