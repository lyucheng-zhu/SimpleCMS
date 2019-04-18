using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleCMS.CMS
{
    public class CMSContentManager : ICMSContentManager
    {
        public IEventBus EventBus { get; set; }

        private readonly IRepository<CMSContent, Guid> _CMSContentRepository;

        public CMSContentManager(IRepository<CMSContent, Guid> CMSContentRepository)
        {
            _CMSContentRepository = CMSContentRepository;

            EventBus = NullEventBus.Instance;
        }

        public async Task<CMSContent> GetOneAsync(int pageId)
        {
            var @CMSContent = await _CMSContentRepository
                                    .FirstOrDefaultAsync(@CMSContents => @CMSContents.PageId == pageId);

            /*if (@CMSContent == null)
            {
                throw new UserFriendlyException("Could not found the page, maybe it's deleted!");
            }*/

            return @CMSContent;
        }

        public async Task<List<CMSContent>> GetAllAsync()
        {
            var @CMSContents = await _CMSContentRepository.GetAllListAsync();

            /*if (@CMSContents == null)
            {
                throw new UserFriendlyException("Could not found any page, maybe they're all deleted!");
            }*/

            return @CMSContents;
        }

        public async Task<CMSContent> InsertOrUpdateAsync(int pageId, string pageName, string pageContent)
        {
            var @CMSContent = await _CMSContentRepository
                                    .FirstOrDefaultAsync(@CMSContents => @CMSContents.PageId == pageId);

            var _CMSContent = CMS.CMSContent.Create(pageId, pageName, pageContent);

            if (@CMSContent != null)
            {
                await _CMSContentRepository.DeleteAsync(@CMSContent);
            }

            await _CMSContentRepository.InsertAsync(_CMSContent);

            return _CMSContent;
        }

    }
}
