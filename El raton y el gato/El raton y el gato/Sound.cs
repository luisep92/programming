using System.Media;
using System.Reflection.Metadata.Ecma335;

namespace El_raton_y_el_gato
{
    internal class Sound
    {
        public static string[] ratSounds =
        {
            "resources/rata.wav",
            "resources/mellamanrata.wav",
            "resources/mellamanchepudo.wav",
            "resources/ultraderecha.wav"
        };
        public static void Play(string path)
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer(path);
                player.Load();
                player.Play();
            }
        }
        
        public void Music()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer("resources/mellamanchepudo.wav");
                player.Load();
                player.PlayLooping();
            }
        }
        public static void PlayRandom(string[] array)
        {
            int n = (int)Utils.RandomRange(0, (float)array.Length);
            Play(ratSounds[n]);
            
        }

    }
}
