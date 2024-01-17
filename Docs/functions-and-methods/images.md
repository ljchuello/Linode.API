# 📸 Images

## Get All

Returns a paginated list of Images.

* Public Images have IDs that begin with “linode/”. These distribution images are generally available to all users.
* Private Images have IDs that begin with “private/”. These Images are Account-specific and only accessible to Users with appropriate [Grants](https://www.linode.com/docs/api/account/#users-grants-view).

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<Image> list = await linodeClient.Image.Get();
```

## Get One

Get information about a single Image.

* Public Images have IDs that begin with “linode/”. These distribution images are generally available to all users.
* Private Images have IDs that begin with “private/”. These Images are Account-specific and only accessible to Users with appropriate [Grants](https://www.linode.com/docs/api/account/#users-grants-view).

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

string imageId = "linode/debian11";

// Get
Image image = await linodeClient.Image.Get(imageId);
```

## JSON

```json
{
    "id": "linode/debian11",
    "label": "Debian 11",
    "deprecated": false,
    "size": 1500,
    "created": "2021-08-14T22:44:02",
    "updated": "2023-10-09T16:23:37",
    "description": "",
    "created_by": "linode",
    "type": "manual",
    "is_public": true,
    "vendor": "Debian",
    "expiry": null,
    "eol": "2026-06-30T04:00:00",
    "status": "available",
    "capabilities": [
        "cloud-init"
    ]
}
```
