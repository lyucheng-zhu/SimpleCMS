using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.CMS.Dtos
{
    [AutoMapFrom(typeof(CMSContent))]
    public class CMSContentDetailOutput : FullAuditedEntityDto<Guid>
    {
        public int id { get; set; }
        public string PageName { get; set; }

        public string PageContent { get; set; }
    }
}
