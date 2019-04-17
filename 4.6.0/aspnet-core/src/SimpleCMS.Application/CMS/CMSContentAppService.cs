using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.AutoMapper;
using Abp.Domain.Repositories;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using SimpleCMS.CMS;
using SimpleCMS.CMS.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCMS.CMS
{
    [AbpAuthorize]
    public class CMSContentAppService : SimpleCMSAppServiceBase, ICMSContentAppService
    {
        private readonly ICMSContentManager _CMSContentManager;
        private readonly IRepository<CMSContent, Guid> _CMSContentRepository;

        public CMSContentAppService(
            ICMSContentManager CMSContentManager,
            IRepository<CMSContent, Guid> CMSContentRepository)
        {
            _CMSContentManager = CMSContentManager;
            _CMSContentRepository = CMSContentRepository;
        }

        /*public async Task<ListResultDto<EventListDto>> GetListAsync(GetEventListInput input)
        {
            var events = await _eventRepository
                .GetAll()
                .Include(e => e.Registrations)
                .WhereIf(!input.IncludeCanceledEvents, e => !e.IsCancelled)
                .OrderByDescending(e => e.CreationTime)
                .Take(64)
                .ToListAsync();

            return new ListResultDto<EventListDto>(events.MapTo<List<EventListDto>>());
        }*/

        public async Task<CMSContentDetailOutput> GetAll(EntityDto<Guid> input)
        {
            var @CMSContent = await _CMSContentRepository
                .GetAll()
                .Where(e => e.Id == input.Id)
                .FirstOrDefaultAsync();

            if (@CMSContent == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @CMSContent.MapTo<CMSContentDetailOutput>();
        }

        public async Task<CMSContentDetailOutput> InsertOrUpdateCMSContent(CreateCMSContentInput input)
        {
            var @CMSContent = CMS.CMSContent.Create(AbpSession.GetTenantId(), input.id, input.PageName, input.PageContent);
            return (await _CMSContentManager.CreateAsync(@CMSContent)).MapTo<CMSContentDetailOutput>();
        }

        public async Task<CMSContentDetailOutput> GetCMSContent(int pageid)
        {
            var @CMSContent = await _CMSContentRepository
                .GetAll()
                .Where(e => e.id == pageid)
                .FirstOrDefaultAsync();

            if (@CMSContent == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @CMSContent.MapTo<CMSContentDetailOutput>();
        }
    }
}
