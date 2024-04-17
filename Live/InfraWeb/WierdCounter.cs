namespace InfraWeb;

public class WierdCounter : ICounter
{
    private readonly ILogger<Counter> _logger;
    private int _counter = 0;

    public WierdCounter(ILogger<Counter> logger)
    {
        _logger = logger;
    }

    public void Increase()
    {
        _logger.LogCritical($"Counter Value = {--_counter}");
    }
}
