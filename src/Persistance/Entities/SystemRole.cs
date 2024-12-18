﻿using Persistance.TrackingEntity;

namespace Persistance.Entities
{
    public class SystemRole : SoftDeleteBaseEntity
    {
        public string Name { get; set; }
        
        public ICollection<UserProfile> UserProfiles { set; get; }

        public ICollection<SystemRolePermissions> SystemRolePermissions { get; set; }
    }
}
