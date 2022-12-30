// See https://aka.ms/new-console-template for more information
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.IdentityModel.Tokens;
using ThomasMaskinporten.Core;
using ThomasMaskinporten.Core.Models;

namespace ThomasMaskinporten.ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        //Henter Virksomhetssertifikat fra Local Machine Certificate Store
        var cert = CertificateUtil.GetCertificateFromLocalMachineStore("Lilla Mett Tiger AS Auth");
        var cliendID = "19b1234d-ca55-5adb-b195-3db4b662effe";


        //Hvis det skal signeres med RSAnøkler
        //var tokenstring = File.ReadAllText(@"ThomasMaskinporten.ConsoleApp\JWK.json");
        //var JWKtoken = JsonSerializer.Deserialize<JWK>(tokenstring);
       

        //Utgående JWT til Maskinporten ,Header
        //Bygg Header --> Gjør om til JSON --> Gjør om til Base64
        var OutgoingHeader = new OutgoingTokenHeader(cert);        
        //var OutgoingHeader = new OutgoingTokenHeader(JWKtoken.kid);

        string jsonOutgoingHeader = JsonSerializer.Serialize<OutgoingTokenHeader>(OutgoingHeader, new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
        string base64header = Base64UrlEncoder.Encode(jsonOutgoingHeader);

        //Utgående JWT til Maskinporten ,Body
        //Bygg Body --> Gjør om til JSON --> Gjør om til Base64
        var OutgoingBody = new OutgoingToken(cliendID, @"https://www.utv.vegvesen.no",new List<string>{@"svv:kjoretoy/kjoretoyopplysninger"});
        string jsonOutgoingBody = JsonSerializer.Serialize<OutgoingToken>(OutgoingBody, new JsonSerializerOptions {DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
        string base64body =  Base64UrlEncoder.Encode(jsonOutgoingBody);

        //Signer Header og Body
        //Sender inn Base64
        //Returnerer Signert JWT Token        
        var SignedOutgoingToken = CertificateUtil.CreateJWTSignature(cert, $"{base64header}.{base64body}");        
        //var SignedOutgoingToken = CertificateUtil.CreateJWTSignature(JWKtoken, $"{base64header}.{base64body}");
        System.Console.WriteLine(SignedOutgoingToken);
        System.Console.WriteLine();

        //Veksler inn Generert Token i ett Maskinporten Token
        var result = MaskinportenWebClient.ExchangeTokenAsync(SignedOutgoingToken);

        //Konverterer svar fra Maskinporten til JSON og Printer til Console
        //access_token er det som brukes i Webkall mot f.ekes vegvesenet.
        string responejson = JsonSerializer.Serialize<MaskinportenResponse>(result.Result, new JsonSerializerOptions { WriteIndented = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull });
        System.Console.WriteLine(responejson);
    }
}