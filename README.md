## NPPES API for .NET

[![NuGet](https://img.shields.io/nuget/v/Forcura.NPPESAPI.svg?style=flat-square&label=nuget)](https://www.nuget.org/packages/Forcura.NPPESAPI/)

This is a .NET wrapper for interacting with the CMS **National Plan and Provider Enumeration System** [NPPES](https://nppes.cms.hhs.gov/NPPES/Welcome.do) **National Provider Identifier** (NPI) lookup system

For more information visit the [NPI registry](https://npiregistry.cms.hhs.gov/)

## Usage

Requests are as simple as providing an NPI number to lookup:

```cs
var results = await NPPESApiClient.SearchAsync("8942315671");
```

OR

```cs
var results = await NPPESApiClient.SearchAsync(new NPPESRequest
{
   Number = "5631047582"
});
```

For more complicated queries, use the other provided fields on the `NPPESRequest` object:
```cs
var results = await NPPESApiClient.SearchAsync(new NPPESRequest
{
   FirstName = "John",
   LastName = "Doe"
});
```

## License

Copyright 2019 Forcura

Licensed under the [Apache 2.0](https://github.com/ForcuraCo/npi-api-net/blob/master/LICENSE) license

## Resources

* https://www.cms.gov/
* https://npiregistry.cms.hhs.gov/
