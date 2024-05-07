namespace Diploma.Application.Contracts.DTOs.Svm;

public class SelectionResult
{
    public double MatchScore { get; set; }
    public string Candidate { get; set; }
    public string Name { get; set; }
    public double YearsOfExperience { get; set; }
}