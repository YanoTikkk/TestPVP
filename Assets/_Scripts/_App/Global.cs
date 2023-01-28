using _Config;

namespace _App
{
    public static class Global
    {
        public static IAppFields Fields { private set; get; }
        public static ICoreConfig Config { private set; get; }
        public static IInputManager Input { private set; get; }

        public static void Setup
        (
            IAppFields fields,
            ICoreConfig config,
            IInputManager input
        )
        {
            Fields = fields;
            Config = config;
            Input = input;
        }
    }
}