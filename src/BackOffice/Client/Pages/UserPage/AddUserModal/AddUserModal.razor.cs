using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SharedData.Models.Reference;
using System.Globalization;
using System.Linq;

namespace BackOffice.Client.Pages.UserPage.AddUserModal
{
    public partial class AddUserModal : ComponentBase
    {
        public UserProfileModel Model { get; set; } = new();

        private EditContext? _userProfileEditContext;

        public List<RoleModel> RoleList = new()
        {
            //new()
            //{
            //    Name = "Administrator",
            //    Id = 1
            //},
            //new()
            //{
            //    Name = "User",
            //    Id = 2
            //},
            //new()
            //{
            //    Name = "Person",
            //    Id = 3
            //},
        };

        public List<CountryModel> CountryList = new()
        {
            new CountryModel("Republic of Moldova", "MD", "+373", "Icons\\Images\\md.png"),
            new CountryModel("Romania", "RO", "+40", "Icons\\Images\\ro.png")
        };

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        protected override void OnInitialized()
        {
            _userProfileEditContext = new EditContext(Model);
        }

        void Submit() => MudDialog.Close(DialogResult.Ok(true));
        void Cancel() => MudDialog.Cancel();

        void SelectValueChanged()
        {
            if (Model.Country != null) Model.PhoneNumber = Model.Country.PhoneCode;
        }

        private void ValidateContext()
        {
            //_form.Validate();
            var isValid = _userProfileEditContext != null && _userProfileEditContext.Validate();

            if (isValid) { Submit();} else return;
        }


        private void OnValidSubmit(EditContext context)
        {
            StateHasChanged();
        }

        string GetPhoneNumberHelperText()
        {
            return Model.Country?.Code switch
            {
                "MD" => $"{Model.Country?.PhoneCode} - (xx) - xxx - xxx",
                "RO" => $"{Model.Country?.PhoneCode} - (xxx) - xxx - xxx",
                _ => string.Empty
            };
        }
    }
}
