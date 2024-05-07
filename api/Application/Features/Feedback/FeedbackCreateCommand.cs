using Diploma.Application.Contracts.DTOs.Svm;
using Diploma.Application.Shared;
using MediatR;

namespace Diploma.Application.Features.Feedback;

public record FeedbackCreateCommand(string VacancyId) : IRequest<Result<List<SelectionResult>?>>;