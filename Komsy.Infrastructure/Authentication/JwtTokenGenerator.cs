using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Komsy.Application.Services.Authentication;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Komsy.Application.Common.Interfaces.Services;
using Komsy.Domain.Entities;

namespace Komsy.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator {

  private readonly IDateTimeProvider _dateTimeProvider;
  private readonly JwtSettings _jwtSettings;
  public JwtTokenGenerator(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) {
    _dateTimeProvider = dateTimeProvider;
    _jwtSettings = jwtOptions.Value;
  }


  public string GenerateToken(User user) {

    var siginingCredentials = new SigningCredentials(
      new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Secret)),
      SecurityAlgorithms.HmacSha256);

    var claims = new List<Claim> {
      new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
      new Claim(JwtRegisteredClaimNames.GivenName, user.FirstName),
      new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

  };

    var securityTokent = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      expires: _dateTimeProvider.UtcNow.AddMinutes(_jwtSettings.ExpiryMinutes),
      claims: claims,
      signingCredentials: siginingCredentials
    );

    return new JwtSecurityTokenHandler().WriteToken(securityTokent);

  }

}