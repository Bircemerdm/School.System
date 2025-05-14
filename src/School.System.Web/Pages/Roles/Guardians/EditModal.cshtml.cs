using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using School.System.Roles.Guardians;
using Volo.Abp;


namespace School.System.Web.Pages.Roles.Guardians;

public class EditModalModel : SystemPageModel
{
   [HiddenInput]
   [BindProperty(SupportsGet = true)]
   
   public Guid Id { get; set; }
   
   [BindProperty]
   public GuardianUpdateViewModel Guardian { get; set; }
   
   protected IGuardianAppService _guardianAppService;

   public EditModalModel(IGuardianAppService guardianAppService)
   {
      _guardianAppService = guardianAppService;
      Guardian = new();
   }

   public virtual async Task OnGetAsync() //sayfa yüklendiğinde çalışacak
   {
      var guardianDto = await _guardianAppService.GetAsync(Id);
      Guardian = ObjectMapper.Map<GuardianDto, GuardianUpdateViewModel>(guardianDto);
   }

   public virtual async Task<IActionResult> OnPostAsync()
   {
      if (Id == Guid.Empty)
      {
         throw new UserFriendlyException("Geçersiz ID: id boş olamaz.");
      }
      await _guardianAppService.UpdateAsync(Id,ObjectMapper.Map<GuardianUpdateViewModel, CreateUpdateGuardianDto>(Guardian));
      return NoContent();
   }
   
   
}

public class GuardianUpdateViewModel : CreateUpdateGuardianDto
{
   
}