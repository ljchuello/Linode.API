# 🌎 Regions

Lists the Regions available for Linode services. Not all services are guaranteed to be available in all Regions.

## Get all Regions

Returns all Regions objects.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<Region> list = await linodeClient.Region.Get();
```

## Get a Region

Returns a specific Region object.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Set ID
string regionId = "ap-south";

// Get
Region region = await linodeClient.Region.Get(regionId);
```

## JSON

```json
{
    "id": "ap-southeast",
    "label": "Sydney, AU",
    "country": "au",
    "capabilities": [
        "Linodes",
        "NodeBalancers",
        "Block Storage",
        "Kubernetes",
        "Cloud Firewall",
        "Vlans",
        "Block Storage Migrations",
        "Managed Databases"
    ],
    "status": "ok",
    "resolvers": {
        "ipv4": "172.105.166.5, 172.105.169.5, 172.105.168.5, 172.105.172.5, 172.105.162.5, 172.105.170.5, 172.105.167.5, 172.105.171.5, 172.105.181.5, 172.105.161.5",
        "ipv6": "2400:8907::f03c:92ff:fe6e:ec8, 2400:8907::f03c:92ff:fe6e:98e4, 2400:8907::f03c:92ff:fe6e:1c58, 2400:8907::f03c:92ff:fe6e:c299, 2400:8907::f03c:92ff:fe6e:c210, 2400:8907::f03c:92ff:fe6e:c219, 2400:8907::f03c:92ff:fe6e:1c5c, 2400:8907::f03c:92ff:fe6e:c24e, 2400:8907::f03c:92ff:fe6e:e6b, 2400:8907::f03c:92ff:fe6e:e3d"
    }
}
```
