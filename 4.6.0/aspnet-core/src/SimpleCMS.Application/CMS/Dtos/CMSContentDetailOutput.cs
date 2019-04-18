using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleCMS.CMS.Dtos
{
    public class CMSContentDetailOutput
    {
        public int id { get; set; }

        public string pageName { get; set; }

        public string pageContent { get; set; }
    }
}
