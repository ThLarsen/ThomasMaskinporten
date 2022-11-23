using System.Security.Cryptography.X509Certificates;

namespace ThomasMaskinporten.Core.Models;
public class OutgoingTokenHeader
{ 
    public string alg { get; set; }
    public List<string>? x5c { get; set; }
    public string? kid { get; set; }

    public OutgoingTokenHeader(X509Certificate2 Virksomhetsertifikat)
    {
        alg = "RS256";
        x5c = new List<String> { Convert.ToBase64String(Virksomhetsertifikat.Export(X509ContentType.Cert)) };
        //Convert.ToBase64String(this.certificate.Export(X509ContentType.Cert)

    }
}
