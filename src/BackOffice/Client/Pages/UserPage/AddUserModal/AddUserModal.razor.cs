using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using BackOffice.Client.Pages.UserPage.AddUserModal.UploadAvatar;
using SharedData.Models.Reference;
using System.Globalization;
using System.Linq;

namespace BackOffice.Client.Pages.UserPage.AddUserModal
{
    public partial class AddUserModal : ComponentBase
    {
        private bool _isLoading = false;

        [Parameter]
        public UserProfileModel UserProfileModel { get; set; } = new();

        private EditContext? _userProfileEditContext;

        //private UploadAvatar.UploadAvatar _uploadAvatarComponent;

        public List<RoleModel> RoleList = new();

        public List<CountryModel> CountryList = new()
        {
            new CountryModel("Republic of Moldova", "MD", "+373", "Icons\\Images\\md.png"),
            new CountryModel("Romania", "RO", "+40", "Icons\\Images\\ro.png")
        };

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
      

        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            StateHasChanged();

            RoleList = await RoleService.GetUserProfileRoles();
            ConsoleLog.LogAsJson("UserProfile:", UserProfileModel);
            _userProfileEditContext = new EditContext(UserProfileModel);

            _isLoading = false;
            StateHasChanged();
        }

        string GetRoleName()
        {
            return UserProfileModel?.Role?.Name ?? String.Empty;
        }
        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        void SelectValueChanged()
        {
            if (UserProfileModel.Country != null) UserProfileModel.PhoneNumber = UserProfileModel.Country.PhoneCode;
        }

        private async Task ValidateContext()
        {
            var isValid = _userProfileEditContext != null && _userProfileEditContext.Validate();
            ConsoleLog.LogAsJson("isValid:", isValid);
            ConsoleLog.LogAsJson("isValid:", _userProfileEditContext.GetValidationMessages());

            if (isValid)
            {
                //UserProfileModel.AvatarBase64 = _uploadAvatarComponent.GetBase64Image();

                ConsoleLog.LogAsJson("UserToAdd:", UserProfileModel);
                await UserProfileService.AddEditUserProfile(UserProfileModel);
                ConsoleLog.LogAsJson("AddEditUserProfile:");

                Submit();
            }
            else return;
        }


        private void OnValidSubmit(EditContext context)
        {
            StateHasChanged();
        }

        string GetPhoneNumberHelperText()
        {
            return UserProfileModel.Country?.Code switch
            {
                "MD" => $"{UserProfileModel.Country?.PhoneCode} - (xx) - xxx - xxx",
                "RO" => $"{UserProfileModel.Country?.PhoneCode} - (xxx) - xxx - xxx",
                _ => string.Empty
            };
        }
    }
}
