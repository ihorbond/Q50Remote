using Q50Remote.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Q50Remote.Models
{
    public class CarCommandModel
    {
        public CarCommandEnum CarCommandEnum { get; set; }
        public int Col { get; set; }
        public int Row { get; set; }

        public CarCommandModel()
        {
            Debug.WriteLine("Called");
        }

        public CarCommandModel(CarCommandEnum carCommandEnum, int col, int row)
        {
            Debug.WriteLine("Called");
            CarCommandEnum = carCommandEnum;
            Col = col;
            Row = row;
        }
    }
}
