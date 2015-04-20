using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;

namespace UnitOfWorkImpl
{
    class EmailMapping : ClassMap<Email>
    {
        public EmailMapping()
        {
            Table("EMAIL");
            Id(x => x.Id).GeneratedBy.Increment();
            Map(x => x.Sender).Column("SENDER").Not.Nullable();
            Map(x => x.Receiver).Column("RECEIVER ").Not.Nullable();
            Map(x => x.Subject).Column("SUBJECT").Not.Nullable();
            Map(x => x.Body).Column("BODY").Not.Nullable();
        }
    }
}
