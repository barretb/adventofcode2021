

Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 10 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");
List<string> output = new List<string>();
var counter = 1;

if (File.Exists("list.csv")) File.Delete("list.csv");

foreach (var line in lines)
{
    var parts = line.Replace("\"", "\" ").Replace("  ", " ").Split('<');
    var title = (parts[2].Split("title"))[1].Replace("=", "").Replace("\"", "").Replace(",", " ")
        .Trim();
    var link = (parts[2].Split("title"))[0].Replace("a href=", "").Replace("\"", "");
    var iconLink = (parts[3].Split(" src="))[1].Replace("\"", "").Replace("/>", "").Trim();
    var imageName = title.Replace(" ", "")
        .Replace("/", "-").Replace("'", "").Replace("(", "").Replace(")", "")
        + ".png";
    using (HttpClient client = new HttpClient())
    {
        byte[] fileBytes = await client.GetByteArrayAsync(iconLink);
        File.WriteAllBytes("icons\\" + imageName, fileBytes);
    }

    output.Add($"{counter},{title},{link},{imageName}");

    var test = 1;
    counter++;
}

await File.WriteAllLinesAsync("list.csv", output);

//Stop and wait for enter before exiting
Console.ReadLine();