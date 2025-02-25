namespace Serene2.hospital;

[NestedPermissionKeys]
[DisplayName("Hospital")]
public class hospitalPermissionKeys
{
    [DisplayName("Doctors")]
    public class Doctors
    {
        [Description("View")]
        public const string View = "hospital:Doctors:View";

        [Description("Update")]
        public const string Modify = "hospital:Doctors:Modify";

        [Description("Link")]
        public const string Link = "hospital:Doctors:Link";
        
    }

    [DisplayName("Patients")]
    public class Patients
    {
        [Description("View")]
        public const string View = "hospital:Patients:View";

        [Description("Update")]
        public const string Modify = "hospital:Patients:Modify";

        [Description("Link")]
        public const string Link = "hospital:Patients:Link";

        [Description("Read-Only Button")]
        public const string Readonly = "hospital:Patients:Readonly";

    }
}