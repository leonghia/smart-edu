using SmartEdu.Entities;

namespace SmartEdu.Services.CrawlerService;

public interface ICrawlerService
{
    Task FetchAndSave(string url, string filePath);
    string ExtractDocumentDescription(string filePath, string id);
    List<Document> ExtractDocuments(string html, string json);
}