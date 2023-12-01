using System;
using System.Numerics;
using Raylib_cs;

namespace development_assignment_4
{
    internal class Program
    {
        static string title = "Game Title";
        static FallingNote[] notes = new FallingNote[100];
        static float timer = 0;
        static int noteIndex = 0;
        static Vector2 noteHitposition = new Vector2(-125, 675);
        static Vector2 noteHitsize = new Vector2(125, 10);

        static void Main(string[] args)
        {
            Raylib.InitWindow(500, 800, title);
            Raylib.SetTargetFPS(60);

            Setup();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Update();

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }

        static void Setup()
        {
            notes[0] = new FallingNote();

            for (int i = 0; i < notes.Length; i++)
            {
                notes[i] = new FallingNote();
            }
        }

        static void Update()
        {
            timer += Raylib.GetFrameTime();
            if (timer >= 0.6)
            {
                if (noteIndex < notes.Length)
                {
                    notes[noteIndex] = new FallingNote();
                    noteIndex++;
                }
                else
                {
                    noteIndex = 0;
                }

                timer = 0;
            }

            foreach (FallingNote note in notes)
            {
                note.Draw();
                note.Move();
            }

            float column = -125;

            if (Raylib.IsKeyDown(KeyboardKey.KEY_H) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                column = 0;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_J) || Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                column = 125;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_K) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                column = 250;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_L) || Raylib.IsKeyDown(KeyboardKey.KEY_F))
            {
                column = 375;
            }

            noteHitposition.X = column;

            float leftEdge = noteHitposition.X;
            float topEdge = noteHitposition.Y;

            foreach (FallingNote note in notes)
            {
                bool isWithinX = false;
                bool isWithinY = note.position.Y + note.size.Y > topEdge;
                if (column == note.noteColumn) { isWithinX = true; }
                if (isWithinX && isWithinY) note.position.Y = note.position.Y + 800;
            }

            Raylib.DrawRectangleV(noteHitposition, noteHitsize, Color.SKYBLUE);
        }
    }

    internal class FallingNote
    {
        public Vector2 position;
        public Vector2 size;
        public float speed;
        public Color color = Color.BLACK;
        Random rng = new Random();
        public float noteColumn;

        public FallingNote()
        {
            size.X = 125;
            size.Y = 60;
            position.X = rng.Next(4) * 125;
            position.Y = -60;
            speed = 250;
            noteColumn = position.X;
        }

        public void Draw()
        {
            Raylib.DrawRectangleV(position, size, color);
        }

        public void Move()
        {
            float deltaTime = Raylib.GetFrameTime();
            float noteForce = deltaTime * speed;
            position.Y += noteForce;

            if (position.Y > Raylib.GetScreenHeight())
            {
                position.Y = -60;
                DecideLane();
            }
        }

        public void DecideLane()
        {
            noteColumn = rng.Next(4) * 125;
            position.X = noteColumn;
        }
    }
}
