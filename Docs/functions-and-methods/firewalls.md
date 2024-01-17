# 🚧 Firewalls

## Get All

Returns a paginated list of accessible Firewalls.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get All
List<Firewall> list = await linodeClient.Firewall.Get();
```

## Get One

Get a specific Firewall resource by its ID. The Firewall’s Devices will not be returned in the response. Instead, use the [List Firewall Devices](https://www.linode.com/docs/api/networking/#firewall-devices-list) endpoint to review them.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long firewallId = 109478;

// Get One
Firewall firewall = await linodeClient.Firewall.Get(firewallId);
```

## Create

Creates a Firewall to filter network traffic.

* Use the `rules` property to create inbound and outbound access rules.
* Use the `devices` property to assign the Firewall to a service and apply its Rules to the device. Requires `read_write` [User’s Grants](https://www.linode.com/docs/api/account/#users-grants-view) to the device. Currently, Firewalls can only be assigned to Linode instances.
* A Firewall can be assigned to multiple Linode instances at a time.
* A Linode instance can have one active, assigned Firewall at a time. Additional disabled Firewalls can be assigned to a service, but they cannot be enabled if another active Firewall is already assigned to the same service.
* Firewalls apply to all of a Linode’s non-`vlan` purpose Configuration Profile Interfaces.
* Assigned Linodes must not have any ongoing live migrations.
* A `firewall_create` Event is generated when this endpoint returns successfully.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// New firewall
Firewall firewall = new Firewall();

// Name
firewall.Label = "super-firewall";

// By default, we establish that nothing can enter, except explicitly specified in the incoming rule as "Action ACCEPT."
firewall.Rules.InboundPolicy = eFirewallRulAction.DROP;

// Allow port 22 tcp IN
FirewallRule firewallRuleIn22Tcp = new FirewallRule();
firewallRuleIn22Tcp.Label = "tcp-22-in-allow";
firewallRuleIn22Tcp.Description = "Allow al traffic int 22 tcp";
firewallRuleIn22Tcp.Action = eFirewallRulAction.ACCEPT;
firewallRuleIn22Tcp.Protocol = eFirewallProtocol.TCP;
firewallRuleIn22Tcp.Ports = "22";
firewallRuleIn22Tcp.Addresses = new FirewallRuleAddresses();
firewallRuleIn22Tcp.Addresses.IPv4.Add("8.8.8.8/32");
firewallRuleIn22Tcp.Addresses.IPv4.Add("1.1.1.1/32");
firewallRuleIn22Tcp.Addresses.IPv6.Add("2a00:1450:4009:81f::200e/128");
firewallRuleIn22Tcp.Addresses.IPv6.Add("2606:4700::6810:84e5/128");

// Add rule to Firewall
firewall.Rules.Inbound.Add(firewallRuleIn22Tcp);

// Allow port 80 tcp IN
FirewallRule firewallRuleIn80Tcp = new FirewallRule();
firewallRuleIn80Tcp.Label = "tcp-80-in-allow";
firewallRuleIn80Tcp.Description = "Allow al traffic int 80 tcp";
firewallRuleIn80Tcp.Action = eFirewallRulAction.ACCEPT;
firewallRuleIn80Tcp.Protocol = eFirewallProtocol.TCP;
firewallRuleIn80Tcp.Ports = "80";
firewallRuleIn80Tcp.Addresses = new FirewallRuleAddresses();
firewallRuleIn80Tcp.Addresses.IPv4.Add("8.8.8.8/32");
firewallRuleIn80Tcp.Addresses.IPv6.Add("2606:4700::6810:84e5/128");

// Add rule to Firewall
firewall.Rules.Inbound.Add(firewallRuleIn80Tcp);

// By default, we establish that all traffic can exit, except explicitly specified in the outgoing rule as "Action DROP."
firewall.Rules.OutboundPolicy = eFirewallRulAction.ACCEPT;

// Deny port 27017 OUT
FirewallRule firewallRuleOut27017Tcp = new FirewallRule();
firewallRuleOut27017Tcp.Label = "tcp-27017-out-deny";
firewallRuleOut27017Tcp.Description = "Allow al traffic int 27017 tcp";
firewallRuleOut27017Tcp.Action = eFirewallRulAction.DROP;
firewallRuleOut27017Tcp.Protocol = eFirewallProtocol.TCP;
firewallRuleOut27017Tcp.Ports = "27017";
firewallRuleOut27017Tcp.Addresses = new FirewallRuleAddresses();
firewallRuleOut27017Tcp.Addresses.IPv4.Add("0.0.0.0/0");
firewallRuleOut27017Tcp.Addresses.IPv6.Add("::/0");

// Add rule to Firewall
firewall.Rules.Outbound.Add(firewallRuleOut27017Tcp);

// Tags
firewall.Tags = new List<string> { "22 in allow", "80 in allow", "27017 out deny" };

// Create
firewall = await linodeClient.Firewall.Create(firewall);
```

## Update

Updates information for a Firewall.

* Assigned Linodes must not have any ongoing live migrations.
* If a Firewall’s status is changed with this endpoint, a corresponding `firewall_enable` or `firewall_disable` Event will be generated.

Some parts of a Firewall’s configuration cannot be manipulated by this endpoint:

* A Firewall’s Devices cannot be set with this endpoint. Instead, use the Create Firewall Device and Delete Firewall Device endpoints to assign and remove this Firewall from Linode services.
* A Firewall’s Rules cannot be changed with this endpoint. Instead, use the Update Firewall Rules endpoint to update your Rules.
* A Firewall’s status can be set to `enabled` or `disabled` by this endpoint, but it cannot be set to `deleted`. Instead, use the Delete Firewall endpoint to delete a Firewall.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get one
Firewall firewall = await linodeClient.Firewall.Get(280563);

// Change
firewall.Label = "newName";
firewall.Status = eFirewallStatus.disabled;

// Update
firewall = await linodeClient.Firewall.Update(firewall);
```

## Delete

Delete a Firewall resource by its ID. This will remove all of the Firewall’s Rules from any Linode services that the Firewall was assigned to.

* Assigned Linodes must not have any ongoing live migrations.
* A `firewall_delete` Event is generated when this endpoint returns successfully.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

// Get one
Firewall firewall = await linodeClient.Firewall.Get(280384);

// You can delete it by passing the object as a parameter
await linodeClient.Firewall.Delete(firewall);

// You can also delete it by passing the ID as a parameter.
await linodeClient.Firewall.Delete(280384);
```

## Rules List

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long firewallId = 280563;

// Get
FirewallRules firewallRules = await linodeClient.Firewall.GetRules(firewallId);
```

## Rules Update

Updates the inbound and outbound Rules for a Firewall.

* Assigned Linodes must not have any ongoing live migrations.
* **Note**: This command replaces all of a Firewall’s `inbound` and `outbound` rulesets with the values specified in your request.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long firewallId = 280563;

// Get
FirewallRules firewallRules = await linodeClient.Firewall.GetRules(firewallId);

// Allow port 80 tcp IN
FirewallRule firewallRuleIn80Tcp = new FirewallRule();
firewallRuleIn80Tcp.Label = "tcp-80-in-allow";
firewallRuleIn80Tcp.Description = "Allow al traffic int 80 tcp";
firewallRuleIn80Tcp.Action = eFirewallRulAction.ACCEPT;
firewallRuleIn80Tcp.Protocol = eFirewallProtocol.TCP;
firewallRuleIn80Tcp.Ports = "80";
firewallRuleIn80Tcp.Addresses = new FirewallRuleAddresses();
firewallRuleIn80Tcp.Addresses.IPv4.Add("8.8.8.8/32");
firewallRuleIn80Tcp.Addresses.IPv6.Add("2606:4700::6810:84e5/128");

// Add rule to Firewall
firewallRules.Inbound.Add(firewallRuleIn80Tcp);

// Update Rule
firewallRules = await linodeClient.Firewall.UpdateRule(firewallId, firewallRules);
```

## Devices List

Returns a paginated list of a Firewall’s Devices. A Firewall Device assigns a Firewall to a Linode service (referred to as the Device’s `entity`). Currently, only Devices with an entity of type `linode` are accepted.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long firewallId = 280563;

// Get
List<FirewallDevice> list = await linodeClient.Firewall.DeviceGet(firewallId);
```

## Device View

Returns information for a Firewall Device, which assigns a Firewall to a Linode service (referred to as the Device’s `entity`). Currently, only Devices with an entity of type `linode` are accepted.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long firewallId = 280563;
long deviceId = 605747;

// Get
FirewallDevice firewallDevice = await linodeClient.Firewall.DeviceGet(firewallId, deviceId);
```

## Device Create

Creates a Firewall Device, which assigns a Firewall to a service (referred to as the Device’s `entity`) and applies the Firewall’s Rules to the device.

* Currently, only Devices with an entity of type `linode` are accepted.
* A Firewall can be assigned to multiple Linode instances at a time.
* A Linode instance can have one active, assigned Firewall at a time. Additional disabled Firewalls can be assigned to a service, but they cannot be enabled if another active Firewall is already assigned to the same service.
* Assigned Linodes must not have any ongoing live migrations.
* A `firewall_device_add` Event is generated when the Firewall Device is added successfully.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long firewallId = 280563;
long linodeId = 52525566;

// Create device
FirewallDevice firewallDevice = await linodeClient.Firewall.DeviceCreate(firewallId, linodeId);
```

## Device Delete

Removes a Firewall Device, which removes a Firewall from the Linode service it was assigned to by the Device. This will remove all of the Firewall’s Rules from the Linode service. If any other Firewalls have been assigned to the Linode service, then those Rules will remain in effect.

* Assigned Linodes must not have any ongoing live migrations.
* A `firewall_device_remove` Event is generated when the Firewall Device is removed successfully.

```csharp
LinodeClient linodeClient = new LinodeClient("apikey");

long firewallId = 280563;
long deviceId = 605801;

// Delete device
await linodeClient.Firewall.DeviceDelete(firewallId, deviceId);
```

## JSON

```json
{
    "id": 280903,
    "label": "superFirewall",
    "created": "2023-12-01T02:23:42",
    "updated": "2023-12-01T02:26:19",
    "status": "enabled",
    "rules": {
        "inbound": [
            {
                "action": "ACCEPT",
                "addresses": {
                    "ipv4": [
                        "0.0.0.0/0"
                    ],
                    "ipv6": [
                        "::/0"
                    ]
                },
                "ports": "22",
                "protocol": "TCP",
                "label": "accept-inbound-SSH",
                "description": "ssh"
            },
            {
                "action": "ACCEPT",
                "addresses": {
                    "ipv4": [
                        "0.0.0.0/0"
                    ],
                    "ipv6": [
                        "::/0"
                    ]
                },
                "ports": "80",
                "protocol": "TCP",
                "label": "accept-inbound-HTTP",
                "description": "http"
            },
            {
                "action": "ACCEPT",
                "addresses": {
                    "ipv4": [
                        "0.0.0.0/0"
                    ],
                    "ipv6": [
                        "::/0"
                    ]
                },
                "ports": "443",
                "protocol": "TCP",
                "label": "accept-inbound-HTTPS",
                "description": "https"
            }
        ],
        "inbound_policy": "DROP",
        "outbound": [
            {
                "action": "DROP",
                "addresses": {
                    "ipv4": [
                        "0.0.0.0/0"
                    ],
                    "ipv6": [
                        "::/0"
                    ]
                },
                "ports": "3306",
                "protocol": "TCP",
                "label": "accept-outbound-MySQL",
                "description": "Deny MongoDB"
            }
        ],
        "outbound_policy": "ACCEPT"
    },
    "tags": []
}
```
