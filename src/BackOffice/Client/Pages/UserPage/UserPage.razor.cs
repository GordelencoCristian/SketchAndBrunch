using BackOffice.Client.Pages.Roles.RoleModal;
using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace BackOffice.Client.Pages.UserPage
{
    public partial class UserPage : ComponentBase
    {
        readonly DialogOptions _modalOptions = new() { CloseButton = true };

        private async Task OpenModal(UserProfileModel? userProfile)
        {
            if (userProfile == null)
            {
                await ShowModal("Add UserProfile");
            }
            else
            {
                var parameters = new DialogParameters<AddUserModal.AddUserModal> { { x => x.UserProfileModel, userProfile } };
                await ShowModal("Edit UserProfile", parameters);
            }
        }

        private async Task ShowModal(string title, DialogParameters<AddUserModal.AddUserModal>? parameters = null)
        {
            var dialog = parameters == null
                ? await DialogService.ShowAsync<AddUserModal.AddUserModal>(title, _modalOptions)
                : await DialogService.ShowAsync<AddUserModal.AddUserModal>(title, parameters, _modalOptions);

            var result = await dialog.Result;

            if (!result.Canceled)
            {
                await OnInitializedAsync();
            }
        }
    }
}
