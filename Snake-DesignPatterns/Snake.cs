using Snake_DesignPatterns.Controllers;
using Snake_DesignPatterns.Controllers.Events;
using Snake_DesignPatterns.Views;
using System;
using System.IO;
using System.Text;

namespace Snake_DesignPatterns
{
    class Snake
    {
        public static CTick TickThread;
        public static EventManager EventManager;
        public static VInput InputThread;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;

            EventManager = new EventManager();
            TickThread = new CTick();
            InputThread = new VInput();

            //Starts the input manager thread
            InputThread.Start();

            //Start the ticks trigger thread
            TickThread.Start();


            //Starts a new game
            CGame.NewGame();

            string[] soundFile = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), "*.wav");
            System.Media.SoundPlayer sp = new System.Media.SoundPlayer();

            //Infinite loop for the game
            while (true)
            {
                foreach (string music in soundFile)
                {
                    Console.WriteLine(music);
                    sp.SoundLocation = music;
                    sp.PlaySync();
                }
            }

        }
    }
}
