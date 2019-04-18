using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleCMS.CMS.Dtos
{
    public class CreateCMSContentInput
    {
        public int id { get; set; }

        [Required]
        [StringLength(CMS.CMSContent.MaxPageNameLength)]
        public string pageName { get; set; }

        [StringLength(CMS.CMSContent.MaxPageContentLength)]
        public string pageContent { get; set; }
    }
}
