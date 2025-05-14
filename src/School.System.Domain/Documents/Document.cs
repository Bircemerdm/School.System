using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace School.System.Documents;

public class Document : FullAuditedAggregateRoot<Guid>
{
    public long FileSize { get; set; }

    public string MimeType { get; set; }
    
    public string FileUrl { get; set; }
    
    protected Document()
    {
    }

    public Document(
        Guid id,
        long fileSize,
        string mimeType, 
        string fileUrl
    ) : base(id)
    {
        FileSize = fileSize;
        MimeType = mimeType;
        FileUrl= fileUrl;
       
    }
}