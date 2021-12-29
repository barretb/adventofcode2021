

using AngleSharp.Dom;
using AngleSharp.Html.Dom;
using AngleSharp.Html.Parser;
using System.Text.RegularExpressions;

//Solution logic goes here

//Load input array
string html = System.IO.File.ReadAllText("input.txt");
List<string> output = new List<string>();
var counter = 1;

if (File.Exists("list.csv")) File.Delete("list.csv");

var parser = new HtmlParser();
var document = parser.ParseDocument(html);
var items = new List<ConnectorItem>();
foreach(IElement element in document.QuerySelectorAll("li.connectors_list__parent"))
{
    var item = new ConnectorItem() { Premium = false};
    IHtmlAnchorElement titleElement = (IHtmlAnchorElement)element.QuerySelector("a");
    if(titleElement != null)
    {
        var titleP = titleElement.QuerySelector("p");

        var title = titleP.InnerHtml.Trim();
        if (items.Any(x => x.Name == title))
        {
            continue;
        } //make sure no dupes
        if (title.Contains("deprecated")) continue; //don't include deprecated connectors

        item.Name = title;
        item.InfoLink = new Uri("https://powerautomate.microsoft.com/" + titleElement.PathName);

        var imageElement = (IHtmlImageElement)titleElement.QuerySelector("img");
        if(imageElement != null)
        {
            item.ImageLink = new Uri(imageElement.Source);
            item.ImageFileName = Regex.Replace(title, "[^a-zA-Z0-9]", String.Empty) + ".png";

            if (!File.Exists("\\icons\\" + item.ImageFileName))
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] fileBytes = await client.GetByteArrayAsync(item.ImageLink);
                    File.WriteAllBytes("icons\\" + item.ImageFileName, fileBytes);
                }
            }
        }

        //check premium
        foreach (IElement child in titleElement.QuerySelectorAll("span"))
        {
            if (child != null && child.InnerHtml.Contains("Premium")) item.Premium = true;            
        }

        items.Add(item);
    }


}


//foreach (var line in lines)
//{
//    var parts = line.Replace("\"", "\" ").Replace("  ", " ").Split('<');
//    var title = (parts[2].Split("title"))[1].Replace("=", "").Replace("\"", "").Replace(",", " ")
//        .Trim();
//    var link = (parts[2].Split("title"))[0].Replace("a href=", "").Replace("\"", "");
//    var iconLink = (parts[3].Split(" src="))[1].Replace("\"", "").Replace("/>", "").Trim();
//    var imageName = title.Replace(" ", "")
//        .Replace("/", "-").Replace("'", "").Replace("(", "").Replace(")", "")
//        + ".png";
//    using (HttpClient client = new HttpClient())
//    {
//        byte[] fileBytes = await client.GetByteArrayAsync(iconLink);
//        File.WriteAllBytes("icons\\" + imageName, fileBytes);
//    }

//    output.Add($"{counter},{title},{link},{imageName}");

//    var test = 1;
//    counter++;
//}

foreach (var i in items)
{
    output.Add($"{counter},{i.Name},{i.InfoLink.ToString()},{i.ImageFileName},{i.Premium.ToString()}");
    counter++;
}

await File.WriteAllLinesAsync("list.csv", output);

//Stop and wait for enter before exiting
Console.ReadLine();



public class ConnectorItem
{
    public string Name { get; set; }
    public Uri InfoLink       { get; set; }
    public Uri ImageLink { get; set; }
    public string ImageFileName { get; set; }
    public bool Premium { get; set; }
}