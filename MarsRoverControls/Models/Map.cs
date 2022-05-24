using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverControls.Models
{
    public class Map
    {
        public int YAxisLabelSize { get; }
        public int Height { get; }
        public int Width { get; }
        public int XAxisCalibrator { get; }
        public int YAxisCalibrator { get; }
        public string EmptyXAxisBoarder { get; set; }

        public Map(int[] mapDimensions)
        {
            int xAxisBoardersSize = 2;
            int yAxisBoardersSize = 2;
            

            YAxisLabelSize = (mapDimensions[0] - 1).ToString().Length;
            Height = mapDimensions[0] + 1;
            Width = YAxisLabelSize + mapDimensions[1] + xAxisBoardersSize;
            XAxisCalibrator = -YAxisLabelSize - xAxisBoardersSize;
            YAxisCalibrator = -(yAxisBoardersSize/2);
            EmptyXAxisBoarder = MapBuilder.GenerateSpaces(YAxisLabelSize);
        }
    }
}
