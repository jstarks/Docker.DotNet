using System.Net.Http;
using System.Threading;
using Microsoft.Net.Http.Client;

namespace Docker.DotNet
{
    public class AnonymousCredentials : Credentials
    {
        public AnonymousCredentials()
        {
        }

        public override bool IsTlsCredentials()
        {
            return false;
        }

        public override void Dispose()
        {
        }

        public override HttpMessageHandler GetHandler(HttpMessageHandler innerHandler)
        {
            return innerHandler;
        }
    }
}