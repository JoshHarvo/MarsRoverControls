namespace MarsRoverControls.Functions
{
    public class RoverControls
    {
        private RoverData _data { get; }
        private ConsoleBuilder _console { get; }
        private Parser _parser { get; }

        public RoverControls (RoverData data, ConsoleBuilder console)
        {
            _data = data;
            _console = console;
            _parser = new Parser(_data, _console);

            ControlLoop();
        }

        public void ControlLoop()
        {
            while(true)
            {
                var input = Console.ReadLine();
                
                if (input.TrimEnd() != "")
                {
                    _parser.Parse(input.ToLower());
                    ExecuteCommands();
                }
                _console.AwaitCommand();
            }
        }

        private void ExecuteCommands()
        {
            foreach(Command command in _data.Commands)
            {
                if (command.Type == "rotate")
                    RotateRover(command);

                else if (command.Type == "move")
                {
                    MoveRover(command);

                    if (!ValidateMovement())
                    {
                        _console.Boundary();
                        _data.Commands.Clear();
                        return;
                    }
                }
                else if (command.Type == "map")
                    _console.ToggleMap();
            }

            _console.GiveCoordinate();
            _data.Commands.Clear();
        }

        private void RotateRover(Command command)
        {
            if (_data.Oritentation[0] == -1 && _data.Oritentation[1] == 0)
            {
                if (command.Rotate == "left")
                    _data.Oritentation = new int[] { 0, -1 };
                else
                    _data.Oritentation = new int[] { 0, 1 };
            }
            else if (_data.Oritentation[0] == 0 && _data.Oritentation[1] == 1)
            {
                if (command.Rotate == "left")
                    _data.Oritentation = new int[] { -1, 0 };
                else
                    _data.Oritentation = new int[] { 1, 0 };
            }
            else if (_data.Oritentation[0] == 1 && _data.Oritentation[1] == 0)
            {
                if (command.Rotate == "left")
                    _data.Oritentation = new int[] { 0, 1 };
                else
                    _data.Oritentation = new int[] { 0, -1 };
            }
            else if (_data.Oritentation[0] == 0 && _data.Oritentation[1] == -1)
            {
                if (command.Rotate == "left")
                    _data.Oritentation = new int[] { 1, 0 };
                else
                    _data.Oritentation = new int[] { -1, 0 };
            }
        }

        private void MoveRover(Command command)
        {
            _data.RoverCoordinate[0] = (_data.Oritentation[0] * command.Distance) + _data.RoverCoordinate[0];
            _data.RoverCoordinate[1] = (_data.Oritentation[1] * command.Distance) + _data.RoverCoordinate[1];
        }

        private bool ValidateMovement()
        {
            if (_data.RoverCoordinate[0] < 0)
            {
                _data.RoverCoordinate[0] = 0;
                return false;
            }
            else if (_data.RoverCoordinate[0] > 99)
            {
                _data.RoverCoordinate[0] = 99;
                return false;
            }
            else if (_data.RoverCoordinate[1] < 0)
            {
                _data.RoverCoordinate[1] = 0;
                return false;
            }
            else if (_data.RoverCoordinate[1] > 99)
            {
                _data.RoverCoordinate[1] = 99;
                return false;
            }
            return true;
        }
    }
}