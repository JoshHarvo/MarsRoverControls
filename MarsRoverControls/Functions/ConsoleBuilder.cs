namespace MarsRoverControls.Functions
{
    public class ConsoleBuilder
    {
        private RoverData _data { get; }
        private Strings _strings { get; }
        private MapBuilder _map { get; }

        public ConsoleBuilder(RoverData data)
        {
            _data = data;
            _strings = new Strings(_data);
            _map = new MapBuilder(_data);

            Introduction();
        }

        private static void WriteToConsole(string text)
        {
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
        }

        private static void ErrorToConsole(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            WriteToConsole(message);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal void Introduction()
        {
            WriteToConsole(_strings.Introduction0());
            Thread.Sleep(1000);

            Console.ForegroundColor= ConsoleColor.White;
            WriteToConsole(Strings.Introduction1);
            Console.ForegroundColor= ConsoleColor.Gray;

            WriteToConsole(Strings.AwaitCommandIntroduction);
        }
        
        internal void AwaitCommand()
        {
            Random random = new Random();
            int message = random.Next(1, 4);

            if (message == 1)
                WriteToConsole(Strings.AwaitCommand1);
            else if (message == 2)
                WriteToConsole(Strings.AwaitCommand2);
            else if (message == 3)
                WriteToConsole(Strings.AwaitCommand3);
        }

        internal void GiveCoordinate()
        {
            _data.UpdateDirectionData();

            if (_map.Enabled == true)
                _map.BuildMap();

            Console.ForegroundColor = ConsoleColor.Green;
            WriteToConsole(_strings.GiveCoordinate());
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal void Boundary()
        {
            _data.UpdateDirectionData();

            if (_map.Enabled == true)
                _map.BuildMap();

            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteToConsole(_strings.Boundary());
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        internal void TooManyCommandsError()
            => ErrorToConsole(Strings.TooManyInputs);

        internal void InvalidCommandError(string command)
            => ErrorToConsole(Strings.InvalidCommand(command));
        
        internal void ToggleMap ()
            => _map.Enabled = !_map.Enabled;
    }
}