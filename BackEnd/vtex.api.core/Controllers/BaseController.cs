using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using vtex.api.core.Security;

namespace vtex.api.core.Controllers
{
    [ServiceFilter(typeof(SimpleFilterRules))]
    public class BaseController : ControllerBase
    {

    }
}
