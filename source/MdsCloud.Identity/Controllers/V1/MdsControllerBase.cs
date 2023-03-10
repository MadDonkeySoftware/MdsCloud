using MdsCloud.Identity.DTOs;
using MdsCloud.Identity.Utils;
using Microsoft.AspNetCore.Mvc;
using NHibernate;

namespace MdsCloud.Identity.Controllers.V1;

public abstract class MdsControllerBase : ControllerBase
{
    protected readonly ILogger<ImpersonationController> Logger;
    protected readonly ISessionFactory SessionFactory;
    protected readonly IConfiguration Configuration;
    protected readonly IRequestUtilities RequestUtilities;

    protected MdsControllerBase(
        ILogger<ImpersonationController> logger,
        ISessionFactory sessionFactory,
        IConfiguration configuration,
        IRequestUtilities requestUtilities
    )
    {
        Logger = logger;
        SessionFactory = sessionFactory;
        Configuration = configuration;
        RequestUtilities = requestUtilities;
    }

    /// <summary>
    /// </summary>
    /// <param name="reason">The internal log message to emit</param>
    /// <returns></returns>
    protected BadRequestObjectResult FailRequest(string logReason, string? userMessage = null)
    {
        Logger.Log(LogLevel.Debug, "{}", logReason);
        RequestUtilities.Delay(10000);
        return BadRequest(
            new BadRequestResponse(
                new Dictionary<string, string[]>
                {
                    {
                        "Message",
                        new[]
                        {
                            userMessage
                                ?? "Could not find account, user, or passwords did not match"
                        }
                    }
                }
            )
        );
    }
}
