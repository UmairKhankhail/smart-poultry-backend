using Abp.Application.Services.Dto;

namespace SmartPoultry.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

