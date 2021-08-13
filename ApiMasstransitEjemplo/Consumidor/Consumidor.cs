using MassTransit;
using Mensajes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ApiMasstransitEjemplo.Consumidor
{
    public class Consumidor : IConsumer<Correo>
    {
        IHttpClientFactory _client;

        public Consumidor(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory;
        }
        public async Task Consume(ConsumeContext<Correo> context)
        {
            var Mensaje = context.Message;

            Console.WriteLine("Ha entrado al consumidor" + context.Message.Destinatario);

            var client = _client.CreateClient("Email");
            HttpResponseMessage response;
            StringContent xy = null;
            string responseBody = "";

            xy = new StringContent(JsonConvert.SerializeObject(context.Message), Encoding.UTF8, "application/json");

            try
            {
                response = await client.PostAsync("api/Correo/enviarCorreo", xy);
            }
            catch (Exception ex)
            {

                throw ex;
            }            
            var x = response.Content;
            if (response.IsSuccessStatusCode)
            {
                responseBody = await response.Content.ReadAsStringAsync();
            }
            else
            {
                response.EnsureSuccessStatusCode();
            }
        }

    }    
}
