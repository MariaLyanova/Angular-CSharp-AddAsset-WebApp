using System;

namespace DomainClasses
{
    public class Asset
    {
        public Guid AssetId { get; set; }
        public string FileName { get; set; }
        public virtual MimeType MimeType { get; set; }
        public string CreatedBy { get; set; }
        public string Email { get; set; }
        public virtual Country Country { get; set; }
        public string Description { get; set; }
    }
}