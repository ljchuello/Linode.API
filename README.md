<div align="center">
  <img src="https://raw.githubusercontent.com/ljchuello/Linode.API/master/icon_128.png" alt="Logo" width="128">

  <h3 align="center">Welcome to Linode.API</h3>

  <p align="center">
    An awesome README template to jumpstart your projects!
    <br />
    <a href="https://ljchuello.gitbook.io/linode.api/"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://ljchuello.gitbook.io/linode.api/functions-and-methods/linode-instance">View Demo</a>
    ·
    <a href="https://github.com/ljchuello/Linode.API/issues/">Report Bug</a>
    ·
    <a href="https://github.com/ljchuello/Linode.API/issues/">Request Feature</a>
  </p>
</div>


## About The Project

This project is essentially your comprehensive guide to explore and use Linode APIs. Here, I compile everything you need to integrate your projects into one of the top cloud platforms, covering instances, firewalls, images, regions, SSH keys, StackScripts, and much more! 🌐🔒🚀

### Key Features

* Quick Start: Get going with simple examples to connect and utilize the API. 🖥️
* Detailed API Reference: Each endpoint is explained with code examples, making it easy even for beginners. 📚
* Use Cases: Explore how other developers are leveraging the API in real-world scenarios. 💡
* Security and Best Practices: Learn how to use the API securely and efficiently. 🔐
* Support and Community: Join our community and get assistance when you need it. 👥

### Built With
<img src="https://raw.githubusercontent.com/bablubambal/All_logo_and_pictures/7c0ac2ceb9f9d24992ec393d11fa7337d2f92466/programming%20languages/c%23.svg" alt="C#" width="128"> <img src="https://raw.githubusercontent.com/bablubambal/All_logo_and_pictures/7c0ac2ceb9f9d24992ec393d11fa7337d2f92466/text%20editors/vscode.svg" alt="VSCode" width="128">

### Installation

Before you can use Linode.API in your application, you must add the NuGet package. You can do this using your IDE or the command line:

`PM> dotnet add package Linode.API`

## Usage

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

Leonardo Chuello - [@LJChuello](https://twitter.com/LJChuello) - ljchuello@gmail.com

Project Link: [github.com/ljchuello/Linode.API](https://github.com/ljchuello/Linode.API)

Project Documentation: [ljchuello.gitbook.io/linode.api/](https://ljchuello.gitbook.io/linode.api/)

Nuget Package [nuget.org/packages/Linode.API](https://www.nuget.org/packages/Linode.API)

## Implemented functionality

:heavy_check_mark: - Available on API, implemented\
:x: - Available on API, not implemented\
:heavy_minus_sign:  - Not available on API

|  | Get all | Get one | Create | Update | Delete | Actions |
|--|:--:|:--:|:--:|:--:|:--:|:--:|
| Domains (Zone DNS) | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_minus_sign: |
| Domains (Record DNS) | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_minus_sign: |
| Firewalls | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |
| Images | :heavy_check_mark: | :heavy_check_mark: | :x: | :x: | :x: | :heavy_minus_sign: |
| Linode Instance | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_minus_sign: |
| Linode Type | :heavy_check_mark: | :heavy_check_mark: | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: |
| Regions | :heavy_check_mark: | :heavy_check_mark: | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: |
| SSH Keys | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_minus_sign: |
| StackScript | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_minus_sign: |
| VLANs | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: | :heavy_minus_sign: |
| Volumes | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: | :heavy_check_mark: |

To have the complete list of the functionalities implemented in this library [consult the Wiki](https://ljchuello.gitbook.io/linode.api/)
