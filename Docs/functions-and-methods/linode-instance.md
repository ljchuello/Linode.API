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
for (int i = 1; i <= 10; i++)
{
    // We rely on the 'SshKeyGenerator' library to generate SSH credentials.
    SshKeyGenerator.SshKeyGenerator sshKeyGenerator = new SshKeyGenerator.SshKeyGenerator(2048);
    // Add to list
    authorizedKeys.Add(sshKeyGenerator.ToRfcPublicKey($"{Guid.NewGuid()}"));
}

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
