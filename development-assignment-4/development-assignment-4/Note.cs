using System;
using System.Drawing;
using System.Numerics;
using Raylib_cs;

namespace development_assignment_4
{

    public class Note
    {
        public Random rng = new Random();
        public void decideLane()
        {
            Program.position.X = rng.Next(4) * Program.size.X;
        }
    }
}
