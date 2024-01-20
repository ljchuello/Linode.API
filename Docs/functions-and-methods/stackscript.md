# 📜 StackScript

[StackScripts](http://linode.com/stackscripts/) provide Linode users with the ability to automate the deployment of custom systems. They work by running a custom script when deploying a new Compute Instance. These custom scripts store tasks that you may need to repeat often on new Compute Instances, such as:

* Automating common system administration tasks, such as installing and configuring software, configuring system settings, adding limited user accounts, and more.
* Running externally hosted deployment scripts.
* Quickly creating Compute Instances for yourself or clients with the exact starter configuration you need.

All StackScripts are stored in the Linode Cloud Manager and can be accessed whenever you deploy a Compute Instance. A StackScript authored by you is an _Account StackScript_. A _Community StackScript_ is a StackScript created by a Linode community member that has made their StackScript publicly available.

## Get All

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<StackScript> list = await linodeClient.StackScript.Get();
```

## Get One

Returns all of the information about a specified StackScript, including the contents of the script.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get One
StackScript stackScript = await linodeClient.StackScript.Get(1278172);+
```

## Create

Creates a StackScript in your Account.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Label
string label = "Super-StackScript";

// Images
List<string> listImages = new List<string> { "linode/debian10", "linode/debian11", "linode/debian12" };

// Script. In this example we will update the system and install several packages
string script = "#!/bin/bash\n" +
                "# Updates the packages\n" +
                "DEBIAN_FRONTEND=noninteractive apt-get update && DEBIAN_FRONTEND=noninteractive apt-get -y upgrade\n" +
                "# Tools\n" +
                "apt install curl -y\n" +
                "apt install wget -y\n" +
                "apt install unzip -y\n" +
                "apt install nginx -y\n" +
                "apt install nano -y";

// Optional

// Description
string description = "This its an example";

// revNote
string revNote = "check (LJChuello)";

// Is Public; Default => false
bool isPublic = true;

// Create StackScript 
StackScript stackScript = await linodeClient.StackScript.Create(
    label,
    listImages,
    script,
    revNote: revNote,
    description: description,
    isPublic: isPublic);
```

## Update

Updates a StackScript.

**Once a StackScript is made public, it cannot be made private.**

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get 
StackScript stackScript = await linodeClient.StackScript.Get(1300720);

// Rename label
stackScript.Label = "How to be an F1 driver for dummies (By; Valtteri Bottas)";

// Set images, We add Ubuntu images
stackScript.Images.Add("linode/ubuntu18.04");
stackScript.Images.Add("linode/ubuntu20.04");
stackScript.Images.Add("linode/ubuntu22.04");

// Update
stackScript = await linodeClient.StackScript.Update(stackScript);
```

## **Delete**

Deletes a private StackScript you have permission to `read_write`. You cannot delete a public StackScript.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get 
StackScript stackScript = await linodeClient.StackScript.Get(1300722);

// You can delete it by passing the object as a parameter
await linodeClient.StackScript.Delete(stackScript);

// You can also delete it by passing the ID as a parameter.
await linodeClient.StackScript.Delete(1300722);
```

## JSON

```json
{
    "id": 1278172,
    "username": "LJChuello",
    "user_gravatar_id": "948613bff805c4e1569f76ade6792277",
    "label": "OnServer",
    "description": "This is a script that installs various packages, adds firewall and enables monitoring",
    "ordinal": 0,
    "logo_url": "",
    "images": [
        "linode/debian10",
        "linode/ubuntu20.04",
        "linode/debian11",
        "linode/ubuntu22.04",
        "linode/debian12"
    ],
    "deployments_total": 10,
    "deployments_active": 0,
    "is_public": true,
    "mine": true,
    "created": "2023-12-04T20:02:53",
    "updated": "2024-01-20T18:34:14",
    "rev_note": "LJChuello",
    "script": "#!/bin/bash\n\n# Updates the packages\nDEBIAN_FRONTEND=noninteractive apt-get update && DEBIAN_FRONTEND=noninteractive apt-get -y upgrade\n\n# Tools\napt install curl -y\napt install wget -y\napt install unzip -y\napt install nginx -y\napt install nano -y\n\n# .NET Core LTS\ncurl -sSL https://dot.net/v1/dotnet-install.sh | bash /dev/stdin --channel LTS --install-dir /usr/share/dotnet\nln -s /usr/share/dotnet/dotnet /usr/bin/dotnet\n\n# Install Firewall\napt install ufw -y\necho \"y\" | ufw enable\n\n# Enabling traffic from the internet\nufw allow 22/tcp\nufw allow 80/tcp\nufw allow 443/tcp\nufw allow 27017/tcp\n\n# Glances\napt install python3\napt install python3-dev -y\napt install python3-pip -y\nwget -O- https://raw.githubusercontent.com/nicolargo/glancesautoinstall/master/install.sh | /bin/bash\n\n# Glances Service\ncd /etc/systemd/system/\nwget -O glances.service https://raw.githubusercontent.com/DeployRise/OnServer/main/glances.service\nsystemctl start glances\nsystemctl enable glances",
    "user_defined_fields": []
}
```
