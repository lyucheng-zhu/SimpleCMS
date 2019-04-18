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

        public async Task<CMSContentDetailOutput> GetAll()
        {
            var @CMSContent = await _CMSContentRepository
                .GetAll()
                .FirstOrDefaultAsync();

            if (@CMSContent == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            var @CMSContentDetailOutput = new CMSContentDetailOutput()
            {
                id = @CMSContent.PageId,
                pageName = @CMSContent.PageName,
                pageContent = @CMSContent.PageContent
            };

            return @CMSContentDetailOutput;
        }

        public async Task<CMSContentDetailOutput> InsertOrUpdateCMSContent(CreateCMSContentInput input)
        {
            var @CMSContent = CMS.CMSContent.Create(input.id, input.pageName, input.pageContent);
            return await _CMSContentManager.CreateAsync(@CMSContent);
        }

        public async Task<CMSContentDetailOutput> GetCMSContent(int pageId)
        {
            var @CMSContent = await _CMSContentRepository
                .GetAll()
                .Where(e => e.PageId == pageId)
                .FirstOrDefaultAsync();

            if (@CMSContent == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }

            return @CMSContent.MapTo<CMSContentDetailOutput>();
        }
    }
}
