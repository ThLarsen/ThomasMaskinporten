using System.Net.Http.Headers;
using ThomasMaskinporten.Core.Models;

namespace ThomasMaskinporten.Core;
public class MaskinportenOutgoingToken
{  
    public OutgoingTokenHeader Header { get; set; }
    public OutgoingToken TokenBody { get; set; }

    public MaskinportenOutgoingToken()
    {
        //ToDo!
    }
}