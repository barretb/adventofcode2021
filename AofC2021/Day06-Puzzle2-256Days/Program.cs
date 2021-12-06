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

//initialize number of fish
var dictFish = new Dictionary<int, ulong>();
for (int a = 0; a <= 8; a++)
{
    dictFish[a] = 0;
}

foreach (var item in lanternFish)
{
    dictFish[item]++;
}

for (int x = 0; x < 256; x++)
{
    var fishReproducing = dictFish[0];
    for (int y = 0; y < 8; y++)
    {
        //shift all fish down one day
        dictFish[y] = dictFish[y + 1];
    }
    //now reset reproducers
    dictFish[6] = dictFish[6] + fishReproducing;
    dictFish[8] = fishReproducing;
}
ulong fishcount = 0;
for (var b = 0; b < 9; b++)
{
    fishcount += dictFish[b];
}
Console.WriteLine($"Total Fish after 256 days: {fishcount}");

//Stop and wait for enter before exiting
Console.ReadLine();