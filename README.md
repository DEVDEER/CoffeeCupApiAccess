# CoffeeCupApiAccess
A .NET core library for accessing the CoffeeCup API.

# Summary
We are using [CoffeeCupApp](https://www.coffeecupapp.com) for time tracking on our projects.

This library supports in accessing the public [API](https://dev.coffeecupapp.com/) which is developed at [Github](https://github.com/coffeecupapp/api).

We are currently targetting version 1.0.2 of the CoffeeCup API.

# Known limitations

- We only support `GET` requests currently.
- The C#-documentation is not complete yet.
- No unit tests where written to this point.
- The retry-policy in the repository is poor (to say the least).
- Most of the optional parameters for queries are not supported.

# Contribution

If you want to contribute feel free to contact us.

# nuget
There are 2 packages coming out of this project:

[![NugGet](https://img.shields.io/nuget/vpre/devdeer.CoffeeCupApiAccess.svg?label=devdeer.CoffeeCupApiAccess)](https://www.nuget.org/packages/devdeer.CoffeeCupApiAccess/)

[![NugGet](https://img.shields.io/nuget/vpre/devdeer.CoffeeCupModels.svg?label=devdeer.CoffeeCupModels)](https://www.nuget.org/packages/devdeer.CoffeeCupModels/)

We've splitted this repo into 2 packages because it is very likely that you need to reference the complete logic in one project while another project of your solution just needs to reference the used models.

# Getting started
The easiest way to get started is to create a new .NET Core Console app in Visual Studio and then writte

    install-package devdeer.CoffeeCupApiAccess -pre

in the `Package Manager Console`.

This will bring in some types. The most important ones are directly in the namespace `devdeer.CoffeeCupApiAccess.Logic.Core`:

- `CoffeeCupRepository`
- `CoffeeCupRequestDataModel`

The latter of the two is simply a transport container to pass needed informations to the repository.

Let's start with a new file `appsettings.json` which you add to the root of your new project. Here is the content:

    {
        "CoffeeCup": {
            "BaseAddress": "https://api.coffeecupapp.com",
            "Origin": "https://YOUR_TENANT_NAME.coffeecupapp.com",
            "ClientId": "YOUR_KEY",
            "ClientSecret": "YOUR_SECRET",
            "Username": "YOUR_USERNAME",
            "Password": "YOUR_PASSWORD",
            "ApiVersion": "v1"
        }
    }

You have to replace the upper-case strings with your own values. The `ClientId` and `ClientSecret` are available from CoffeeCup if you are a customer already.

Now lets add some code in with a our `Program.cs`:


    private static async Task Main(string[] args)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();
        // setup request model
        var requestData = new CoffeeCupRequestDataModel(configuration["CoffeeCup:ApiVersion"],
            configuration["CoffeeCup:ClientId"],
            configuration["CoffeeCup:ClientSecret"],
            configuration["CoffeeCup:Username"],
            configuration["CoffeeCup:Password"]);
        // instantiate and configure a HTTP client
        var client = new HttpClient
        {
            BaseAddress = new Uri(configuration["CoffeeCup:BaseAddress"])
        };
        client.DefaultRequestHeaders.Add("Origin", configuration["CoffeeCup:Origin"]);
        // instantiate repository
        var repository = new CoffeeCupRepository(client);
        // retrieve result
        var result = await repository.GetUsersAsync(requestData);
        // write result to console
        Console.WriteLine(result.Count());
        Console.ReadKey();
    }

That should do the job.