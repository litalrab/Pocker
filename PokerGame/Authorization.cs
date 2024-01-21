using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.AspNetCore.Http;

namespace PokerGame
{
    public class Authorization
    {
        public static bool IsAuthorize(HttpRequest request)
        {
            string authHeader = request.Headers["Authorization"];

            if (authHeader != null && authHeader.StartsWith("Bearer"))
            {
                string encodedUsernamePassword = authHeader.Substring("Bearer ".Length).Trim();
                if (encodedUsernamePassword == ConfigurationManager.AppSettings["jwt"])
                    return true;

            }
            return false;
        }

    }
}
