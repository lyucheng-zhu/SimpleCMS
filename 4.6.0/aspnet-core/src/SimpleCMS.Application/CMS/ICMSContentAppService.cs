using Abp.Application.Services.Dto;
using SimpleCMS.CMS.Dtos;
using System;
using System.Threading.Tasks;

namespace SimpleCMS.CMS
{
    public interface ICMSContentAppService
    {
        Task<CMSContentDetailOutput> GetAll(EntityDto<Guid> input);

        Task<CMSContentDetailOutput> InsertOrUpdateCMSContent(CreateCMSContentInput input);
}
}