# RabbitMQMessageApplication

Companion code for my RabbitMQ articles: connecting to RabbitMQ, creating a channel and a queue, and sending and reading messages.

| Article | Blog | Medium |
|---|---|---|
| 🇹🇷 Nedir bu RabbitMQ? | [Blog](https://onurkarakus.com.tr/blog/nedir-bu-rabbitmq/) | [Medium](https://onnurkarakus.medium.com/nedir-bu-rabbitmq-28e3e9296ecd) |
| 🇹🇷 RabbitMQ İle İlk Adımlar | [Blog](https://onurkarakus.com.tr/blog/rabbitmq-ile-ilk-adimlar/) | [Medium](https://onnurkarakus.medium.com/rabbitmq-i%CC%87le-i%CC%87lk-ad%C4%B1mlar-572f0aea7d3f) |

> **Learning sample** written in 2021 for .NET Core 3.1 and `RabbitMQ.Client` 6. The connection uses the default local `guest` user.

## What it shows

- **Sender**: a console app that declares the `MessageTest` queue and publishes JSON messages
- **Receiver**: a console app that consumes the same queue with `EventingBasicConsumer`

## Run

Start RabbitMQ with the management UI:

```bash
docker run -d --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

Then run the two apps in separate terminals:

```bash
dotnet run --project RabbitMQMessageApplication.Receiver
```

```bash
dotnet run --project RabbitMQMessageApplication.Sender
```

The management UI is at `http://localhost:15672` (`guest` / `guest`).

Requires the .NET Core 3.1 SDK, or a newer SDK with `DOTNET_ROLL_FORWARD=Major`.
