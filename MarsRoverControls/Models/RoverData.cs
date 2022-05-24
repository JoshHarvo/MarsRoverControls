namespace MarsRoverControls.Models
{
    public class RoverData
    {
        public int[] RoverCoordinate { get; set; } = new int[] {0,0};
        public int[] MapDimensions { get; set; } = new int[] { 100, 100 };
        public int[] Oritentation { get; set; } = new int[] { 1, 0 };
        public string RoverToken { get; set; } = "v";
        public string Direction { get; set; } = "south";
        public  List<Command> Commands { get; set; } = new ();

        public void UpdateDirectionData()
        {
            if (Oritentation[0] == -1 && Oritentation[1] == 0)
            {
                RoverToken = "^";
                Direction = "North";
            }
            else if (Oritentation[0] == 0 && Oritentation[1] == 1)
            {
                RoverToken = ">";
                Direction = "East";
            }
            else if (Oritentation[0] == 1 && Oritentation[1] == 0)
            {
                RoverToken = "v";
                Direction = "South";
            }
            else
            {
                RoverToken = "<";
                Direction = "West";
            }
        }
    }
}
