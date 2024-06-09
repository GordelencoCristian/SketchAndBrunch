using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.Data;

namespace BackOffice.Client.Pages.Location.LocationModal
{
    public partial class LocationModal : ComponentBase
    {
        private bool _isLoading;
        [Parameter]
        public LocationModel Location { get; set; } = new();
        private EditContext _locationEditContext;

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            StateHasChanged();

            _locationEditContext = new EditContext(Location);

            _isLoading = false;
            StateHasChanged();
        }


        void Submit() => MudDialog.Close(DialogResult.Ok(true));

        void Cancel() => MudDialog.Cancel();

        public async Task ValidateContext()
        {
            if (_locationEditContext.Validate())
            {
                await LocationService.AddEditLocation(Location);
                Submit();
            }
        }

        void OnMudSelectChanged()
        {
            StateHasChanged();
        }

        Func<PermissionsModel, string> converter = p => p?.Name;
    }
}
