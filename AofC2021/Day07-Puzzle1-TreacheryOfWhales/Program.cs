Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 7 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");
var lineList = lines[0].Split(',');

var crabs = new int[lineList.Length];
for (int i = 0; i < lineList.Length; i++)
{
    crabs[i] = int.Parse(lineList[i]);
}

//find the range of values
int maxVal = crabs.Max();
int minVal = crabs.Min();
var avg = Convert.ToInt32(Math.Floor(crabs.Average()));

//now figure out fuel cost, starting at the average point
var costCompare = new Dictionary<int, int>();
for (int i = 0;i< 500; i++)
{
    var costSumPlus = 0;
    var costSumMinus = 0;

    var plus = avg + i;
    var minus = avg - i;

    foreach (var crab in crabs)
    {
        costSumPlus += Math.Abs(crab - plus);
        costSumMinus += Math.Abs(crab - minus);
    }

    costCompare[plus] = costSumPlus;
    costCompare[minus] = costSumMinus;
}

var minCost = costCompare.Min(x => x.Value);

Console.WriteLine($"The smallest fuel cost is: {minCost}");

//Stop and wait for enter before exiting
Console.ReadLine();