namespace Diploma.Application.Shared.EntityErrors;

public static class VacancyErrors
{
    public static Error MissingInformation(string missingField) =>
        Error.Validation("Vacancy.MissingInformation", $"The required field '{missingField}' is missing.");

    public static Error InvalidInformation(string invalidField) =>
        Error.Validation("Vacancy.MissingInformation", $"The required field '{invalidField}' is invalid.");

    public static Error InvalidLocation(string locationId) =>
        Error.Validation("Vacancy.InvalidLocation", $"The location with Id = {locationId} is not valid.");
    public static Error InvalidSalary() =>
        Error.Validation("Vacancy.InvalidSalary", $"The salary should be greater than zero");

    public static Error InvalidExperienceYears() =>
        Error.Validation("Vacancy.InvalidExperienceYears",
            $"The required experience years should be greater or equal to zero");

    public static Error InvalidSkillSet() =>
        Error.Validation("Vacancy.InvalidSkillSet", "One or more provided skills are not valid.");
}