using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace NewsApp.Models;

public class Article
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("image")]
    public string Image { get; set; }

    [JsonProperty("publishedAt")]
    public DateTime? PublishedAt { get; set; }

    [JsonProperty("lang")]
    public string Lang { get; set; }

    [JsonProperty("source")]
    public Source Source { get; set; }
}

public class Information
{
    [JsonProperty("realTimeArticles")]
    public RealTimeArticles RealTimeArticles { get; set; }
}

public class RealTimeArticles
{
    [JsonProperty("message")]
    public string Message { get; set; }
}

public class Root
{
    [JsonProperty("information")]
    public Information Information { get; set; }

    [JsonProperty("totalArticles")]
    public int? TotalArticles { get; set; }

    [JsonProperty("articles")]
    public List<Article> Articles { get; set; }
}

public class Source
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}
