using MyMusic.Models;
using Newtonsoft.Json;

namespace MyMusic.Views;

public partial class ConfigPage : ContentPage
{
    public ConfigPage()
	{
		InitializeComponent();
        initConfig();
    }

    private void initConfig() {
        localDir.Text = Lib.config.LocalDir;
    }

    public void SaveClicked(System.Object sender, System.EventArgs e)
	{
        Lib.config.LocalDir = localDir.Text;
        //Lib.config.ListUrl = listPageUrl.Text;
        //Lib.config.ContentUrl = MusicContentUrl.Text;
        Lib.SaveConfig();
    }
}
