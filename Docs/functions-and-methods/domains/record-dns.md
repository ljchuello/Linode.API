# Record DNS

## Get All Record DNS

Returns a paginated list of Records configured on a Domain in Linode’s DNS Manager.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2872928;

// Get all
List<RecordDns> list = await linodeClient.RecordDns.Get(domainId);
```

## Get One Record DNS

View a single Record on this Domain

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2872928;

long recordDnsId = 32484370;

// Get one
RecordDns recordDns = await linodeClient.RecordDns.Get(domainId, recordDnsId);
```

## Create IPv4 DNS Record

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2873263;

string name = "mysubdomainipv4";
string target = "200.44.32.12";
long ttl = 30;

// Create
RecordDns recordDns = await linodeClient.RecordDns.CreateIPv4(domainId, name, target, ttl);
```

## Create IPv6 DNS Record

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2873263;

string name = "mysubdomainipv6";
string target = "2a06:98c1:50::ac40:2062";
long ttl = 30;

// Create
RecordDns recordDns = await linodeClient.RecordDns.CreateAAAA(domainId, name, target, ttl);
```

## Create CNAME DNS Record

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2873263;

string name = "mysubdomaincname";
string target = "a1859.w27.akamai.net";
long ttl = 30;

// Create
RecordDns recordDns = await linodeClient.RecordDns.CreateCNAME(domainId, name, target, ttl);
```

## Create TXT DNS Record

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2873263;

string name = "mysubdomaintxt";
string target = "my value in txt record";
long ttl = 30;

// Create
RecordDns recordDns = await linodeClient.RecordDns.CreateTXT(domainId, name, target, ttl);
```

## Create MX DNS Record

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2873263;

string name = "";
string target = "mxa.mailgun.org";
long priority = 10;
long ttl = 30;

// Create
RecordDns recordDns = await linodeClient.RecordDns.CreateMX(domainId, name, target, priority, ttl);
```

## Create CAA DNS Record

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2873263;

string name = "subdomain";
string tag = "issue";
string content = "letsencrypt.or";
long ttl = 30;

// Create
RecordDns recordDns = await linodeClient.RecordDns.CreateCAA(domainId, name, tag, content, ttl);
```

## Delete DNS Record

Deletes a Record on this Domain.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long domainId = 2873263;
long recordDnsId = 32497006;

// Get
RecordDns recordDns = await linodeClient.RecordDns.Get(domainId, recordDnsId);

// You can delete it by passing the object as a parameter.
await linodeClient.RecordDns.Delete(domainId, recordDns);

// You can also delete it by passing the ID as a parameter.
await linodeClient.RecordDns.Delete(domainId, recordDnsId);
```
