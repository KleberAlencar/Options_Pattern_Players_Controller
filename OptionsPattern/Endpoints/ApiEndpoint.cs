namespace OptionsPattern.Endpoints;

public static class ApiEndpoint
{
    private const string ApiBase = "api";
    
    public static class Players
    {
        private const string Base = $"{ApiBase}/players";
        public const string Get = $"{Base}";
        public const string GetHealth = $"{Base}/health";
        public const string GetSnapshot = $"{Base}/snapshot";
        public const string GetMonitor = $"{Base}/monitor";
    }
}