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
    public class CMSServiceAppService : SimpleCMSAppServiceBase, ICMSServiceAppService
    {
        private readonly ICMSContentManager _CMSContentManager;
        //private readonly IRepository<CMSContent, Int32> _CMSContentRepository;

        public CMSServiceAppService(
            ICMSContentManager CMSContentManager,
            IRepository<CMSContent, Guid> CMSContentRepository)
        {
            _CMSContentManager = CMSContentManager;
            //_CMSContentRepository = CMSContentRepository;
        }

        public async Task<CMSContentDetailOutput> GetCMSContent(int pageId)
        {
            var @CMSContent = await _CMSContentManager.GetOneAsync(pageId);

            if (@CMSContent == null)
            {
                throw new UserFriendlyException("Could not found the page, maybe it's deleted!");
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
            var @CMSContent = await _CMSContentManager.InsertOrUpdateAsync(input.id, input.pageName, input.pageContent);

            var @CMSContentDetailOutput = new CMSContentDetailOutput()
            {
                id = @CMSContent.PageId,
                pageName = @CMSContent.PageName,
                pageContent = @CMSContent.PageContent
            };

            return @CMSContentDetailOutput;
        }

        public async Task<CMSContentsOutput> GetAll()
        {
            var @CMSContents = await _CMSContentManager.GetAllAsync();

            /*if (@CMSContent == null)
            {
                throw new UserFriendlyException("Could not found the event, maybe it's deleted.");
            }*/

            var @CMSContentsOutput = new CMSContentsOutput();
            @CMSContentsOutput.items = new List<CMSContentDetailOutput>();

            foreach (CMSContent content in @CMSContents)
            {
                var @CMSContentDetailOutput = new CMSContentDetailOutput()
                {
                    id = content.PageId,
                    pageName = content.PageName,
                    pageContent = content.PageContent
                };

                @CMSContentsOutput.items.Add(@CMSContentDetailOutput);
            };

            return @CMSContentsOutput;
        }

    }
}
