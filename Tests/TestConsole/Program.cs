using AngleSharp;

string url = "https://yandex.ru/search/?text=%D0%BA%D0%B0%D0%BA+%D1%83%D0%B4%D0%B0%D0%BB%D0%B8%D1%82%D1%8C+%D1%80%D0%B5%D0%BF%D0%BE%D0%B7%D0%B8%D1%82%D0%BE%D1%80%D0%B8%D0%B9+%D0%BD%D0%B0+github&lr=120612&src=suggest_B";

HttpClient client = new HttpClient();
string page = await client.GetStringAsync(url);

using var context = BrowsingContext.New(Configuration.Default);
using var doc = await context.OpenAsync(req => req.Content(page));

var films = doc.GetElementsByClassName("Fact-ECFragment Fact-ECFragment_marker_number Fact-ECFragment Fact-ECFragment_typo");

foreach (var film in films)
{
    string name = film.TextContent.Trim();
    Console.WriteLine(name);
}

