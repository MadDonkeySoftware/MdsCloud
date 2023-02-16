using Microsoft.Build.Framework;
using Swashbuckle.AspNetCore.Annotations;

#pragma warning disable CS8618
namespace Identity.DTOs.Authentication;

public class AuthenticationResponseBody
{
    [Required]
    [SwaggerSchema("The user specific JWT to be supplied for authentication")]
    public string Token { get; set; }
}
