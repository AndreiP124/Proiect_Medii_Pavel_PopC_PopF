using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using proiect1.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace proiect1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListPage : ContentPage
    {
        public ListPage()
        {
            InitializeComponent();
        }
        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var slist = (ReservationList)BindingContext;
            slist.Date = DateTime.UtcNow;
            await App.Database.SaveReservationListAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var slist = (ReservationList)BindingContext;
            await App.Database.DeleteReservationListAsync(slist);
            await Navigation.PopAsync();
        }
        async void OnChooseButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ProductPage((ReservationList) this.BindingContext)
            {
                BindingContext = new Product()
            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var shopl = (ReservationList)BindingContext;

            listView.ItemsSource = await App.Database.GetListProductsAsync(shopl.ID);
        }
    }
}