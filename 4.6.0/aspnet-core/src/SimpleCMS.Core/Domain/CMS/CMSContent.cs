using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.Domain.CMS
{
    public static class DomainCMSContent
    {
        public static IEventBus EventBus { get; set; }

        static DomainCMSContent()
        {
            EventBus = Abp.Events.Bus.EventBus.Default;
        }
    }
}
