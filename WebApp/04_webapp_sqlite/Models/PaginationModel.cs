
namespace _04_webapp_sqlite.Models;
public class PaginationModel
{
    public int PageIndex { get; set; }
    public int TotalPages { get; set; }
    public bool HasPreviewPage => PageIndex > 1;
    public bool HasNextPage => PageIndex < TotalPages;
    public Func<int, string> PageUrl { get; set; }
}