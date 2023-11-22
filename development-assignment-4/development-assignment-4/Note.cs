using System;
using System.Numerics;
using Raylib_cs;

namespace development_assignment_4
{
    internal class Note
    {
        public Vector2 position;
        public Vector2 size;
        public float speedY;
        public Color color = Color.BLACK;
        Random rng = new Random();

        public Note()
        {
            size.X = 125;
            size.Y = 60;
            position.X = 0;
            position.Y = 0;
            speedY = 10;
        }

        public void Draw()
        {
            Raylib.DrawRectangleV(position, size, color);
        }

        public void Move()
        {
            position.Y += speedY;
        }

        public void DecideLane()
        {
            int noteLane = rng.Next(4);

            if (noteLane == 0)
            {
                position.X = 0;
            }

            else if (noteLane == 1)
            {
                position.X = 125;
            }

            else if (noteLane == 2)
            {
                position.X = 250;
            }

            else
            {
                position.X = 375;
            }
        }
    }
}
