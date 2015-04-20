﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace UnitOfWorkImpl
{
    public class SqlExpressSessionFactory
    {
        public static ISessionFactory CreateFactory()
        {
            var factory =
                Fluently.Configure()
                    .Database(
                        MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("default")))
                        .ExposeConfiguration(c => Configuration = c)
                        .Mappings(m => m.FluentMappings.Add<PersonMapping>())
                        .Mappings(m => m.FluentMappings.Add<EmailMapping>())
                        .BuildSessionFactory();

            return factory;
        }

        public static Configuration Configuration { get; set; }
    }
}
