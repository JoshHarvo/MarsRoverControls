namespace MarsRoverControls.Functions
{

    public class MapBuilder
    {
        private RoverData _data { get; }
        private Map _map;

        public bool Enabled { get; set; } 

        public MapBuilder(RoverData data)
        {
            Enabled = false;
            _data = data;
            _map = new Map(_data.MapDimensions);
        }

        private void WriteMapToConsole(string mapLine)
        {
            foreach (char c in mapLine)
            {
                Console.Write(c);
            }
        }

        public void BuildMap()
        {
            string mapLine;

            for (var yAxis = _map.Height; yAxis > -1; yAxis--)
            {
                int calibratedYAxis = yAxis + _map.YAxisCalibrator;

                if (yAxis == _map.Height || yAxis == 1)
                    mapLine = XAxisBoarder();
                else if (yAxis == 0)
                    mapLine = XAxisLabels();
                else
                    mapLine = BuildXAxis(calibratedYAxis, yAxis);

                WriteMapToConsole(mapLine + "\n");
            }
            Enabled = false;
        }

        private string BuildXAxis(int calibratedYAxis, int yAxis)
        {
            var xAxisContent = "";

            for (var xAxis = 0; xAxis <= _map.Width; xAxis++)
            {
                if (xAxis == 0)
                {
                    xAxisContent = xAxisContent + YAxisLabels(calibratedYAxis);
                    xAxis = xAxis + _map.YAxisLabelSize;
                }
                else if (xAxis == _map.YAxisLabelSize + 1 || xAxis == _map.Width)
                    xAxisContent = xAxisContent + "|";

                else if (_data.RoverCoordinate[0] == (calibratedYAxis) && _data.RoverCoordinate[1] == (xAxis + _map.XAxisCalibrator))
                    xAxisContent = xAxisContent + _data.RoverToken;

                else
                    xAxisContent = xAxisContent + " ";
            }

            return xAxisContent;
        }

        private string YAxisLabels(int calibratedYAxis)
        {
            if (calibratedYAxis % 10 == 0)
            {
                var spacesNeeded = _map.YAxisLabelSize - calibratedYAxis.ToString().Length;

                if (calibratedYAxis.ToString().Length == _map.YAxisLabelSize)
                    return calibratedYAxis.ToString();

                return GenerateSpaces(spacesNeeded) + calibratedYAxis.ToString();
            }
            else
                return _map.EmptyXAxisBoarder; 
        }

        private string XAxisBoarder()
        {
            var xBoarder = _map.EmptyXAxisBoarder;

            for (var xAxis = _map.YAxisLabelSize; xAxis < _map.Width; xAxis++)
                xBoarder = xBoarder + "-";

            return xBoarder;
        }

        private string XAxisLabels()
        {
            var xLabels = _map.EmptyXAxisBoarder;
            var calibratdXAxis = 0;

            for (var xAxis = 0; xAxis < _data.MapDimensions[1]; xAxis++)
            {
                calibratdXAxis = xAxis + _map.XAxisCalibrator;

                if (calibratdXAxis % 10 == 0)
                {
                    xLabels = xLabels + calibratdXAxis.ToString();
                    xAxis = xAxis + calibratdXAxis.ToString().Length;
                }
                else
                    xLabels = xLabels + " ";
            }

            return xLabels;
        }

        public static string GenerateSpaces(int spacesNeeded)
        {
            var spaces = "";

            for (var i = 0; i != spacesNeeded; i++)
            {
                spaces = spaces + " ";
            }

            return spaces;
        }
    }
}