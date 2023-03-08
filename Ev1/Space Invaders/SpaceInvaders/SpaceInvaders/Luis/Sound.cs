using System.Media;

namespace Luis
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
        public static void PlayRandom(string[] array)
        {
            int n = (int)Utils.RandomRange(0, (float)array.Length - 0.00001f);
                Play(ratSounds[n]);
            
        }

    }
}
