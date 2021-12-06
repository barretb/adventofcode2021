Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 6 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

var strLanternFish = lines[0].Split(',');
var lanternFish = new List<int>();
foreach (var fish in strLanternFish)
{
    lanternFish.Add(int.Parse(fish));
}

for (int x = 0; x < 80; x++)
{
    var newList = new List<int>();
    foreach (var fishie in lanternFish)
    {
        if (fishie == 0)
        {
            //Time for a new fishie
            newList.Add(8);
            newList.Add(6);
        }
        else
        {
            //Just another day in the lifecycle
            newList.Add(fishie - 1);
        }
    }
    lanternFish = newList;
}

Console.WriteLine($"Total Fish after 80 days: {lanternFish.Count}");

//Stop and wait for enter before exiting
Console.ReadLine();