using MudBlazor;

namespace BackOffice.Client.Services.Implementation
{
    public class NotificationService : INotificationService
    {
        private readonly ISnackbar _snackbar;

        public NotificationService(ISnackbar snackbar)
        {
            _snackbar = snackbar;
        }

        public void Notify(string message, Severity severity)
        {
            _snackbar.Configuration.PositionClass = Defaults.Classes.Position.BottomRight;
            _snackbar.Add(message, severity);
        }

        public void Notify(string message, Severity severity, string? positionClass)
        {
            _snackbar.Configuration.PositionClass = positionClass;
            _snackbar.Add(message, severity);
        }
    }
}
