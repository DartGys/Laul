using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laul.Application.Common.Parser
{
    public static class TokenParser
    {
        public static (string containerName, string fileName) ParsToken(string token)
        {
            string[] parts = token.Split('/');

            string containerName = parts[parts.Length - 2];
            string fileName = parts[parts.Length - 1].Split("?")[0];

            return(containerName, fileName);
        }
    }
}
