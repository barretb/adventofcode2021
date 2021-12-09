Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 9 - Puzzle 2");

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

var basins = new List<Basin>();
var total = 0;
for (int i = 0; i < 100; i++)
{
    for (int j = 0; j < 100; j++)
    {
        var pt = new List<Points>();
        var lowest = Checker.CheckThePoint(grid, i, j);

        if (lowest)
        {
            var basin = new Basin()
            {
                PointX = i,
                PointY = j,
                BasinPoints = new List<Points>()
            };


            basins.Add(basin);
        }
    }
}

foreach (var basin in basins)
{
    basin.CheckPoints(grid);
}

var subset = basins.OrderByDescending(x => x.BasinPoints.Count).Take(3).ToList();
total = subset[0].BasinPoints.Count * subset[1].BasinPoints.Count * subset[2].BasinPoints.Count;

Console.WriteLine($"Total sum of low points: {total}");

//Stop and wait for enter before exiting
Console.ReadLine();

public struct Points
{
    public int x;
    public int y;
}

public static class Checker { 
    public static bool CheckThePoint(int[,] grid, int i, int j)
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

        return lowest;
    }
}

public class Basin
{
    public int PointX;
    public int PointY;
    public List<Points> BasinPoints;

    public void CheckPoints(int[,] grid)
    {
        var pointsToCheck = new List<Points>() { new Points() { x = PointX, y = PointY } };


        while (pointsToCheck.Any())
        {
            var count = pointsToCheck.Count();
            for(int a = count-1; a>= 0; a--)
            {
                var point = pointsToCheck[a];
               
                if (grid[point.x, point.y] < 9 && !BasinPoints.Contains(point))
                {
                    BasinPoints.Add(point);

                    //check left
                    if (point.x > 0 && grid[point.x, point.y] < grid[point.x - 1, point.y])
                    {
                        pointsToCheck.Add(new Points() { x = point.x - 1, y = point.y });
                    }

                    //check above
                    if (point.y > 0 && grid[point.x, point.y] < grid[point.x, point.y - 1])
                    {
                        pointsToCheck.Add(new Points() { x = point.x, y = point.y - 1 });
                    }

                    //check below
                    if (point.y < 99 && grid[point.x, point.y] < grid[point.x, point.y + 1])
                    {
                        pointsToCheck.Add(new Points() { x = point.x, y = point.y + 1 });
                    }

                    //check right
                    if (point.x < 99 && grid[point.x, point.y] < grid[point.x + 1, point.y])
                    {
                        pointsToCheck.Add(new Points() { x = point.x + 1, y = point.y });
                    }

                }
                    pointsToCheck.Remove(point);
            }
        }
    }
}