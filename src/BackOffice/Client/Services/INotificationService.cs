using MudBlazor;

namespace BackOffice.Client.Services
{
    public interface INotificationService
    {
        void Notify(string message, Severity severity);
        void Notify(string message, Severity severity, string? positionClass);
    }
}
