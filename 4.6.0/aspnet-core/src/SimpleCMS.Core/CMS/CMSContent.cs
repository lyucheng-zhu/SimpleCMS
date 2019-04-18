using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using Abp.UI;
using SimpleCMS.Domain.CMS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SimpleCMS.CMS
{
    [Table("AppCMSContents")]
    public class CMSContent : FullAuditedEntity<Guid>
    {
        public const int MaxPageNameLength = 128;
        public const int MaxPageContentLength = 2048;

        [Required]
        public virtual int PageId { get; protected set; }

        [Required]
        [StringLength(MaxPageNameLength)]
        public virtual string PageName { get; protected set; }

        [StringLength(MaxPageContentLength)]
        public virtual string PageContent { get; protected set; }

        /// <summary>
        /// We don't make constructor public and forcing to create events using <see cref="Create"/> method.
        /// But constructor can not be private since it's used by EntityFramework.
        /// Thats why we did it protected.
        /// </summary>
        protected CMSContent()
        {

        }

        public static CMSContent Create(int pageId, string pageName, string pageContent = null)
        {
            var @CMSContent = new CMSContent
            {
                Id = Guid.NewGuid(),
                PageId = pageId,
                PageName = pageName,
                PageContent = pageContent
            };

            return @CMSContent;
        }

    }
}
