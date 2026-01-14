using System;
using Microsoft.Maui.Controls;
using NewsApp.Pages;

namespace NewsApp;

public partial class App : Application
{
    [Obsolete("Obsolete")]
    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(new NewsPage());
    }
}