using SharedData.Enums;

namespace BackOffice.Shared.Models
{
    public class ChangeStatusModel
    {
        public ChangeStatusModel(RequestStatusEnumModel status, int id)
        {
            Status = status;
            Id = id;
        }

        public int Id { get; set; }
        public RequestStatusEnumModel Status { get; set; }
    }
}
