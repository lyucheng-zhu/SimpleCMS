using Abp.Application.Services.Dto;
using SimpleCMS.CMS.Dtos;
using System;
using System.Threading.Tasks;

namespace SimpleCMS.CMS
{
    public interface ICMSServiceAppService
    {
        Task<CMSContentDetailOutput> GetCMSContent(int pageId);

        Task<CMSContentDetailOutput> InsertOrUpdateCMSContent(CreateCMSContentInput input);

        Task<CMSContentsOutput> GetAll();
    }
}