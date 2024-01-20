# 🖥️ Linode Instance

## Get All

Returns a paginated list of Linodes you have permission to view.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get all
List<LinodeInstance> list = await linodeClient.LinodeInstance.Get();
```

## Get One

Get a specific Linode by ID.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long instanceId = 52767381;

// Get One
LinodeInstance linodeInstance = await linodeClient.LinodeInstance.Get(instanceId);
```

## Create Linode Instance (Simple)

Creates a Linode Instance on your Account. In order for this request to complete successfully, your User must have the add\_linodes grant. Creating a new Linode will incur a charge on your Account.

Linodes can be created using one of the available Types. See [Types List](https://github.com/ljchuello/Linode.API/wiki/Linode-Types) to get more information about each Type’s specs and cost.

Linodes can be created in any one of our available Regions, which are accessible from the [Regions List](https://github.com/ljchuello/Linode.API/wiki/Regions) endpoint.

**Important:** You must be an unrestricted User in order to add or modify tags on Linodes.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

string label = "mySuperServerLinode";
string regionId = "eu-central";
string linodeTypeId = "g6-nanode-1";
string imageId = "linode/debian11";
string rootPassword = "krGNsg7oPxWTYS^q*KWL8HkHC2nJRUDjE*wT";

// Create
LinodeInstance linodeInstance = await linodeClient.LinodeInstance.Create(
    label,
    regionId,
    linodeTypeId,
    imageId,
    rootPassword
);
```

## Create Linode Intance (Complete)

Creates a Linode Instance on your Account. In order for this request to complete successfully, your User must have the add\_linodes grant. Creating a new Linode will incur a charge on your Account.

Linodes can be created using one of the available Types. See [Types List](https://github.com/ljchuello/Linode.API/wiki/Linode-Types) to get more information about each Type’s specs and cost.

Linodes can be created in any one of our available Regions, which are accessible from the [Regions List](https://github.com/ljchuello/Linode.API/wiki/Regions) endpoint.

**Important:** You must be an unrestricted User in order to add or modify tags on Linodes.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Required

string label = "mySuperServerLinode";
string regionId = "eu-central";
string linodeTypeId = "g6-nanode-1";
string imageId = "linode/debian11";
string rootPassword = "krGNsg7oPxWTYS^q*KWL8HkHC2nJRUDjE*wT";

// Optional

// List of authorized users
List<string> authorizedUsers = new List<string> { "LJChuello" };

// List of enabled public SSH keys
List<string> authorizedKeys = new List<string>();
// We rely on the 'SshKeyGenerator' library to generate SSH credentials.
SshKeyGenerator.SshKeyGenerator sshKeyGenerator = new SshKeyGenerator.SshKeyGenerator(2048);
// Add to list
authorizedKeys.Add(sshKeyGenerator.ToRfcPublicKey($"{Guid.NewGuid()}"));

// If true, we indicate that backups are made by Linode
bool backups = true;

// If indicated, sets the firewall ID of the firewall that was specified
long firewallId = 285728;

// If StackScripts is set, the server executes the Stack Scripts of the specified ID
long stackscriptId = 1278172;

// If Private Ip is true, it enables the private IP address on the Linode
bool privateIp = true;

// If specified, it is a list of tags with which the Linode will be identified
List<string> tags = new List<string> { "this", "super", "server" };

// Create
LinodeInstance linodeInstance = await linodeClient.LinodeInstance.Create(
    label,
    regionId,
    linodeTypeId,
    imageId,
    rootPassword,
    authorizedUsers: authorizedUsers,
    authorizedKeys: authorizedKeys,
    backups: backups,
    firewallId: firewallId,
    stackscriptId: stackscriptId,
    privateIp: privateIp,
    tags: tags
);
```

## Updates a Linode

Updates a Linode that you have permission to `read_write`.

**Important**: You must be an unrestricted User in order to add or modify tags on Linodes.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get
LinodeInstance linodeInstance = await linodeClient.LinodeInstance.Get(54126156);

// Set label and Tags
linodeInstance.Label = $"{Guid.NewGuid()}";
linodeInstance.Tags = new List<string> { "Kevin", "Magnussen", "Haas F1 Team" };

// Update
linodeInstance = await linodeClient.LinodeInstance.Update(linodeInstance);
```

## Deletes a Linode

Deletes a Linode you have permission to `read_write`.

**Deleting a Linode is a destructive action and cannot be undone.**

Additionally, deleting a Linode:

* Gives up any IP addresses the Linode was assigned.
* Deletes all Disks, Backups, Configs, etc.
* Detaches any Volumes associated with the Linode.
* Stops billing for the Linode and its associated services. You will be billed for time used within the billing period the Linode was active.

Linodes that are in the process of [cloning](https://www.linode.com/docs/api/linode-instances/#linode-clone) or [backup restoration](https://www.linode.com/docs/api/linode-instances/#backup-restore) cannot be deleted.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get
LinodeInstance linodeInstance = await linodeClient.LinodeInstance.Get(54126784);

// You can delete it by passing the object as a parameter
await linodeClient.LinodeInstance.Delete(linodeInstance);

// You can also delete it by passing the ID as a parameter.
await linodeClient.LinodeInstance.Delete(54126784);
```

## JSON

```json
{
    "id": 54203595,
    "label": "debian-eu-central",
    "group": "",
    "status": "running",
    "created": "2024-01-20T18:41:32",
    "updated": "2024-01-20T18:42:09",
    "type": "g6-nanode-1",
    "ipv4": [
        "172.105.89.206",
        "192.168.139.240"
    ],
    "ipv6": "2a01:7e01::f03c:94ff:febd:d06d/128",
    "image": "linode/debian11",
    "region": "eu-central",
    "specs": {
        "disk": 25600,
        "memory": 1024,
        "vcpus": 1,
        "gpus": 0,
        "transfer": 1000
    },
    "alerts": {
        "cpu": 90,
        "network_in": 10,
        "network_out": 10,
        "transfer_quota": 80,
        "io": 10000
    },
    "backups": {
        "enabled": false,
        "available": false,
        "schedule": {
            "day": null,
            "window": null
        },
        "last_successful": null
    },
    "hypervisor": "kvm",
    "watchdog_enabled": true,
    "tags": [],
    "host_uuid": "dbad721e1935a43e409a0fa120d30e42574c3088",
    "has_user_data": false
}
```
