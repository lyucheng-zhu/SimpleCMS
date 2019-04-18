using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.CMS
{
    public interface ICMSContentManager : IDomainService
    {
        Task<CMSContent> GetOneAsync(int pageId);

        Task<List<CMSContent>> GetAllAsync();

        Task<CMSContent> InsertOrUpdateAsync(int pageId, string pageName, string pageContent);

    }
}
