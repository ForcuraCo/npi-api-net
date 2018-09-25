## NPPES API for .NET

This is a .NET wrapper for interacting with the CMS **National Plan and Provider Enumeration System** [NPPES](https://nppes.cms.hhs.gov/NPPES/Welcome.do) **National Provider Identifier** (NPI) lookup system

For more information visit the [NPI registry](https://npiregistry.cms.hhs.gov/)

## Usage

Requests are as simple as providing an NPI number to lookup:

```
var results = await NPPESApiClient.Search(new NPPESRequest
{
   Number = "5631047582"
});
```

For more complicated queries, use the other provided fields on the `NPPESRequest` object:
```
var results = await NPPESApiClient.Search(new NPPESRequest
{
   FirstName = "John",
   LastName = "Doe"
});
```

## License

Apache 2.0 license

## Resources

* https://www.cms.gov/
* https://npiregistry.cms.hhs.gov/
