using System.Collections.ObjectModel;
using System.IO;
using Microsoft.Maui.Controls.Shapes;

namespace MyMusic.Models
{
    internal class LocalPage
    {
        public int currentIndex = 0;

        public ObservableCollection<Music> MusicList { get; set; } = new ObservableCollection<Music>();
        public Collection<int> hisotry = new Collection<int>();

        public LocalPage() => LoadMusic();

        public void LoadMusic()
        {
            if (!Directory.Exists(Lib.config.LocalDir))
            {
                return;
            }
            DirectoryInfo folder = new(Lib.config.LocalDir);
            int i = 0;
            foreach (FileInfo file in folder.GetFiles("*.mp3"))
            {
                MusicList.Add(new Music()
                {
                    Name = file.Name,
                    Author = "-",
                    TimeLength = 60,
                    Ablum = "-",
                    Url = file.FullName,
                    FileType = 1,
                    Index = i,
                });
                i++;
            }
            hisotry.Add(0);
        }

        public Music GetCurrentMusic()
        {
            return MusicList[currentIndex];
        }

        public int GetCurrentIndex()
        {
            return currentIndex;
        }

        public void SetCurrentIndex(int i)
        {
            currentIndex = i;
        }

        public void CurrentIndexPlus()
        {
            currentIndex++;
        }

        public void CurrentIndexMinus()
        {
            currentIndex--;
        }
    }
}
