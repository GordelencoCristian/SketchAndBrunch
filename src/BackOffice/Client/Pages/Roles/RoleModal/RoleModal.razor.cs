using BackOffice.Client.Services;
using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;

namespace BackOffice.Client.Pages.Roles.RoleModal
{
    public partial class RoleModal : ComponentBase
    {
        private bool _isLoading;
        private bool _showPermissionsError;
        [Parameter]
        public RoleModel Role { get; set; } = new();
        private EditContext _roleEditContext;

        public List<PermissionsModel> Permissions = new() { };
        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            StateHasChanged();

            _roleEditContext = new EditContext(Role);

            Permissions = await RoleService.GetRolePermissions();

            _isLoading = false;
            StateHasChanged();
        }


        void Submit() => MudDialog.Close(DialogResult.Ok(true));

        void Cancel() => MudDialog.Cancel();

        public async  Task ValidateContext()
        {
            if (!Role.Permissions.Any())
            {
                _showPermissionsError = true;
                StateHasChanged();
            }

            if (Role.Permissions.Any() && _roleEditContext.Validate())
            {
                await RoleService.AddEditRolePermissions(Role);
                Submit();
            }
        }

        void OnMudSelectChanged()
        {
            _showPermissionsError = false;
            StateHasChanged();
        }

        Func<PermissionsModel, string> converter = p => p?.Name;
    }
}
