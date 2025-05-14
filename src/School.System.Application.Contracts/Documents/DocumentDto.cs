using System;
using Volo.Abp.Application.Dtos;

namespace School.System.Documents;

public class DocumentDto : EntityDto<Guid>
{
    public long FileSize { get; set; }

    public string FileUrl { get; set; }

    public string MimeType { get; set; }
}