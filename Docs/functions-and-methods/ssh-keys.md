# 🔐 SSH Keys

## Get All

Returns a collection of SSH Keys you’ve added to your Profile.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<SshKey> list = await linodeClient.SshKey.Get();
```

## Get One

Returns a single SSH Key object identified by id that you have access to view.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long sshKeyId = 314986;

// Get One
SshKey sshKey = await linodeClient.SshKey.Get(sshKeyId);
```

## Create

Adds an SSH Key to your Account profile.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// We rely on the 'SshKeyGenerator' library to generate SSH credentials.
SshKeyGenerator.SshKeyGenerator sshKeyGenerator = new SshKeyGenerator.SshKeyGenerator(2048);

string label = "name";
string pubKey = sshKeyGenerator.ToRfcPublicKey($"{Guid.NewGuid()}");

// Create
SshKey sshKey = await linodeClient.SshKey.Create(label, pubKey);
```

## Update

Updates an SSH Key that you have permission to read\_write.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get one
SshKey sshKey = await linodeClient.SshKey.Get(314986);

// Change name
sshKey.Label = "new-name";

// Update
sshKey = await linodeClient.SshKey.Update(sshKey);
```

## Delete

Deletes an SSH Key you have access to.

**Note:** deleting an SSH Key will not remove it from any Linode or Disk that was deployed with authorized\_keys. In those cases, the keys must be manually deleted on the Linode or Disk. This endpoint will only delete the key’s association from your Profile.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get one
SshKey sshKey = await linodeClient.SshKey.Get(314986);

// You can delete it by passing the object as a parameter
await linodeClient.SshKey.Delete(sshKey);

// You can also delete it by passing the ID as a parameter.
await linodeClient.SshKey.Delete(314986);
```

## JSON

```json
{
    "id": 314986,
    "label": "new-name",
    "ssh_key": "ssh-rsa AAAAB3NzaC1yc2EAAAADAQABAAABAQC6tABZGFBt6/0XQFfGsoZsweDmz0v0jMkgPJDZ+CzngqExUP3mW17KFreV1HpCeL8EDx9qvhTdJFvgjOZ23PJqEE8/NZy6e8EupCHxyS+7b8NYFIxhxaq1XN8MB4+pi2xICjfAROoUBi4Sx5NKym/2WGqnaJtig56cL0c/4pmG1kVV1VeEb3Z84SCTI6WzQNLtHaaBg3hdP3PilcKQSL2zFq2I/bkDNUO3FdUPISzjCWqMveDMi2rUNo5RGvrxQqQLxcBWB1mKUA1xA6Bsp6NyzNbGhhKcc6IMBEj/H+gDvl5DBAhE5B55gGhRWVZJYTWqI2jC3/hfIC5oAN/1yqX5 e7beb5fe-bbf1-4258-bf19-1a5761492318",
    "created": "2023-11-27T19:55:36"
}
```
