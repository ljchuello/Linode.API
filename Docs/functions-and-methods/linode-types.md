# 🗄️ Linode Types

## Get All

Returns collection of Linode Types, including pricing and specifications for each Type. These are used when [creating](https://www.linode.com/docs/api/linode-instances/#linode-create) or [resizing](https://www.linode.com/docs/api/linode-instances/#linode-resize) Linodes.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<LinodeType> list = await linodeClient.LinodeType.Get();
```

## Get One

Returns information about a specific Linode Type, including pricing and specifications. This is used when [creating](https://www.linode.com/docs/api/linode-instances/#linode-create) or [resizing](https://www.linode.com/docs/api/linode-instances/#linode-resize) Linodes.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

string = linodeTypeId = "g7-highmem-2";

// Get
LinodeType linodeType = await linodeClient.LinodeType.GetlinodeTypeId);
```

### JSON

```json
{
    "id": "g7-premium-64",
    "label": "Premium 512GB",
    "price": {
        "hourly": 8.295,
        "monthly": 5530.0
    },
    "region_prices": [
        {
            "id": "id-cgk",
            "hourly": 9.953,
            "monthly": 6635.52
        },
        {
            "id": "br-gru",
            "hourly": 11.612,
            "monthly": 7741.44
        }
    ],
    "addons": {
        "backups": {
            "price": {
                "hourly": 0.36,
                "monthly": 240.0
            },
            "region_prices": [
                {
                    "id": "id-cgk",
                    "hourly": 0.432,
                    "monthly": 288.0
                },
                {
                    "id": "br-gru",
                    "hourly": 0.504,
                    "monthly": 336.0
                }
            ]
        }
    },
    "memory": 524288,
    "disk": 7372800,
    "transfer": 12000,
    "vcpus": 64,
    "gpus": 0,
    "network_out": 12000,
    "class": "premium",
    "successor": null
}
```
