namespace Diploma.Application.Shared.EntityErrors;

public static class CandidateErrors
{
    public static Error NotFound(string id) =>
        Error.NotFound("Candidate.NotFound", $"The candidate with id '{id}' is not exist.");
}