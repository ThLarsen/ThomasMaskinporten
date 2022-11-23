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

}