namespace ThomasMaskinporten.Core.Models;
public class OutgoingToken
{ 
    public string iss { get; set; }
    public string? aud { get; set; }
    public string? resource { get; set; }
    public long? iat { get; set; }
    public long? exp { get; set; }
    public string? jti { get; set; } 

    public string? scope { get; set; } 
    //public int MyProperty { get; set; }

    public OutgoingToken(string ClientID,List<string> Scopes)
    {             
        iss = ClientID;
        aud = @"https://ver2.maskinporten.no/";
        jti = Guid.NewGuid().ToString();
        iat = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        exp = new DateTimeOffset(DateTime.UtcNow.AddSeconds(600)).ToUnixTimeSeconds();

        scope = String.Join(" ", Scopes);
    }
    public OutgoingToken(string ClientID,string Resource,List<string> Scopes)
    {             
        iss = ClientID;
        aud = @"https://ver2.maskinporten.no/";
        resource = Resource;
        jti = Guid.NewGuid().ToString();
        iat = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();
        exp = new DateTimeOffset(DateTime.UtcNow.AddSeconds(120)).ToUnixTimeSeconds();

        scope = String.Join(" ", Scopes);

    }
}

