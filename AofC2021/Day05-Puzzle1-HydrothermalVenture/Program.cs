Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 5 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

//initialize grid
int[,] seaGrid = new int[1000, 1000];
for (int a = 0; a < 1000; a++)
{
    for (int b = 0; b < 1000; b++)
    {
        seaGrid[a, b] = 0;
    }
}

//now parse the lines
foreach (var line in lines)
{
    //get our endpoints as ints
    var points = line.Replace(" ", "").Split("->");
    var startPoint = points[0].Split(",");
    var x1 = Convert.ToInt32(startPoint[0]);
    var y1 = Convert.ToInt32(startPoint[1]);
    var endPoint = points[1].Split(",");
    var x2 = Convert.ToInt32(endPoint[0]);
    var y2 = Convert.ToInt32(endPoint[1]);

    if (x1 == x2)
    {
        //vertical line
        if(y1 > y2)
        {
            var temp = y2;
            y2 = y1;
            y1 = temp;
        }

        for (var z = y1; z <= y2; z++)
        {
            seaGrid[x1, z] = seaGrid[x1, z] + 1;
        }
    }
    else if (y1 == y2)
    {
        //horizontal line
        if(x1 > x2)
        {
            var temp = x2;
            x2 = x1;
            x1 = temp;
        }
        for (var t = x1; t <= x2; t++)
        {
            seaGrid[t, y1] = seaGrid[t, y1] + 1;
        }
    }
    else
    {
        //diagonal line
        //determine angle (top left to bottom right or bottom left to top right)
        int xPath = 1, yPath = 1;
        if (x1 > x2) xPath = -1;
        if (y1 > y2) yPath = -1;
        //Console.WriteLine($"{x1},{y1} -> {x2},{y2}");

        //now find all the points
        var diff = Math.Abs(x1 - x2);
        for(int t=0; t <= diff; t++)
        {
            var x = x1 + (t * xPath);
            var y = y1 + (t * yPath);
            seaGrid[x, y] = seaGrid[x, y] + 1;
        }
    }
}

//now find count where intersection >= 2
var counter = 0;
for (int f = 0; f < 1000; f++)
{
    for (int g = 0; g < 1000; g++)
    {
        if (seaGrid[f, g] >= 2)
        {
            counter++;
        };
    }
}

Console.WriteLine($"Number of points >= 2:  {counter}");
//Stop and wait for enter before exiting
Console.ReadLine();