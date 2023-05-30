using System;
namespace MyMusic.Models
{
	public class UserConfig
	{
		public enum PlayType {
            Sequential,
			Random
        };

		public int UserPlayType = 0;
        public string LocalDir = "";
		//public string ListUrl = "";
		//public string ContentUrl = "";
	}
}

