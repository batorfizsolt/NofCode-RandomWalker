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
using SimplexNoise;

namespace NofCode_RandomWalker
{
    public class RandomWalker
    {
        //2D panel for the Walker
        private Canvas _sketch;

        //Walker's actual position
        public double PosX { get; set; }
        public double PosY { get; set; }

        //Walker's geometry
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
     
        public virtual void Reset()
        {
            this.PosX = 0;
            this.PosY = 0;
        }

        public virtual void RandomMove(int speed)
        {
            //get random directions: -1,0,1
            int choiceX = new Random().Next(3) - 1;
            int choiceY = new Random().Next(3) - 1;
            
            this.PosX += choiceX * speed;
            this.PosY += choiceY * speed;
        }
        
        public virtual void Display()
        {
            //Calculate actual position using canvas center points
            Canvas.SetLeft(_walkerEllipse, (_sketch.ActualWidth / 2) + this.PosX);
            Canvas.SetTop(_walkerEllipse, (_sketch.ActualHeight / 2) - this.PosY);
        }
    }
}
