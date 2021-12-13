Console.WriteLine("Advent of Code 2021");
Console.WriteLine("Day 12 - Puzzle 1");

//Solution logic goes here

//Load input array
string[] lines = System.IO.File.ReadAllLines("input.txt");

//build our caves
var caves = new List<Cave>();
foreach(var line in lines)
{
    var points = line.Split("-");
    Cave caveA = caves.FirstOrDefault(x=>x.Name==points[0]);
    Cave caveB = caves.FirstOrDefault(x => x.Name == points[1]);

    if (caveA==null)
    {
        caveA = new Cave() { Name = points[0], ConnectedCaves = new List<Cave>() };
        caves.Add(caveA);
    }
    if(caveB == null)
    {
        caveB = new Cave() { Name = points[1], ConnectedCaves = new List<Cave>() };
        caves.Add(caveB);
    }
    caveA.ConnectedCaves.Add(caveB);
    caveB.ConnectedCaves.Add(caveA);
}

var start = caves.First(x => x.Name == "start");
var end = caves.First(x => x.Name == "end");







Console.WriteLine($"Number of paths: {}");

//Stop and wait for enter before exiting
Console.ReadLine();

void FindPaths(Cave start, Cave end)
{
    List<Cave> pathList = new List<Cave>();
    pathList.Add(start);

}

void FindPathsUtil(Cave start, Cave end, List<Cave> localPaths)
{
    if (start == end) return;

}


class Cave
{
    public string Name { get; set; }
    public List<Cave> ConnectedCaves { get; set; }
    public bool IsLargeCave
    {
        get
        {
            return Char.IsUpper(Name[0]);
        }
    }
}
