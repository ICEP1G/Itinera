using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itinera.Client.Models
{
    public enum RequestError
    {
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        RequestTimeOut = 408,
        ResourceGone = 410,
        TooManyRequest = 428,
        InternalServerError = 500,
        ServiceUnavailable = 503,
        NetworkAuthenticationRequired = 511
    }
}
