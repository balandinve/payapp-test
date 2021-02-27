using Microsoft.Extensions.DependencyInjection;
using payapp.data.Models;
using payapp.message.receive.OrderReceiver;
using payapp.message.send.OrderSender;
using payapp.services.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace payapp.api
{
    public static class DependencyInjection
    {
        public static void AddDepencyInjection(this IServiceCollection services)
        {
            services.AddTransient<AppDbContext>();
            services.AddTransient<IClientPayService, ClientPayService>();
            //services.AddScoped<IOrderSender, OrderSender>();
        }
    }
}
