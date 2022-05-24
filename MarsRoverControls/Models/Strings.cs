namespace MarsRoverControls.Models
{
    public class Strings
    {
        RoverData _data { get; }

        public Strings (RoverData data)
        {
            _data = data;
        }

        internal string Introduction0() 
            => "Welcome to the Mars Rover Control Console.\n" +
            "The Rover is currently in a crater which we are representing as a 100mx100m grid.\n" +
            $"It is waiting for your command at coordinate ({_data.RoverCoordinate[0]}, {_data.RoverCoordinate[1]}) and is currently facing {_data.Direction}.\n" +
            "To move the rover, enter a direction of travel followed by a distance in meters (50m).\n" +
            "You can turn the rover on the spot at right angles using the commands 'left' and 'right'.\n" +
            "To view the map, enter the command 'map'\n"+
            "A maximum of 5 commands can be entered at once, just leave a space between each one.\n\n";
            
        internal static string Introduction1 { get; } = "Please drive responsibly.\n\n";

        internal static string AwaitCommand0 { get; } = "Enter your first command...\n\n";

        internal static string AwaitCommand1 { get; } = "The Rover Awaits your next command...\n\n";
        
        internal static string AwaitCommand2 { get; } = "Please enter another command...\n\n";
        
        internal static string AwaitCommand3 { get; } = "Command the Rover, if you dare...\n\n";

        internal static string TooManyInputs { get; } = "Your Input was invalid. Please enter a maxium of 5 commands.\n";

        internal static char Meter { get; } = 'm';

        internal string Boundary()
            => $"The Rover has reached the {_data.Direction} Boundary.\n" +
            $"At coordinate ({_data.RoverCoordinate[0]},{_data.RoverCoordinate[1]}).\n" +
            "Please turn the rover if you wish to move again.\n";
        
        internal string GiveCoordinate()
            => $"The the Rover is currently at coordinate ({_data.RoverCoordinate[0]},{_data.RoverCoordinate[1]}) and is facing {_data.Direction}.\n";

        internal static string InvalidCommand(string input)
            => $"'{input}' is not a valid command. Please enter 'left', 'right', or a distance in meters.\n";
    }
}