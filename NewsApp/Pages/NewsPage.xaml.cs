using System.Collections.ObjectModel;
using NewsApp.Models;
using NewsApp.Services;

namespace NewsApp.Pages;

public partial class NewsPage : ContentPage
{
    public ObservableCollection<string> NewsCategory { get; set; }
    public ObservableCollection<Article> ArticlesList { get; set; }

    private readonly ApiService _apiService;
    private string _currentCategory = "General"; // match casing

    public NewsPage()
    {
        InitializeComponent();
        NewsCategory = new ObservableCollection<string>();
        ArticlesList = new ObservableCollection<Article>();
        LoadCategories();
        _apiService = new ApiService();
        BindingContext = this;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        CvCategory.SelectedItem = "General"; // safe here
        await LoadArticlesAsync(_currentCategory);
    }

    private async Task LoadArticlesAsync(string category)
    {
        if (_currentCategory.Equals(category, StringComparison.OrdinalIgnoreCase) && ArticlesList.Count > 0)
            return;

        _currentCategory = category;

        var newsList = await _apiService.GetNewsAsync(category.ToLower());
        if (newsList?.Articles == null) return;

        ArticlesList.Clear();
        foreach (var news in newsList.Articles)
            ArticlesList.Add(news);
    }

    private void SelectableItemsView_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var selectedItem = e.CurrentSelection.FirstOrDefault() as Article;
        if (selectedItem == null) return;

        CvArticle.SelectedItem = null; // works now with x:Name
        Navigation.PushAsync(new DetailsPage(selectedItem));
    }

    private async void SelectableItemsViewCat_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var selectedCategory = e.CurrentSelection.FirstOrDefault()?.ToString();
        if (!string.IsNullOrEmpty(selectedCategory))
        {
            await LoadArticlesAsync(selectedCategory);
        }
    }
    
    private void LoadCategories()
    {
        NewsCategory.Add("General");
        NewsCategory.Add("World");
        NewsCategory.Add("Nation");
        NewsCategory.Add("Business");
        NewsCategory.Add("Technology");
        NewsCategory.Add("Entertainment");
        NewsCategory.Add("Sports");
        NewsCategory.Add("Science");
        NewsCategory.Add("Health");
    }
}