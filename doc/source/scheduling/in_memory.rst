Hosting Quartz In-Memory
------------------------

One of the nice features of quartz is that it can run entirely in memory without any additional dependencies.

To use Quartz in-memory for message scheduling:

1. Use the NuGet package manager to add the ``MassTransit.Quartz`` package to your project.
2. Add the extension method to your bus configuration.

.. sourcecode:: csharp

    var busControl = Bus.Factory.CreateUsingRabbitMq(cfg =>
    {
        var host = cfg.Host(new Uri("rabbitmq://localhost/"), h =>
        {
            h.Username("guest");
            h.Password("guest");
        });

        cfg.UseInMemoryMessageScheduler();
    });


The ``UseInMemoryScheduler`` method initializes Quartz.NET for standalone in-memory operation, and adds
a receive endpoint to the bus named "quartz", which hosts the consumers for scheduling messages.

.. warning::

    Using the in-memory scheduler uses non-durable storage. If the process terminates, any scheduled messages
    will be lost, immediately, never to be found again. For any production system, using a standalone service
    is recommended with persistent storage.
