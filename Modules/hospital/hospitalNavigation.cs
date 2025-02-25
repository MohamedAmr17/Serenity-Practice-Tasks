using Serenity.Navigation;

using MyPages = Serene2.hospital.Pages;

[assembly: NavigationMenu(int.MaxValue, "hospital", icon: "fa-hospital")]
[assembly: NavigationLink(int.MaxValue, "hospital/Doctors", typeof(MyPages.DoctorsPage), icon: "fa-stethoscope")]
[assembly: NavigationLink(int.MaxValue, "hospital/Medical Records", typeof(MyPages.MedicalRecordsPage), icon: "fa-notes-medical")]
[assembly: NavigationLink(int.MaxValue, "hospital/Patients", typeof(MyPages.PatientsPage), icon: "fa-user-injured")]
[assembly: NavigationLink(int.MaxValue, "hospital/Speciality",
typeof(MyPages.SpecialityPage), icon: "fa-tools")]

