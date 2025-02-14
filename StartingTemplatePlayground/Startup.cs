namespace StartingTemplatePlayground
{
    public class Startup
    {
        public Startup(IConfiguration config)
        {
            ConfigurationBinder = config;
        }
        public IConfiguration ConfigurationBinder { get; }
    }
}
