namespace MyMusic.Models
{
    internal class Music
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public int TimeLength { get; set; }
        public string Ablum { get; set; }
        public string Url { get; set; }
        public int FileType { get; set; } // 0 http file ; 1 local file
        public int Index { get; set; }
    }
}
