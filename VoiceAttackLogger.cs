using System;
using EliteVA.Proxy;
using EliteVA.Proxy.Logging;
using Microsoft.Extensions.Logging;

namespace EliteVA;

public class VoiceAttackLogger : ILogger
{
    private readonly VoiceAttackProxy _proxy;

    public VoiceAttackLogger(VoiceAttackProxy proxy)
    {
        _proxy = proxy;
    }
    
    public IDisposable BeginScope<TState>(TState state)
    {
        return new NoopDisposable();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
        var color = VoiceAttackColor.Red;
        
        switch (logLevel)
        {
            case LogLevel.Trace:
                color = VoiceAttackColor.Black;
                break;
            case LogLevel.Debug:
                color = VoiceAttackColor.Gray;
                break;
            case LogLevel.Information:
                color = VoiceAttackColor.Blue;
                break;
            case LogLevel.Warning:
                color = VoiceAttackColor.Yellow;
                break;
            case LogLevel.Error:
                color = VoiceAttackColor.Red;
                break;
            case LogLevel.Critical:
                color = VoiceAttackColor.Purple;
                break;
            case LogLevel.None:
                color = VoiceAttackColor.Black;
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null);
        }
        
        _proxy.Log.Write(formatter(state, exception), color);
    }
    
    public class NoopDisposable : IDisposable
    {
        public void Dispose()
        {
        }
    }
}