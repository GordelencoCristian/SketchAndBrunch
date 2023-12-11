using BackOffice.Client.Pages.UserPage.AddUserModal;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BackOffice.Client.Pages.Roles
{
    public partial class RolesPage : ComponentBase
    {
        readonly DialogOptions _modalOptions = new() { CloseButton = true };

        private void OpenModal(DialogOptions options)
        {
            DialogService.Show<RoleModal.RoleModal>("Add role", options);
        }
    }
}
