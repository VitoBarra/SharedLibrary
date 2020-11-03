using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLibrary.AspNetCore.ChartJsTool
{
    public class ChartData
    {
        public string DatasetName = "Chart Tool";
        public IList<double?> Data = new List<double?>();
        public ChartPalette ChartPalette = ChartPalette.blue;
    }
}
