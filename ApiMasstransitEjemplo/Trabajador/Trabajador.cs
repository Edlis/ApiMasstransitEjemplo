using ApiMasstransitEjemplo.Consumidor;
using MassTransit;
using Mensajes;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiMasstransitEjemplo.Trabajador
{
    public class Trabajador : BackgroundService

    {
        readonly IBus _bus;

        public Trabajador(IBus bus) {
            _bus = bus;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await _bus.Publish(new Correo { Mensaje = "sigue entrando aqui"  });

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}
