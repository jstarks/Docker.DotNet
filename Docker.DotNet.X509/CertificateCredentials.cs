using System;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Docker.DotNet.X509
{
    public class CertificateCredentials : Credentials
    {
        private X509Certificate2 _certificate;

        public CertificateCredentials(X509Certificate2 clientCertificate)
        {
            _certificate = clientCertificate;
        }

        public override HttpMessageHandler GetHandler(HttpMessageHandler innerHandler)
        {
            // Until the inner handle supports client certificates, just ignore it and
            // use a WebRequestHandler.
            innerHandler.Dispose();

            var handler = new WebRequestHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                UseDefaultCredentials = false
            };

            handler.ClientCertificates.Add(_certificate);
            return handler;
        }

        public override bool IsTlsCredentials()
        {
            return true;
        }

        public override void Dispose()
        {
        }
    }
}