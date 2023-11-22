using System;
using System.Numerics;
using Raylib_cs;

namespace development_assignment_4
{
    internal class Note
    {
        public Vector2 position;
        public Vector2 size;
        public float speed;
        public Color color = Color.BLACK;
        Random rng = new Random();

        public Note()
        {
            size.X = 125;
            size.Y = 60;
            position.X = 0;
            position.Y = 0;
            speed = 10;
        }

        public void Draw()
        {
            Raylib.DrawRectangleV(position, size, color);
        }

       
        public void Move()
        {
            position.Y += speed;
        }


        // Makes the X position of the note one of the 4 lanes randomly
        public void DecideLane()
        {
            position.X = rng.Next(4)*size.X;
        }
    }
}
