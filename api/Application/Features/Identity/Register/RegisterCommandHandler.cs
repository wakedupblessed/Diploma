using AutoMapper;
using Diploma.Application.Contracts.Persistence;
using Diploma.Application.Shared;
using FluentValidation;
using Identity.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Diploma.Application.Features.Identity.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Result<Unit>>
{
    private readonly IValidator<RegisterCommand> _validator;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ICandidateRepository _candidateRepository;
    private readonly IMapper _mapper;

    public RegisterCommandHandler(ICandidateRepository candidateRepository, UserManager<ApplicationUser> userManager,
        IValidator<RegisterCommand> validator, IMapper mapper)
    {
        _candidateRepository = candidateRepository;
        _userManager = userManager;
        _validator = validator;
        _mapper = mapper;
    }

    public async Task<Result<Unit>> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (validationResult.Errors.Any())
        {
            return Result<Unit>.Failure((validationResult.Errors.First().CustomState as Error)!);
        }

        var identityUser = _mapper.Map<ApplicationUser>(request);

        var creationResult = await _userManager.CreateAsync(identityUser, request.Password);

        if (creationResult.Succeeded)
        {
            var user = _mapper.Map<Domain.Candidate>(identityUser);

            await _candidateRepository.CreateAsync(user);
            
            return Unit.Value;
        }

        var error = creationResult.Errors.First();

        return Result<Unit>.Failure(Error.Failure(error.Code, error.Description));
    }
}