using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using SharedData.Models.FileModels;

namespace BackOffice.Client.Pages.UserPage.AddUserModal.UploadAvatar
{
    public partial class UploadAvatar : ComponentBase
    {
        private FileModel _uploadFile = new();
        private bool _showAvatar;
        private long _maxAllowedSize = 2048000;

        [Parameter] public string AvatarBase64 { get; set; }

        public string GetBase64Image() => $"data:image/jpeg;base64,{_uploadFile.Base64Content}";

        private void DeleteSelectedFile()
        {
            _uploadFile = new();
            _showAvatar = false;
            StateHasChanged();
        }

        private async void UploadFiles(IBrowserFile file)
        {
            if (!ValidateFile(file)) return;

            _uploadFile.File = file;
            _uploadFile.Name = file.Name;

            using var ms = new MemoryStream();
            await file.OpenReadStream(_maxAllowedSize).CopyToAsync(ms);
            _uploadFile.Base64Content = Convert.ToBase64String(ms.ToArray());

            _showAvatar = true;
            StateHasChanged();
        }

        private bool ValidateFile(IBrowserFile file)
        {
            if (file.Size < _maxAllowedSize) return true;

            _notificationService.Notify("The file size is too big, MAX 2 MB", Severity.Success);
            return false;
        }

    
    }
}
