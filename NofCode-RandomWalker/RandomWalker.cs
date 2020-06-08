using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using System.Windows.Shapes;

namespace NofCode_RandomWalker
{
    public class RandomWalker
    {
        //2D panel for the Walker
        private Canvas _sketch;

        public double PosX { get; set; }
        public double PosY { get; set; }

        //Walker's ellipse geometry
        private int _width;
        private int _height;

        //Walker shape, initialized as a circle
        private Ellipse _walkerEllipse;

        public RandomWalker(Canvas Sketch, short Radius)
        {
            _sketch = Sketch;
            _height = Radius;
            _width = Radius;
            _walkerEllipse = (new Ellipse()
            {
                Width = _width,
                Height = _height,
                Fill = new SolidColorBrush(Colors.Crimson),
            });
            _sketch.Children.Add(_walkerEllipse);
        }
        
        public void Display()
        {
            Canvas.SetLeft(_walkerEllipse, PosX);
            Canvas.SetTop(_walkerEllipse, PosY);
        }
    }
}
