﻿using eRestoran.Client.Mobile.Helpers;
using eRestoran.Client.Mobile.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eRestoran.Client.Mobile.Navigation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MyPageMaster : ContentPage
    {
        public ListView ListView;

        public MyPageMaster()
        {
            InitializeComponent();

            BindingContext = new MyPageMasterViewModel();
            ListView = MenuItemsListView;
        }

        class MyPageMasterViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<MyPageMenuItem> MenuItems { get; set; }
            
            public MyPageMasterViewModel()
            {
                if (ApplicationProperties.userRole != 1)
                {
                    MenuItems = new ObservableCollection<MyPageMenuItem>(new[]
                {
                    new MyPageMenuItem {  Title = "Ponuda",TargetType=typeof(Ponuda) },
                    new MyPageMenuItem { Title = "Rezervacije",TargetType=typeof(RezervisiSto) },
                    new MyPageMenuItem { Title = "Dodavanje naloga",TargetType=typeof(DodavanjeNaloga) },
                    new MyPageMenuItem { Title = "Promocija ",TargetType=typeof(Promocija) },
                    new MyPageMenuItem { Title = "Odjava ",TargetType=typeof(Login)},
                });
                } else
                {
                    MenuItems = new ObservableCollection<MyPageMenuItem>(new[]
                {
                    new MyPageMenuItem {  Title = "Ponuda",TargetType=typeof(Ponuda) },
                    new MyPageMenuItem { Title = "Rezervacije",TargetType=typeof(RezervisiSto) },
                    new MyPageMenuItem { Title = "Odjava ",TargetType=typeof(Login)},
                });
                }
                
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}