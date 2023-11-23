using System;
using System.Numerics;
using Raylib_cs;

namespace development_assignment_4
{
    public class Note
    {
        public Vector2 position;
        public Vector2 size;
        public float speed;
        public Color color = Color.BLACK;
        Random rng = new Random();
        public float notePosition;

        
        public Note()
        {
            size.X = 125;
            size.Y = 60;
            position.X = 0;
            position.Y = 0;
            speed = 7;
            notePosition = position.Y + 60;
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
