namespace Serene2;

public static partial class ESM
{
    public const string CityPage = "~/esm/Modules/Default/City/CityPage.js";
    public const string DocSpecPage = "~/esm/Modules/hospital/DocSpec/DocSpecPage.js";
    public const string DoctorsPage = "~/esm/Modules/hospital/Doctors/DoctorsPage.js";
    public const string GovernatePage = "~/esm/Modules/Default/Governate/GovernatePage.js";
    public const string LanguagePage = "~/esm/Modules/Administration/Language/LanguagePage.js";
    public const string LoginPage = "~/esm/Modules/Membership/Account/Login/LoginPage.js";
    public const string MedicalRecordsPage = "~/esm/Modules/hospital/MedicalRecords/MedicalRecordsPage.js";
    public const string PatientsPage = "~/esm/Modules/hospital/Patients/PatientsPage.js";
    public const string RolePage = "~/esm/Modules/Administration/Role/RolePage.js";
    public const string ScriptInit = "~/esm/Modules/Common/ScriptInit.js";
    public const string SignUpPage = "~/esm/Modules/Membership/Account/SignUp/SignUpPage.js";
    public const string SpecialityPage = "~/esm/Modules/hospital/Speciality/SpecialityPage.js";
    public const string TranslationPage = "~/esm/Modules/Administration/Translation/TranslationPage.js";
    public const string UserPage = "~/esm/Modules/Administration/User/UserPage.js";

    public static partial class Modules
    {
        public static partial class Administration
        {
            public static partial class Language
            {
                public const string LanguagePage = "~/esm/Modules/Administration/Language/LanguagePage.js";
            }

            public static partial class Role
            {
                public const string RolePage = "~/esm/Modules/Administration/Role/RolePage.js";
            }

            public static partial class Translation
            {
                public const string TranslationPage = "~/esm/Modules/Administration/Translation/TranslationPage.js";
            }

            public static partial class User
            {
                public const string UserPage = "~/esm/Modules/Administration/User/UserPage.js";
            }
        }

        public static partial class Common
        {
            public const string ScriptInit = "~/esm/Modules/Common/ScriptInit.js";
        }

        public static partial class Default
        {
            public static partial class City
            {
                public const string CityPage = "~/esm/Modules/Default/City/CityPage.js";
            }

            public static partial class Governate
            {
                public const string GovernatePage = "~/esm/Modules/Default/Governate/GovernatePage.js";
            }
        }

        public static partial class hospital
        {
            public static partial class DocSpec
            {
                public const string DocSpecPage = "~/esm/Modules/hospital/DocSpec/DocSpecPage.js";
            }

            public static partial class Doctors
            {
                public const string DoctorsPage = "~/esm/Modules/hospital/Doctors/DoctorsPage.js";
            }

            public static partial class MedicalRecords
            {
                public const string MedicalRecordsPage = "~/esm/Modules/hospital/MedicalRecords/MedicalRecordsPage.js";
            }

            public static partial class Patients
            {
                public const string PatientsPage = "~/esm/Modules/hospital/Patients/PatientsPage.js";
            }

            public static partial class Speciality
            {
                public const string SpecialityPage = "~/esm/Modules/hospital/Speciality/SpecialityPage.js";
            }
        }

        public static partial class Membership
        {
            public static partial class Account
            {
                public static partial class Login
                {
                    public const string LoginPage = "~/esm/Modules/Membership/Account/Login/LoginPage.js";
                }

                public static partial class SignUp
                {
                    public const string SignUpPage = "~/esm/Modules/Membership/Account/SignUp/SignUpPage.js";
                }
            }
        }
    }
}