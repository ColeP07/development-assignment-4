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
        public float noteColumn;
        
        public Note()
        {
            size.X = 125;
            size.Y = 60;
            position.X = 0;
            position.Y = 0;
            speed = 250;
            noteColumn = rng.Next(4) * 125;
        }
        public void Draw()
        {
            Raylib.DrawRectangleV(position, size, color);
        }
        public void Move()
        {
            float deltatime = Raylib.GetFrameTime();
            float noteForce = deltatime * speed;
            position.Y += noteForce;
        }
        public void DecideLane()
        {
            noteColumn = rng.Next(4)*125;
            position.X = noteColumn;
        }
    }
}
