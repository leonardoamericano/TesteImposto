using Flunt.Notifications;
using System;

namespace Imposto.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public long Id { get; set; }

        protected Entity()
        {
            Id = DateTime.Now.Ticks;
        }

    }
}
