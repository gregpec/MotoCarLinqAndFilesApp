using Microsoft.Extensions.DependencyInjection;
using MotoAppmod4App;
using MotoAppmod4App.Components.CsvReader;

var services = new ServiceCollection();

services.AddSingleton<IApp, App>(); 
services.AddSingleton<ICsvReader, CsvReader>();
var serviceProvider = services.BuildServiceProvider(); 
var app = serviceProvider.GetService<IApp>()!;

    app.Run(); 
