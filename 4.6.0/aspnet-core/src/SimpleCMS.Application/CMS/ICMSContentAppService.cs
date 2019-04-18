using Abp.Application.Services.Dto;
using SimpleCMS.CMS.Dtos;
using System;
using System.Threading.Tasks;

namespace SimpleCMS.CMS
{
    public interface ICMSContentAppService
    {
        Task<CMSContentDetailOutput> GetAll();

        Task<CMSContent> InsertOrUpdateCMSContent(CreateCMSContentInput input);
    }
}