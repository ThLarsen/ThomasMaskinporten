public class JWK
{
    //Key ID (Private Key)
    public string? kid { get; set; }   
     
    //Private Exponent (Private Key)
    public string? d { get; set; }

    //Public Key Exponent
    public string? e { get; set; }

    //Public Key Modulus
    public string? n { get; set; }  

    //Public Key Use: sig/enc
    public string? use { get; set; }
    
    //Algorithm ,Ex RS256
    public string? alg { get; set; }

    //Algorithm  Family ,ex RSA
    public string? kty { get; set; }

    //First Prime Factor
    public string? p { get; set; }

    //Second Prime Factor
    public string? q { get; set; }  

    //First CRT Coefficient
    public string? qi { get; set; }

    //First Factor CRT Exponent
    public string? dq { get; set; }

    //Second Factor CRT Exponent
    public string? dp { get; set; } 
}