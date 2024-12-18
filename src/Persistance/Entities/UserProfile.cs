﻿using Persistance.Enums;
using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class UserProfile : SoftDeleteBaseEntity
    {
        public string Email { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string PhoneNumber { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime BirthDay { get; set; }

        public int SystemRoleId { get; set; }
        public SystemRole SystemRole { get; set; }

        public int? AvatarId { get; set; }
        public Avatar Avatar { get; set; }

        public ICollection<Request> Requests { set; get; }
        public ICollection<ScheduledRequest> ScheduledRequests { set; get; }
    }
}
