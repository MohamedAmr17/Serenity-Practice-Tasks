using Serenity.Navigation;
using MyPages = Serene2.Default.Pages;

[assembly: NavigationLink(int.MaxValue, "Address/City", typeof(MyPages.CityPage), icon: null)]
[assembly: NavigationLink(int.MaxValue, "Address/Governate", typeof(MyPages.GovernatePage), icon: null)]
