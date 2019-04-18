using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.CMS.Dtos
{
    public class CMSContentsOutput
    {
        public List<CMSContentDetailOutput> items { get; set; }

    }
}
