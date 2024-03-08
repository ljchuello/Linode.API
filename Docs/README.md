# 👋🏻 Welcome to Linode.API

## About The Project

This project is essentially your comprehensive guide to explore and use Linode APIs. Here, I compile everything you need to integrate your projects into one of the top cloud platforms, covering instances, firewalls, images, regions, SSH keys, StackScripts, and much more! 🌐🔒🚀

#### Key Features

* Quick Start: Get going with simple examples to connect and utilize the API. 🖥️
* Detailed API Reference: Each endpoint is explained with code examples, making it easy even for beginners. 📚
* Use Cases: Explore how other developers are leveraging the API in real-world scenarios. 💡
* Security and Best Practices: Learn how to use the API securely and efficiently. 🔐
* Support and Community: Join our community and get assistance when you need it. 👥

## Installation

Before you can use `Linode.API` in your application, you must add the NuGet package. You can do this using your IDE or the command line:

`PM> dotnet add package Linode.API`

### Usage

Ex; Create a server

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

Ex; Get all server

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get all
List<LinodeInstance> list = await linodeClient.LinodeInstance.Get();
```

Ex; Get a server

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long instanceId = 52767381;

// Get One
LinodeInstance linodeInstance = await linodeClient.LinodeInstance.Get(instanceId);
```

## License

Distributed under the MIT License. See `LICENSE` for more information.

## Contact

Leonardo Chuello - [@LJChuello](https://twitter.com/LJChuello) - [ljchuello@gmail.com](mailto:ljchuello@gmail.com)

Project Link: [github.com/ljchuello/Linode.API](https://github.com/ljchuello/Linode.API)

Project Documentation: [ljchuello.gitbook.io/linode.api/](https://ljchuello.gitbook.io/linode.api/)

Nuget Package [nuget.org/packages/Linode.API](https://www.nuget.org/packages/Linode.API)

## Implemented functionality

✔️ - Available on API, implemented\
❌ - Available on API, not implemented\
➖ - Not available on API

<table><thead><tr><th width="246"></th><th align="center">Get all</th><th align="center">Get one</th><th align="center">Create</th><th align="center">Update</th><th align="center">Delete</th><th align="center">Actions</th></tr></thead><tbody><tr><td>Domains (Zone DNS)</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">➖</td></tr><tr><td>Domains (Record DNS)</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">➖</td></tr><tr><td>Firewalls</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td></tr><tr><td>Images</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">❌</td><td align="center">❌</td><td align="center">❌</td><td align="center">➖</td></tr><tr><td>Linode Instance</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">➖</td></tr><tr><td>Linode Type</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td></tr><tr><td>Regions</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td></tr><tr><td>SSH Keys</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">➖</td></tr><tr><td>StackScript</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">➖</td></tr><tr><td>VLANs</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td><td align="center">➖</td></tr><tr><td>Volumes</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td><td align="center">✔️</td></tr></tbody></table>

To have the complete list of the functionalities implemented in this library [consult the Wiki](https://ljchuello.gitbook.io/linode.api/)
