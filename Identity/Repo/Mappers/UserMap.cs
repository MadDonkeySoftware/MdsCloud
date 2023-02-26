using FluentNHibernate.Mapping;
using Identity.Domain;

namespace Identity.Repo.Mappers;

public class UserMap : ClassMap<User>
{
    UserMap()
    {
        Id(u => u.Id).Column("id");
        Map(u => u.Email).Column("email");
        Map(u => u.FriendlyName).Column("friendly_name");
        Map(u => u.Password).Column("password");
        Map(u => u.IsPrimary).Column("is_primary");
        Map(u => u.IsActive).Column("is_active");
        Map(u => u.ActivationCode).Column("activation_code");
        Map(u => u.Created).Column("created");
        Map(u => u.LastActivity).Column("last_activity");
        Map(u => u.LastModified).Column("last_modified");
        References<Account>(u => u.Account).Column("account_id");
    }
}