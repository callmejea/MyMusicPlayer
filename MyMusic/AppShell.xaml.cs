using MyMusic.Models;

namespace MyMusic;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(Views.ConfigPage), typeof(Views.ConfigPage));
		// load config
		Lib.LoadConfig();
    }
}
