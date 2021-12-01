Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 1 - Sonar Sweep");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");
int[] measurements = new int[lines.Length];
for (int i = 0; i < lines.Length; i++)
{
      measurements[i] = int.Parse(lines[i]);
}

int depth1 = 0, depth2 = 0;
var increases = 0;
for (int i = 0; i < lines.Length - 3; i++)
{
    depth1 = measurements[i] + measurements[i + 1] + measurements[i + 2];
    depth2 = measurements[i + 1] + measurements[i + 2] + measurements[i + 3];
    if(depth2 > depth1) increases++;
}

//Write out the answer
Console.WriteLine($"Number of increases: {increases}");

//Stop and wait for enter before exiting
Console.ReadLine();