using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace ThomasMaskinporten.Core;

public static class CertificateUtil
{
    public static X509Certificate2? GetCertificateFromLocalMachineStore(string friendlyName)
    {
        var store = GetLocalMachineCertificates();
        X509Certificate2 certificate = null;
        foreach (var cert in store.Cast<X509Certificate2>().Where(cert => cert.FriendlyName.Equals(friendlyName)))
        {
            certificate = cert;
        }
        return certificate;
    }

    private static X509Certificate2Collection GetLocalMachineCertificates()
    {
        var localMachineStore = new X509Store(StoreLocation.LocalMachine);
        localMachineStore.Open(OpenFlags.ReadOnly);
        var certificates = localMachineStore.Certificates;
        localMachineStore.Close();
        return certificates;
    }

    public static string CreateJWTSignature(X509Certificate2 Virksomhetssertifikat, string Data)
    {
        using (HashAlgorithm hasher = SHA256.Create())
        using (RSA rsa = Virksomhetssertifikat.GetRSAPrivateKey())
        {
            byte[] byteArray = Encoding.UTF8.GetBytes(Data);
            var hash = hasher.ComputeHash(byteArray);
            var signed = rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            return $"{Data}.{Base64UrlEncoder.Encode(signed)}";
        }
    }

    public static string CreateJWTSignature(JWK token, string data)
    {
        var rsaParams = RSAParameters(token);

        using (HashAlgorithm hasher = SHA256.Create())
        using (RSA rsa = new RSACryptoServiceProvider(2048))
        {
            rsa.ImportParameters(rsaParams);

            byte[] byteArray = Encoding.UTF8.GetBytes(data);
            var hash = hasher.ComputeHash(byteArray);
            var signed = rsa.SignHash(hash, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            return $"{data}.{Base64UrlEncoder.Encode(signed)}";
        }
    }

    private static RSAParameters RSAParameters(JWK token)
    {
        return new RSAParameters
        {
            Modulus = Base64UrlEncoder.DecodeBytes(token.n),
            Exponent = Base64UrlEncoder.DecodeBytes(token.e),
            D = Base64UrlEncoder.DecodeBytes(token.d),
            P = Base64UrlEncoder.DecodeBytes(token.p),
            Q = Base64UrlEncoder.DecodeBytes(token.q),
            DP = Base64UrlEncoder.DecodeBytes(token.dp),
            DQ = Base64UrlEncoder.DecodeBytes(token.dq),
            InverseQ = Base64UrlEncoder.DecodeBytes(token.qi),
        };
    }
}