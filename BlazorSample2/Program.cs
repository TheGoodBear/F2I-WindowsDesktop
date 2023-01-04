using BlazorSample2;
using BlazorSample2.Utilities;
using BlazorSample2.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// database parameters
//string DBPath = FileAccessHelper.GetLocalFilePath("BlazorSample2.sqlite3");
string DBPath = "BlazorSample2.sqlite3";
string DBStructurePath = "Data.DBStructure-SQLite3.sql";
string InitialDataPath = "Data.InitialData-SQLite3.sql";
DBUtil.DBPath = DBPath;
DBUtil.DBStructurePath = DBStructurePath;
DBUtil.InitialDataPath = InitialDataPath;
DBUtil.Init();

builder.Services.AddSingleton<AnimalVM>();


await builder.Build().RunAsync();
