using System;
using System.Numerics;
using Raylib_cs;

namespace development_assignment_4
{

    public class Note
    {
        public int positionY;
        public int positionX;
        public int sizeY;
        public int sizeX;
        public int speed;
        public Random rng = new Random();


        public Note()
        {
            sizeX = 125;
            sizeY = 60;
            speed = 7;

        }
        public void decideLane() 
        {
            positionX = rng.Next(4) * sizeX;
        }
    }
}
