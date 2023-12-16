# devdeer.CoffeeCupApiAccess

## Disclaimer

We are using this package in our own projects. So it is not only a playground but also production code. We are trying to keep the quality high but we are also humans. So if you find any issues please report them or even better: fix them and create a pull request.

## Summary

This package contains logic to access CoffeeCup API with .NET 6 onwards.

## Usage

In order to start using the logic in this package your first need to ensure that your DI container is configured correctly.

The following example shows a typical DI configuration:

```csharp
using devdeer.CoffeeCupApiAccess.Logic.Core;

services.AddOptions<ApiOptions>()
    .Configure<IConfiguration>(settings, configuration) =>
    {
        configuration.GetSection("CoffeeCupAccess").Bind(settings);
    });     
services.AddHttpClient<CoffeeCupAccess>(
    c =>
    {
        var options = GetRequiredService<IOptions<ApiOptions>>();
        c.BaseAddress = new Uri("https://api.coffeecupapp.com");
        c.DefaultRequestHeaders.Add("Origin", options.Value.Origin);
    });
```

This assumes that your `appsettings.json` contains a section like this:

```json
{
    "CoffeeCupAccess": {
        "CoffeeCupApiVersion": "v1",
        "CoffeeCupApiClientId": "",
        "CoffeeCupApiClientSecret": "",
        "CoffeeCupUsername": "",
        "CoffeeCupPassword": "",
        "CoffeeCupOrigin": ""
    }
}
```

## About DEVDEER

DEVDEER is a company from Magdeburg, Germany which is specialized in consulting, project management and development. We are very focussed on Microsoft Azure as a platform to run our products and solutions in the cloud. So all of our backend components usually runs in this environment and is developed using .NET. In the frontend area we are using react and a huge bunch of packages to build our UIs.

You can find us online:

- [GitHub](https://github.com/devdeer)
- [Twitter](https://twitter.com/devdeerz)
- [Youtube](https://m.youtube.com/@real-codingfreaks)
