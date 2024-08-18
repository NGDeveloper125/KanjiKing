using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace KanjiKingInterface
{
    public class AudioPlayer
    {
        private MediaPlayer _mediaPlayer;

        public AudioPlayer()
        {
            _mediaPlayer = new MediaPlayer();
        }

        public void PlayAudio(string filePath)
        {
            _mediaPlayer.Open(new Uri(filePath, UriKind.RelativeOrAbsolute));
            _mediaPlayer.Play();
        }

        public void StopAudio()
        {
            _mediaPlayer.Stop();
        }

        public void PauseAudio()
        {
            _mediaPlayer.Pause();
        }

        public void ResumeAudio()
        {
            _mediaPlayer.Play();
        }
    }
}
