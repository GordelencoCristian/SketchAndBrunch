using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SharedData.Models.Reference;

namespace BackOffice.Client.Pages.UserPage.AddUserModal
{
    public partial class AddUserModal : ComponentBase
    {
        public UserProfileModel Model { get; set; } = new ()
        {
            PhoneNumber = "+373"
        };

        private EditContext? _userProfileEditContext;

        public List<RoleModel> RoleList = new()
        {
            new()
            {
                Name = "Administrator",
                Id = 1
            },
            new()
            {
                Name = "User",
                Id = 2
            },
            new()
            {
                Name = "Person",
                Id = 3
            },
        };

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }

        protected override void OnInitialized()
        {
            _userProfileEditContext = new EditContext(Model);
        }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        private void ValidateContext()
        {
           var isValid = _userProfileEditContext != null && _userProfileEditContext.Validate();

           if (isValid) { Submit();} else return;
        }

        private void OnValidSubmit(EditContext context)
        {
            StateHasChanged();
        }
    }
}
