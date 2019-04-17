using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.CMS
{
    public interface ICMSContentManager : IDomainService
    {
        Task<CMSContent> GetAsync(Guid id);

        Task<CMSContent> CreateAsync(CMSContent @event);

    }
}
