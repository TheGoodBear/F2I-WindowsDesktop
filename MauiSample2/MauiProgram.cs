using MauiSample2.Data;
using MauiSample2.Utilities;
using MauiSample2.ViewModels;
using Microsoft.AspNetCore.Components.WebView.Maui;

namespace MauiSample2;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

        // database parameters
        //string DBPath = FileAccessHelper.GetLocalFilePath("MauiSample2.sqlite3");
        string DBPath = "MauiSample2.sqlite3";
        string DBStructurePath = "Data.DBStructure-SQLite3.sql";
        string InitialDataPath = "Data.InitialData-SQLite3.sql";
        DBUtil.DBPath = DBPath;
        DBUtil.DBStructurePath = DBStructurePath;
        DBUtil.InitialDataPath = InitialDataPath;
        DBUtil.Init();


        builder.Services.AddSingleton<WeatherForecastService>();
		builder.Services.AddSingleton<AnimalVM>();

		return builder.Build();
    }
}