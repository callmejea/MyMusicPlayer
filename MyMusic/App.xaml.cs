namespace MyMusic;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        
        MainPage = new AppShell();
	}

    protected override Window CreateWindow(IActivationState activationState)
    {
        Window window = base.CreateWindow(activationState);

        // Manipulate Window object

        var displayInfo = DeviceDisplay.Current.MainDisplayInfo;


        if (displayInfo.Density > 0)
        {
            // Center the window
            window.X = (displayInfo.Width / displayInfo.Density - window.Width) / 2;
            window.Y = (displayInfo.Height / displayInfo.Density - window.Height) / 2;
        }

        window.Width = 600;
        window.Height = 800;

        return window;
    }
}
