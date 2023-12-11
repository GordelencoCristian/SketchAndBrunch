using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BackOffice.Client.Pages.UserPage
{
    public partial class UserPage : ComponentBase
    {
        readonly DialogOptions _modalOptions = new() { CloseButton = true };

        private void OpenModal(DialogOptions options)
        {
            DialogService.Show<AddUserModal.AddUserModal>("Add user", options);
        }
    }
}
