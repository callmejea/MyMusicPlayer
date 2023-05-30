namespace MyMusic.Views;

using System.ComponentModel;
using CommunityToolkit.Maui.Core.Primitives;
using CommunityToolkit.Maui.Views;
using Microsoft.Maui;
using MyMusic.Models;

public partial class LocalPage : ContentPage
{
    private readonly Models.LocalPage MP = new();

    public LocalPage()
	{
		InitializeComponent();

        BindingContext = new Models.LocalPage();
        mediaElement.MediaEnded += MediaElement_MediaEnded;
        mediaElement.MediaOpened += MediaElement_MediaOpened;
        mediaElement.MediaFailed += MediaElement_MediaFailed;
        if (Lib.config.UserPlayType == (int)UserConfig.PlayType.Sequential)
        {
            PlayTypeText.Text = "Sequential";
        }
        else
        {
            Lib.config.UserPlayType = (int)UserConfig.PlayType.Sequential;
            PlayTypeText.Text = "Random";
        }
    }

    private void MusicListCoeection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var music = (Models.Music)e.CurrentSelection[0];
        Play(music);
    }

    private async void Play(Models.Music music)
    {
        // 本次开始播放时记录上一次的ID
        if (MP.hisotry.Count > 0 && MP.hisotry.Last() != MP.currentIndex)
        {
            MP.hisotry.Add(MP.currentIndex);
        }
        if (mediaElement.CurrentState == MediaElementState.Playing)
        {
            mediaElement.Stop();
        }

        if (music.FileType == 1)
        {
#if WINDOWS
            mediaElement.Source = new Uri(music.Url).LocalPath;
#else
            mediaElement.Source = new Uri(music.Url);
#endif
        }
        else
        {
            mediaElement.Source = music.Url;
        }

        nowMusicName.Text = "Playing：" + music.Name;
        MP.SetCurrentIndex(music.Index);


        await Task.Delay(200); // 添加短暂延迟

        mediaElement.Play();
    }

    void ContentPage_Unloaded(object sender, EventArgs e)
    {
        mediaElement?.Handler?.DisconnectHandler();
    }

    void OnPlayPauseButtonClicked(object sender, EventArgs e)
    {
        if (mediaElement.CurrentState == MediaElementState.Stopped ||
            mediaElement.CurrentState == MediaElementState.Paused)
        {
            mediaElement.Play();

        }
        else if (mediaElement.CurrentState == MediaElementState.Playing)
        {
            mediaElement.Pause();
        }
    }

    void OnStopButtonClicked(object sender, EventArgs e)
    {
        mediaElement.Stop();
    }

    private void MediaElement_MediaEnded(object sender, EventArgs e)
    {
        MP.CurrentIndexPlus();
        Play(MP.GetCurrentMusic());
    }


    private void MediaElement_MediaOpened(object sender, EventArgs e)
    {
        Console.WriteLine("opened");
    }

    private void MediaElement_MediaFailed(object sender, EventArgs e)
    {
        Console.WriteLine(e.ToString());
    }

    void PreviousClicked(System.Object sender, System.EventArgs e)
    {
        if(Lib.config.UserPlayType == (int)UserConfig.PlayType.Sequential)
        {
            MP.CurrentIndexMinus();
        }
        else
        {
            if (MP.hisotry.Count > 0)
            {
                MP.SetCurrentIndex(MP.hisotry.Last());
            }
        }
        Play(MP.GetCurrentMusic());
    }

    void NextClicked(System.Object sender, System.EventArgs e)
    {
        if (Lib.config.UserPlayType == (int)UserConfig.PlayType.Sequential)
        {
            MP.CurrentIndexPlus();
        }
        else
        {
            Random r = new();
            int i = r.Next(0, MP.MusicList.Count - 1);
            if (MP.hisotry.Count > 0)
            {
                MP.SetCurrentIndex(i);
                int l = MP.GetCurrentIndex();
            }
        }
        Play(MP.GetCurrentMusic());
    }

    void PlayTypeClicked(System.Object sender, System.EventArgs e)
    {
        if(Lib.config.UserPlayType == (int)UserConfig.PlayType.Sequential)
        {
            Lib.config.UserPlayType = (int)UserConfig.PlayType.Random;
            PlayTypeText.Text = "Sequential";
        }
        else
        {
           Lib.config.UserPlayType = (int)UserConfig.PlayType.Sequential;
            PlayTypeText.Text = "Random";
        }
        Lib.SaveConfig();
    }
}

