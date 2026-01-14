using NewsApp.Models;

namespace NewsApp.Pages;

public partial class DetailsPage : ContentPage
{
    private string NewsUrl { get; set; }

    public DetailsPage(Article article)
    {
        InitializeComponent();
        lblNewsTitle.Text = article.Title;
        lblNewsDescrption.Text = article.Description;
        imgNews.Source = article.Image;
        lblContent.Text = article.Content;
        NewsUrl =  article.Url;
    }

    private async void ShareItem_OnClicked(object sender, EventArgs e)
    {
        await Share.RequestAsync(new ShareTextRequest
        {
            Text = lblNewsTitle.Text,
            Uri = NewsUrl,
            Title = "Share News"
        });
    }
}