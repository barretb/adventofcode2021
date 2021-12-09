Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 9 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");
var grid = new int[100, 100];
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        grid[i, j] = Convert.ToInt32(lines[i].Substring(j, 1));
    }
}

var total = 0;
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        var lowest = true;
        //check left
        if (i > 0 && grid[i, j] >= grid[i - 1, j])
        {
            lowest = false;
        }

        //check above
        if (lowest && j > 0 && grid[i, j] >= grid[i, j - 1])
        {
            lowest = false;
        }

        //check below
        if (lowest && j < 99 && grid[i, j] >= grid[i, j + 1])
        {
            lowest = false;
        }

        //check right
        if (lowest && i < 99 && grid[i, j] >= grid[i + 1, j])
        {
            lowest = false;
        }

        if (lowest) total += grid[i, j] + 1;
    }
}


Console.WriteLine($"Total sum of low points: {total}");

//Stop and wait for enter before exiting
Console.ReadLine();