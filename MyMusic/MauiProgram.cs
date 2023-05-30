using CommunityToolkit.Maui;

namespace MyMusic;
using CommunityToolkit.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiApp<App>()// Initialize the .NET MAUI Community Toolkit MediaElement by adding the below line of code
            .UseMauiCommunityToolkit()
        .UseMauiCommunityToolkitMediaElement()// After initializing the .NET MAUI Community Toolkit, optionally add additional fonts, and other things
        .ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();
        // Continue initializing your .NET MAUI App here
        return builder.Build();
    }
}