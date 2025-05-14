using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using School.System.Roles.Guardians;

namespace School.System.Web.Pages.Roles.Guardians;

public class CreateModalModel : SystemPageModel
{
    [BindProperty]
    public GuardianCreateViewModel Guardian{get;set;}
    protected IGuardianAppService _guardianAppService;

    public CreateModalModel(IGuardianAppService guardianAppService)
    {
        _guardianAppService = guardianAppService;
        Guardian = new();//boş bir nesne olarak başlatıyorsun, yani form açıldığında null değil, hazır bir nesne olacak.
        //Bu sayede Razor Page'de asp-for="Guardian.Name" gibi kullanımlar hata vermez.
    }

    public virtual async Task OnGetAsync() //Razor Pages yaşam döngüsündeki GET isteği sırasında çalışacak metottur
    {  //Roles/Guardians/CreateModal sayfası açıldığında bu metot tetiklenir.
        //virtual: Bu metot başka sınıflar tarafından override edilebilir, yani özelleştirilebilir.
     Guardian= new GuardianCreateViewModel();
     await Task.CompletedTask;
    }

    public virtual async Task<IActionResult> OnPostAsync()
    {
        await _guardianAppService.CreateAsync(ObjectMapper.Map<GuardianCreateViewModel, CreateUpdateGuardianDto>(Guardian));
        return NoContent();
    }
}
public class GuardianCreateViewModel :  CreateUpdateGuardianDto
{
    
}