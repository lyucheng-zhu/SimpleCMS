using Abp.Domain.Repositories;
using Abp.Events.Bus;
using Abp.UI;
using System;
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

        public async Task<CMSContent> GetAsync(Guid id)
        {
            var @event = await _CMSContentRepository.FirstOrDefaultAsync(id);
            if (@event == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted!");
            }

            return @event;
        }

        public async Task<CMSContent> CreateAsync(CMSContent @CMSContent)
        {
            return await _CMSContentRepository.InsertAsync(@CMSContent);
        }

    }
}
