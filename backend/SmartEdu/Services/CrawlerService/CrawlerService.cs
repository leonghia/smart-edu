using HtmlAgilityPack;
using SmartEdu.Entities;

namespace SmartEdu.Services.CrawlerService;

public class CrawlerService : ICrawlerService
{

    public string ExtractDocumentDescription(string filePath, string id)
    {
        var text = File.ReadAllText(filePath);
        var start = text.IndexOf("Book." + id);
        text = text.Remove(0, start);
        text = text.Substring(0, text.IndexOf(@"section\u003e\n") - text.IndexOf("Book." + id));
        if (text.IndexOf("display:none") == -1) return "";
        text = text.Substring(text.IndexOf("display:none"));
        text = text.Remove(text.IndexOf(@"\u003c"));
        text = text.Substring(text.IndexOf(@"\u003e") + @"\u003e".Length);
        return text;
    }

    public List<Document> ExtractDocuments(string html, string json)
    {
        var documents = new List<Document>(50);
        var path = html;
        var doc = new HtmlDocument();
        doc.Load(path);
        var tableRows = doc.DocumentNode.SelectNodes("//tr").ToArray<HtmlNode>();

        var random = new Random();
        
        for (var i = 0; i < 50; i++)
        {
            var document = new Document();
            document.Image = tableRows[i].SelectSingleNode(".//img[@class='bookCover']").GetAttributeValue("src", "def").Replace("SY75", "SY300");
            document.Name = tableRows[i].SelectSingleNode(".//a[@class='bookTitle']").InnerText.Trim();
            // var isDouble = Double.TryParse(tableRows[i].SelectSingleNode(".//span[@class='minirating']").InnerText.Trim().Split(" ").ElementAt(0), out double rating);
            // if (isDouble) document.Rating = rating;
            document.Rating = random.Next(10, 50) / 10.0;
            var isInt32 = Int32.TryParse(tableRows[i].SelectSingleNode(".//span[@class='minirating']").InnerText.Trim().Split(" ").ElementAt(4).Replace(",", ""), out int numbersOfRating);
            if (isInt32) document.NumbersOfRating = numbersOfRating;
            var id = tableRows[i].SelectSingleNode(".//div[@class='u-anchorTarget']").GetAttributeValue("id", "def");
            document.Description = ExtractDocumentDescription(json, id);
            documents.Add(document);
        }
        return documents;
    }

    public async Task FetchAndSave(string url, string filePath)
    {
        if (File.Exists(filePath)) return;
        using var client = new HttpClient();
        using var response = await client.GetAsync(url);
        using var content = response.Content;

        var data = await content.ReadAsStringAsync();
        File.WriteAllText(filePath, data);
    }
}