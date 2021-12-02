Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 2 - Adding Aim");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

int depth = 0, forward = 0, aim=0;
for (int i = 0; i < lines.Length; i++)
{
    ///parse the command and adjust the appropriate tracking variable
    var cmd = lines[i].Split(' ');
    if (cmd[0] == "forward")
    {
        var x= int.Parse(cmd[1]);
        forward += x;
        depth += x * aim;
    }
    else if (cmd[0] == "down")
    {
        aim += int.Parse(cmd[1]);
    }
    else
    {
        aim -= int.Parse(cmd[1]);
    }
}

//Write out the solution
Console.WriteLine($"Forward: {forward}");
Console.WriteLine($"Depth: {depth}");
Console.WriteLine($"Product: {forward * depth}");

//Stop and wait for enter before exiting
Console.ReadLine();