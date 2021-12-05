Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 4 - Puzzle 1");

//Solution logic goes here
string[] lines = System.IO.File.ReadAllLines("input.txt");
var bingoNumbers = lines[0].Split(',');

//build our boards list
var bingoboards = new List<string[,]>();
for (int i = 1; i < lines.Length; i++)
{
    if (string.IsNullOrEmpty(lines[i]))
    {
        //start new board
        string[,] board = new string[5, 5];
        for (int a = 1; a <= 5; a++)
        {
            //clean up some extra spaces and then parse rows into bingo boards
            var split = lines[i + a].Trim().Replace("  ", " ").Split(' ');
            for (int b = 0; b < 5; b++)
            {
                board[a - 1, b] = split[b];
            }
        }
        bingoboards.Add(board);
    }
}

//start calling numbers. For each number called, we will iterate all the boards and replace the called number with an X to indicate a marked number
for (int p = 0; p < bingoNumbers.Length; p++)
{
    var number = bingoNumbers[p];

    var boardCount = bingoboards.Count;
    var boardsToRemove = new List<string[,]>();
    for (var q = 0; q < boardCount; q++)
    {
        var boardtomark = bingoboards[q];
        for (int y = 0; y < 5; y++)
        {
            for (int z = 0; z < 5; z++)
            {
                if (number.Equals(boardtomark[y, z]))
                {
                    boardtomark[y, z] = "X";
                    if (Bingo.CheckIfBoardIsBingo(boardtomark))
                    {
                        Bingo.CallBingo(boardtomark, number);
                        boardsToRemove.Add(boardtomark);
                    }
                }
            }
        }
    }

    //remove any boards that already scored a bingo
    foreach (var item in boardsToRemove)
    {
        bingoboards.Remove(item);
    }
}

//Stop and wait for enter before exiting
Console.ReadLine();


public static class Bingo
{
    public static bool CheckIfBoardIsBingo(string[,] boardToCheck)
    {
        bool isBingo = false;
        //horizontals
        for (int a = 0; a < 5; a++)
        {
            isBingo = true;
            for (int b = 0; b < 5; b++)
            {
                if (boardToCheck[a, b] != "X")
                {
                    isBingo = false;
                    break;
                }
            }

            if (isBingo) return true;
        }

        //verticals
        for (int x = 0; x < 5; x++)
        {
            isBingo = true;
            for (int y = 0; y < 5; y++)
            {
                if (boardToCheck[y, x] != "X")
                {
                    isBingo = false;
                    break;
                }
            }

            if (isBingo) return true;
        }

        return isBingo;
    }

    public static void CallBingo(string[,] bingoBoard, string numberCalled)
    {
        Console.WriteLine("BINGO!!!!");
        int unmatchedTotal = 0;
        for (int f = 0; f < 5; f++)
        {
            for (int g = 0; g < 5; g++)
            {
                Console.Write($"{bingoBoard[f, g].PadLeft(3)}");
                if (bingoBoard[f, g] != "X")
                {
                    unmatchedTotal += Convert.ToInt32(bingoBoard[f, g]);
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine();
        Console.WriteLine($"Last Number Called: {numberCalled}");
        Console.WriteLine($"Sum of unmatched: {unmatchedTotal * Convert.ToInt32(numberCalled)}");
        Console.WriteLine();
        Console.WriteLine();
        return;

        Console.ReadLine();
        Environment.Exit(0);
    }
}