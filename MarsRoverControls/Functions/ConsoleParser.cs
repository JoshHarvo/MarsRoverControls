namespace MarsRoverControls.Functions
{
    public class Parser
    {
        RoverData _data { get; }
        ConsoleBuilder _console { get; }

        public Parser (RoverData data, ConsoleBuilder console)
        {
            _data = data;
            _console = console;
        }

        public void Parse(string input)
        {

            string[] words = input.TrimEnd().Split(' ');

            if (words.Length < 6)
                ExtractCommands(words);
            else
                _console.TooManyCommandsError();
        }

        private void ExtractCommands(string[] words)
        {
            foreach (var word in words)
            {
                if (word == "left" || word == "right")
                {
                    _data.Commands.Add(new Command
                    {
                        Type = "rotate",
                        Rotate = word,
                        Distance = 0
                    });
                }
                else if (word == "map")
                {
                    _data.Commands.Add(new Command
                    {
                        Type = "map",
                        Distance = 0
                    });
                }
                else
                {
                    try
                    {
                        _data.Commands.Add(new Command
                        {
                            Type = "move",
                            Distance = ExtractDistance(word)
                        });
                    }
                    catch
                    {
                        _console.InvalidCommandError(word);
                        return;
                    }
                }
            }
        }

        private int ExtractDistance (string word)
        {
            if(word.EndsWith("m"))
                word = word.TrimEnd(Strings.Meter);

            return int.Parse(word);
        }
    }
}