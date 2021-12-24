Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 11 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");
var flashes = 0;

//Load grid
var octopi = new int[10, 10];
for (int a = 0; a < 10; a++)
{
    for (int b = 0; b < 10; b++)
    {
        octopi[a, b] = Convert.ToInt32((lines[a][b]).ToString());
    }
}

//now run through 100 steps
for (var z = 0; z < 100; z++)
{
    //increase every position first
    for (int a = 0; a < 10; a++)
    {
        for (int b = 0; b < 10; b++)
        {
            octopi[a, b]++;
        }
    }

    //check flashes
    var foundFlashes = true;
    while (foundFlashes)
    {
        foundFlashes = false;
        for (int a = 0; a < 10; a++)
        {
            for (int b = 0; b < 10; b++)
            {
                if (octopi[a, b] > 9)
                {
                    foundFlashes = true;
                    Flash(a, b);
                }
            }
        }
    }

    //now reset the -1 to 0 before the next step
    for (int a = 0; a < 10; a++)
    {
        for (int b = 0; b < 10; b++)
        {
            if (octopi[a, b] == -1)
            {
                octopi[a, b] = 0;
            }
        }
    }

    for (int a = 0; a < 10; a++)
    {
        Console.WriteLine();
        for (int b = 0; b < 10; b++)
        {
            Console.Write(octopi[a, b]);
        }
    }
    Console.WriteLine();
    Console.WriteLine();
    Console.WriteLine();
}

Console.WriteLine($"Total flashes after 100 steps: {flashes}");

//Stop and wait for enter before exiting
Console.ReadLine();


void Flash(int x, int y)
{
    flashes++;
    octopi[x, y] = -1;  //we set to -1 to prevent multiple flashes in a step
    if (x - 1 >= 0 && y - 1 >= 0 && octopi[x - 1, y - 1] >= 0)
    {
        octopi[x - 1, y - 1]++;
    }
    if (y - 1 >= 0 && octopi[x, y - 1] >= 0)
    {
        octopi[x, y - 1]++;
    }
    if (x + 1 < 10 && y - 1 >= 0 && octopi[x + 1, y - 1] >= 0)
    {
        octopi[x + 1, y - 1]++;
    }
    if (x - 1 >= 0 && octopi[x - 1, y] >= 0)
    {
        octopi[x - 1, y]++;
    }
    if (x + 1 < 10 && octopi[x + 1, y] >= 0)
    {
        octopi[x + 1, y]++;
    }
    if (x - 1 >= 0 && y + 1 < 10 && octopi[x - 1, y + 1] >= 0)
    {
        octopi[x - 1, y + 1]++;
    }
    if (y + 1 < 10 && octopi[x, y + 1] >= 0)
    {
        octopi[x, y + 1]++;
    }
    if (x + 1 < 10 && y + 1 < 10 && octopi[x + 1, y + 1] >= 0)
    {
        octopi[x + 1, y + 1]++;
    }
}