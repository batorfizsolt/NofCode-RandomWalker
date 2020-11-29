using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NofCode_RandomWalker
{
    public class PerlinWalker : RandomWalker
    {
        public PerlinWalker(Canvas Sketch, short Radius) : base(Sketch, Radius)
        {

        }

        public override void Reset()
        {
            base.Reset();
        }

        public override void RandomMove(int speed)
        {
            base.RandomMove(speed);
        }

        public override void Display()
        {
            base.Display();
        }
    }
}
