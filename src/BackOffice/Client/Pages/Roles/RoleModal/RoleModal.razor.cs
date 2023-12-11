using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BackOffice.Client.Pages.Roles.RoleModal
{
    public partial class RoleModal : ComponentBase
    {
        public RoleModel Role { get; set; } = new();
        private EditContext _roleEditContext;

        private bool _showPermitionsError = false;

        public List<string> Permistions = new List<string>()
        {
            "UsersEntity", "CalendarEntity", "StatisticsEntity", "RolesEntity"
        };
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        protected override void OnInitialized()
        {
            _roleEditContext = new EditContext(Role);
        }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        void ValidateContext()
        {
            if (!Role.Permistions.Any())
            {
                _showPermitionsError = true;
                StateHasChanged();
            }
            if (_roleEditContext.Validate())
            {
                Submit();
            }
        }
    }
}
