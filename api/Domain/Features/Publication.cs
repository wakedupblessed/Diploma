using Diploma.Domain.Common;

namespace Diploma.Domain.Features;

public class Publication : BaseEntity
{
    public string Title { get; set; }
    public string JournalName { get; set; }
    public string Doi { get; set; }
    public int YearOfPublication { get; set; }

    // public Publication(string id,string title, string journalName, int yearOfPublication, string doi)
    // {
    //     Id = id;
    //     Title = title;
    //     JournalName = journalName;
    //     YearOfPublication = yearOfPublication;
    //     Doi = doi;
    // }
    //
    // public Publication(string doi)
    // {
    //     Doi = doi;
    // }

    public Publication()
    {
        
    }
}