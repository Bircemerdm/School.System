using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Volo.Abp.BlobStoring;
using Volo.Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;


namespace School.System.Documents;

public class DocumentAppService : SystemAppService
{
    private readonly IBlobContainer<DocumentStudent> _blobContainer;
    private readonly IRepository<Document, Guid> _repository;
    public DocumentAppService(IRepository<Document, Guid> repository, IBlobContainer<DocumentStudent> blobContainer)
    {
        _repository = repository;
        _blobContainer = blobContainer;
    }
public async Task<List<DocumentDto>> Upload([FromForm] List<IFormFile> files)
{
    var output = new List<DocumentDto>();
    foreach (var file in files)
    {
        using var memoryStream = new MemoryStream();
        await file.CopyToAsync(memoryStream).ConfigureAwait(false);

        var id = Guid.NewGuid();
        var fileUrl = $"/api/app/document/{id}"; // Dosya erişim endpoint'in

        var newFile = new Document(id, file.Length, file.ContentType, fileUrl);

        await _repository.InsertAsync(newFile);
        await _blobContainer.SaveAsync(id.ToString(), memoryStream.ToArray(), overrideExisting: true);

        var dto = ObjectMapper.Map<Document, DocumentDto>(newFile);
        dto.FileUrl = fileUrl; // (Opsiyonel) DTO'ya tekrar set edebilirsin
        output.Add(dto);
    }

    return output;
}
    public async Task<FileResult> Get(Guid id)
    {
        var currentFile = await _repository.FirstOrDefaultAsync(x => x.Id == id);
        if (currentFile != null)
        {
            var myfile = await _blobContainer.GetAllBytesOrNullAsync(id.ToString());
            return new FileContentResult(myfile, currentFile.MimeType);
        }

        throw new FileNotFoundException();
    }
}
