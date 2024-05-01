﻿using System.Text.Json.Serialization;

namespace Diploma.Application.Shared;

public sealed record Error
{
    public static readonly Error None = new(string.Empty, string.Empty, ErrorType.Failure);

    private Error(string code, string description, ErrorType type)
    {
        Code = code;
        Description = description;
        Type = type;
    }

    public string Code { get; }
    public string Description { get; }
    
    [JsonIgnore]
    public ErrorType Type { get; }

    public static Error NotFound(string code, string description)
        => new(code, description, ErrorType.NotFound);

    public static Error Failure(string code, string description)
        => new(code, description, ErrorType.Failure);

    public static Error Validation(string code, string description)
        => new(code, description, ErrorType.Validation);
    
    public static Error Conflict(string code, string description)
        => new(code, description, ErrorType.Conflict);
}

public enum ErrorType
{
    Failure = 0,
    Validation = 1,
    NotFound = 2,
    Conflict = 3
}