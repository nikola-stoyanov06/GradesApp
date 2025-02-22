using Microsoft.AspNetCore.Mvc.Rendering;

namespace GradesApp.DTOs
{
    public class CreateGradeDTO : GradeDTO
    {
        public  List<SelectListItem>? Students { get; set; }
    }
}
