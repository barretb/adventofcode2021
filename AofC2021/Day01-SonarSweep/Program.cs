// See https://aka.ms/new-console-template for more information
Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 1 - Sonar Sweep");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

var depth = int.Parse(lines[0]);
var increases = 0;
for (int i = 1; i < lines.Length; i++)
{
    var measurement = int.Parse(lines[i]);
    if (measurement > depth) increases++;
    depth = measurement;
}

//Write out the solution
Console.WriteLine($"Number of increases: {increases}");


//Stop and wait for enter before exiting
Console.ReadLine();