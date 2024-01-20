# 📦 Volumes

## Get All

Returns a paginated list of Volumes you have permission to view.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<Volume> list = await linodeClient.Volume.Get();
```

## Get One

Get information about a single Volume.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long volumeId = 2035197;

// Get All
List<Volume> list = await linodeClient.Volume.Get(volumeId);
```

## Create

Creates a Volume on your Account. In order for this to complete successfully, your User must have the `add_volumes` grant. Creating a new Volume will start accruing additional charges on your account.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

string label = "megaVolume";
long size = 25;
long linodeId = 52485587;

// Create volume
Volume volume = await linodeClient.Volume.Create(label, size, linodeId);
```

## Update

Updates a Volume that you have permission to `read_write`.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get volume
Volume volume = await linodeClient.Volume.Get(2035297);

// Change name
volume.Label = "new-name-volume";

// Update
volume = await linodeClient.Volume.Update(volume);
```

## Delete

Deletes a Volume you have permission to `read_write`.

* **Deleting a Volume is a destructive action and cannot be undone.**
* Deleting stops billing for the Volume. You will be billed for time used within the billing period the Volume was active.
* Volumes that are migrating cannot be deleted until the migration is finished.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get volume
Volume volume = await linodeClient.Volume.Get(2035297);

// You can delete it by passing the object as a parameter
await linodeClient.Volume.Delete(volume);

// You can also delete it by passing the ID as a parameter.
await linodeClient.Volume.Delete(2035297);
```

## Attach

Attaches a Volume on your Account to an existing Linode on your Account. In order for this request to complete successfully, your User must have `read_write` permission to the Volume and `read_write` permission to the Linode. Additionally, the Volume and Linode must be located in the same Region.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long volumeId = 2036242;
long linodeId = 52485587;

// Attach
Volume volume = await linodeClient.Volume.Attach(volumeId, linodeId);
```

## Detach

Detaches a Volume on your Account from a Linode on your Account. In order for this request to complete successfully, your User must have `read_write` access to the Volume and `read_write` access to the Linode.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long volumeId = 2036242;

// Detach
await linodeClient.Volume.Detach(volumeId);
```

## Resize

Resize an existing Volume on your Account. In order for this request to complete successfully, your User must have the `read_write` permissions to the Volume.

* Volumes can only be resized up.
* Only Volumes with a status of “active” can be resized.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long volumeId = 2036242;
long newSize = 25;

// Resize
Volume volume = await linodeClient.Volume.Resize(volumeId, newSize);
```

## Clone

Creates a Volume on your Account. In order for this request to complete successfully, your User must have the `add_volumes` grant. The new Volume will have the same size and data as the source Volume. Creating a new Volume will incur a charge on your Account.

* Only Volumes with a `status` of “active” can be cloned.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long volumeId = 2036242;
string label = "i-am-a-clone";

// Clone
Volume volume = await linodeClient.Volume.Clone(volumeId, label);
```

## JSON

```json
{
    "id": 2041327,
    "status": "active",
    "label": "superNvme",
    "created": "2023-12-01T02:27:36",
    "updated": "2023-12-01T02:27:48",
    "filesystem_path": "/dev/disk/by-id/scsi-0Linode_Volume_superNvme",
    "size": 25,
    "linode_id": 52525566,
    "linode_label": "debian-se-sto",
    "region": "se-sto",
    "tags": [],
    "hardware_type": "nvme"
}
```
