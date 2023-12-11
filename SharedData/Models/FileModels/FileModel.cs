using Microsoft.AspNetCore.Components.Forms;

namespace SharedData.Models.FileModels
{
    public class FileModel
    {
        public string Name { get; set; }
        public string Base64Content { get; set; }
        public IBrowserFile File { get; set; }
    }
}
