# Zone

## Get all Domains

This is a collection of Domains that you have registered in Linode’s DNS Manager. Linode is not a registrar, and in order for these to work you must own the domains and point your registrar at Linode’s nameservers.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<Domain> list = await linodeClient.Domain.Get();
```

## Get a Domain

This is a single Domain that you have registered in Linode’s DNS Manager. Linode is not a registrar, and in order for this Domain record to work you must own the domain and point your registrar at Linode’s nameservers.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2872605;

// Get
Domain domain = await linodeClient.Domain.Get(domainId);
```

## Create Domain

Adds a new Domain to Linode’s DNS Manager. Linode is not a registrar, and you must own the domain before adding it here. Be sure to point your registrar to Linode’s nameservers so that the records hosted here are used.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Set domain properties
Domain domain = new Domain
{
    Domains = "anydomain.com",
    Type = DomainType.master,
    SoaEmail = "ljchuello@gmail.com",
    Description = "Example domain add",
    RefreshSec = 60,
    RetrySec = 60,
    ExpireSec = 60,
    TtlSec = 30,
    Status = DomainStatus.active,
    Group = "Group Example"
};

// Create
domain = await linodeClient.Domain.Create(domain);
```

## Update Domain

Update information about a Domain in Linode’s DNS Manager.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get
Domain domain = await linodeClient.Domain.Get(2872671);

// Change domain properties
domain.Description = "new descrption";
domain.TtlSec = 200;
domain.RetrySec = 120;
domain.ExpireSec = 300;
// Any other property can be changed

// Update
domain = await linodeClient.Domain.Update(domain);
```

## Delete Domain

Deletes a Domain from Linode’s DNS Manager. The Domain will be removed from Linode’s nameservers shortly after this operation completes. This also deletes all associated Domain Records.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2872671;

// Get
Domain domain = await linodeClient.Domain.Get(domainId);

// You can delete it by passing the object as a parameter
await linodeClient.Domain.Delete(domain);

// You can also delete it by passing the ID as a parameter.
await linodeClient.Domain.Delete(2872671);
```
