﻿using DotNetFramework.CAP;
using DotNetFramework.CAP.Core.Ioc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace CapWeb251
{
    public class CapConfig
    {
        public static IServiceCollection Services { get; set; }

        public static void RegisterCap()
        {
            Services = new ServiceCollection();
            Services.AddCap(stetup =>
            {
                // 注册节点到 Consul
                stetup.UseSqlServer("Data Source=localhost;database=donet61;Uid=sa;pwd=sa;");
                stetup.UseRabbitMQ(option =>
                {
                    option.VirtualHost = "HengQueue";
                    option.HostName = "localhost";
                    option.Port = 5672;
                    option.UserName = "zhangheng";
                    option.Password = "123456";
                });
            });
            Services.BeginRegister();
            Services.ServiceProvider.GetService<IBootstrapper>().BootstrapAsync(new CancellationToken());
        }
    }
}