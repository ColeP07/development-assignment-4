// Include necessary libraries
using Raylib_cs;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace development_assignment_4
{
    internal class Program
    {
        // If you need variables in the Program class (outside functions), you must mark them as static
        static string title = "Game Title";
        static Note[] notes = new Note[100];
        static float timer = 0;
        static int noteIndex = 0;

        static public Vector2 noteHitobject = new Vector2(125, 10);
        static public Vector2 noteHitposition = new Vector2(0, 675);

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(500, 800, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);

            // Setup your game. This is a function YOU define.
            Setup();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

                // Your game code here. This is a function YOU define.
                Update();

                // Stop drawing to the canvas, begin displaying the frame
                Raylib.EndDrawing();
            }
            // Close the window
            Raylib.CloseWindow();
        }

        static void Setup()
        {
            // Your one-time setup code here
            notes[0] = new Note();

            for (int i = 0; i < notes.Length; i++)
            {
                notes[i] = new Note();
            }
        }

        static void Update()
        {
            // Your game code run each frame here
            
            // Notes
            timer += Raylib.GetFrameTime();
            if (timer >= 0.5)
            {
               if (noteIndex < notes.Length)
                {
                    notes[noteIndex] = new Note();
                    notes[noteIndex].DecideLane();
                    noteIndex++;
                }
                else
                {
                    noteIndex = 0;
                }

               timer = 0;
            }

            foreach (Note note in notes)
            {
                note.Draw();
                note.Move();
            }


            //Adding controls

            //1st column
            if (Raylib.IsKeyDown(KeyboardKey.KEY_H) || Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                noteHitposition.X = 0;
            }

            // 2nd column
            if (Raylib.IsKeyDown(KeyboardKey.KEY_J) || Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                noteHitposition.X = 125;
            }

            // 3rd column
            if (Raylib.IsKeyDown(KeyboardKey.KEY_K) || Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                noteHitposition.X = 250;
            }

            // 4th column
            if (Raylib.IsKeyDown(KeyboardKey.KEY_L) || Raylib.IsKeyDown(KeyboardKey.KEY_F))
            {
                noteHitposition.X = 375;
            }

            // adding hit detection

            if (notePosition)
            Raylib.DrawRectangleV(noteHitposition, noteHitobject, Color.SKYBLUE);
            
            

        }
    }
}