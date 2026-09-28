# Communication

C# WCF sample with a shared `IComms` contract plus WinForms Client and Server hosts. The server self-hosts `Comms` at `http://localhost:8000/Stratatel/wcf/comms` with WSHttpBinding and metadata exchange; the client opens a `CommsClient` channel and calls `SendMessage` / `ReceiveMessage`. Useful for learning Stratatel-style duplex messaging over WCF on .NET Framework 3.5.

**Source last updated:** 2008-05-28  
**Language:** C#  
**Target:** .NET Framework 3.5  
**Output:** Class library plus Client and Server WinForms executables

## Solution structure

| Project | Language | Type | Purpose |
| --- | --- | --- | --- |
| `WCFComms` | C# | Library | `IComms` service contract and `Comms` implementation (`Stratatel.wcf.comms`) |
| `Server` | C# | WinForms exe | Self-hosts the WCF service and shows received messages |
| `Client` | C# | WinForms exe | WCF client that sends test messages to the local endpoint |

## How to open

Open `Communication.sln` in Visual Studio.

## Requirements

- Visual Studio 2008 to 2017
- .NET Framework 3.5
- Permission to listen on `http://localhost:8000` for the Server host

## Attribution and provenance

Working copy from my Historical Dev folder. Namespace and endpoint use the Stratatel WCF comms sample naming from this tree.

## License

MIT. See `LICENSE`.
