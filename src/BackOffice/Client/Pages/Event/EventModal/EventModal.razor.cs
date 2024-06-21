using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.Data;
using SharedData.Models;

namespace BackOffice.Client.Pages.Event.EventModal
{
    public partial class EventModal : ComponentBase
    {
        private bool _isLoading;
        private bool _showLocationsError;

        [Parameter]
        public EventModel Event { get; set; } = new();
        private EditContext _eventEditContext;

        public List<LocationModel> Locations = new() { };

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            StateHasChanged();

            _eventEditContext = new EditContext(Event);
            Locations = await LocationService.GetLocations();
            Event.EventTime = DateTime.Now;

            _isLoading = false;
            StateHasChanged();
        }


        void Submit() => MudDialog.Close(DialogResult.Ok(true));

        void Cancel() => MudDialog.Cancel();

        public async Task ValidateContext()
        {
            if (Event.Location == null)
            {
                _showLocationsError = true;
                StateHasChanged();
            }
            if (_eventEditContext.Validate())
            {
                await EventService.AddEditEvent(Event);
                Submit();
            }
        }

        void OnMudSelectChanged()
        {
            _showLocationsError = false;
            StateHasChanged();
        }

        Func<LocationModel, string> converter = p => p?.Name;
    }
}
