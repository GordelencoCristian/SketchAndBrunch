using BackOffice.Client.Services.Implementation;
using BackOffice.Shared.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SharedData.Models;

namespace BackOffice.Client.Pages.Requests.RequestModal
{
    public partial class RequestModal : ComponentBase
    {
        private bool _isLoading;
        private bool _showEventsError;
        private bool _showUsersError;

        [Parameter]
        public RequestModel Request { get; set; } = new();
        private EditContext _RequestEditContext;

        public List<EventModel> Events = new() { };
        public List<UserProfileModel> Users = new() { };

        [CascadingParameter] MudDialogInstance MudDialog { get; set; }
        protected override async Task OnInitializedAsync()
        {
            _isLoading = true;
            StateHasChanged();

            _RequestEditContext = new EditContext(Request);
            Events = await EventService.GetEvents();
            Users = await UserProfileService.GetUserProfiles();

            //Request.RequestTime = DateTime.Now;

            _isLoading = false;
            StateHasChanged();
        }


        void Submit() => MudDialog.Close(DialogResult.Ok(true));

        void Cancel() => MudDialog.Cancel();

        public async Task ValidateContext()
        {
            if (Request.Event == null)
            {
                _showEventsError = true;
                StateHasChanged();
            }
            if (Request.UserProfile == null)
            {
                _showUsersError = true;
                StateHasChanged();
            }
            if (_RequestEditContext.Validate())
            {
                await RequestService.AddEditRequest(Request);
                Submit();
            }
        }

        void OnMudEventSelectChanged()
        {
            _showEventsError = false;
            StateHasChanged();
        }
        void OnMudUserSelectChanged()
        {
            _showUsersError = false;
            StateHasChanged();
        }

        Func<EventModel, string> eventConverter = p => p?.Name;
        Func<UserProfileModel, string> userConverter = p => p?.Email;
    }
}
