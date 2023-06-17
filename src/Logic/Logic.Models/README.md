# devdeer.Libraries.Abstractions

## Disclaimer

If you want to use this package you should be aware of some principles and practices we at DEVDEER use. So be aware that this is not backed by a public repository. The purpose here is to give out customers easy access to our logic. Nevertheless you are welcome to use this lib if it provides any advantages.

## Summary

This package contains base types and helper classes for all other [DEVDEER Nuget Packages](https://www.nuget.org/packages?q=devdeer). It is usually referenced by those packages so you don't need to put an explicit reference in your projects.

The default namespace is `devdeer.Libraries.Abstractions`. Types are organized in sub-namespaces (see below).

## Sub-namespaces

### Attributes

We are collecting .NET attributes here which are normally used by sub-packages.

### BaseTypes

We are building our apps in a multi-layered architecture. This means that we have components providing business logic and other components taking care of data access (usuallly to relational databases). The logic-components are calling the repositories. This enables us to easilly switch database backends if we need to.

The types in this namespace are abstract base types for those classes. They already contain some basic logic but are not related to any specific technology. Have a look at [devdeer.Libraries.Repository.EntityFrameworkCore](https://www.nuget.org/packages/devdeer.Libraries.Repository.EntityFrameworkCore) to see how these types are used. Also [devdeer.Libraries.AspNetCore.RestApi](https://www.nuget.org/packages/devdeer.Libraries.AspNetCore.RestApi) might be interesting here because the `BaseController` is using these types here indirectly.

Also see the `Interfaces` section below.

### Enums

We are collecting all Enumerations needed by this or sub-projects in this namespace.

### Exceptions

Contains types inheriting from `System.Exception`.

### Extensions

All of the types here are extension types for other types.

### Helpers

For some issues like reflection, expressions and other things we often need logic which is collected in this namespace.

### Interfaces

Contains all base interfaces. Most of them are used to enable IoC for the stuff in `BaseTypes` namespace.

### Models

Some of our `BaseTypes` and `Interfaces` are expecting or returning certain POCO`s which are defined here. Some other types might be added too.

## About DEVDEER

DEVDEER is a company from Magdeburg, Germany which is specialized in consulting, project management and development. We are very focussed on Microsoft Azure as a platform to run our products and solutions in the cloud. So all of our backend components usually runs in this environment and is developed using .NET. In the frontend area we are using react and a huge bunch of packages to build our UIs.

You can find us online:

- [GitHub](https://github.com/devdeer)
- [Twitter](https://twitter.com/devdeerz)
- [Youtube](https://m.youtube.com/@real-codingfreaks)
