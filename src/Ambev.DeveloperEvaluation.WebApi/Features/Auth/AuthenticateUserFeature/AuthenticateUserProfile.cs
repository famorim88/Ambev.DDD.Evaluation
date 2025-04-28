using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.Auth.AuthenticateUser;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Auth.AuthenticateUserFeature;

/// <summary>
/// AutoMapper profile for authentication-related mappings
/// </summary>
public sealed class AuthenticateUserProfile : Profile
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AuthenticateUserProfile"/> class
    /// </summary>
    public AuthenticateUserProfile()
    {
        CreateMap<AuthenticateUserRequest, AuthenticateUserCommand>();
        // Mapeamento de AuthenticateUserResponse para AuthenticateUserResult
        CreateMap<AuthenticateUserResponse, AuthenticateUserResult>()
            .ForMember(dest => dest.Id, opt => opt.Ignore()) // Id n�o est� presente na origem, pode ser ignorado ou preenchido de outra forma
            .ForMember(dest => dest.Phone, opt => opt.Ignore()); // Phone tamb�m n�o est� presente na origem, pode ser ignorado ou preenchido de outra forma

        // Mapeamento inverso de AuthenticateUserResult para AuthenticateUserResponse, se necess�rio
        CreateMap<AuthenticateUserResult, AuthenticateUserResponse>();

        CreateMap<User, AuthenticateUserResponse>()
            .ForMember(dest => dest.Token, opt => opt.Ignore())
            .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role.ToString()));
    }
}
