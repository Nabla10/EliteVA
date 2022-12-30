using EliteVA.Proxy;
using Microsoft.Extensions.Logging;

namespace EliteVA;

public class VoiceAttackLoggerProvider : ILoggerProvider
{
    private readonly VoiceAttackProxy _proxy;

    public VoiceAttackLoggerProvider(VoiceAttackProxy proxy)
    {
        _proxy = proxy;
    }

    public void Dispose()
    {
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new VoiceAttackLogger(_proxy);
    }
}