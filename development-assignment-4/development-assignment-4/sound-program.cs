using System;
using System.Numerics;
using Raylib_cs;

namespace development_assignment_4
{
    internal class AudioManager
    {
        public Sound noteSound;

        public void Init()
        {
            Raylib.InitAudioDevice();
            noteSound = Raylib.LoadSound("beep beep"); // Using the default beep sound
        }

        public void Unload()
        {
            Raylib.UnloadSound(noteSound);
            Raylib.CloseAudioDevice();
        }

        public void PlayNoteSound()
        {
            Raylib.PlaySound(noteSound);
        }

        public void Update()
        {
            // You can add any audio-related updates here
        }
    }

    internal class FallingNote
    {
        public FallingNote(AudioManager audioManager)
        {
            // Your existing code for FallingNote constructor

            // Play the sound when a note is created
            audioManager.PlayNoteSound();
        }
    }

    internal class Program
    {
        static string title = "Game Title";
        static FallingNote[] notes = new FallingNote[100];
        static float timer = 0;
        static int noteIndex = 0;
        static Vector2 noteHitposition = new Vector2(-125, 675);
        static Vector2 noteHitsize = new Vector2(125, 10);
        static AudioManager audioManager = new AudioManager();

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

            audioManager.Unload(); // Unload audio resources
            Raylib.CloseWindow();
        }

        static void Setup()
        {
            audioManager.Init(); // Initialize audio

            notes[0] = new FallingNote(audioManager);

            for (int i = 0; i < notes.Length; i++)
            {
                notes[i] = new FallingNote(audioManager);
            }
        }

        static void Update()
        {
            // Your existing Update method code

            // Update audio
            audioManager.Update();
        }
    }
}
