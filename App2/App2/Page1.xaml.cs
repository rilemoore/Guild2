﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App2.Stuff;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FormsControls.Base;
using Newtonsoft.Json;

namespace App2
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage, IAnimationPage
	{
        static RestService restService;
		public Page1 ()
		{
            
			InitializeComponent ();
            GetEvents();
            this.BackgroundImage = "smallbackground.png";

        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            this.Title.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.Brown;
        }

        public IPageAnimation PageAnimation { get; } = new FadePageAnimation { Duration = AnimationDuration.Short, Subtype = AnimationSubtype.FromTop };

        public void OnAnimationStarted(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }

        public void OnAnimationFinished(bool isPopAnimation)
        {
            // Put your code here but leaving empty works just fine
        }

        List<GameEvent> events = new List<GameEvent>();
        async void GetEvents()
        {
            events = await App.RestService.GetResponse<List<GameEvent>>(Constants.LoginUrl);
            GameEvent gameEvent = new GameEvent();
            gameEvent.EndTime = "falsdkfjlkasd";
            string myPostedEvent = JsonConvert.SerializeObject(gameEvent);
            await App.RestService.PostResponse<string>(Constants.BaseUrl + "/events/new", myPostedEvent);
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Page2());
            Console.WriteLine(events.Count);
            
            //try
            //{   
                //List<GameEvent> result = Task.Run<List<GameEvent>>(async () => await App.RestService.GetResponse<List<GameEvent>>(Constants.LoginUrl)).Result;
            //}
            //catch (Exception exception)
            //{
            //    Console.WriteLine(exception.Message);
            //}
        }
        void Handle_Clicked2(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Page3());
        }
        void Handle_Clicked3(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Page8());
        }
        void Handle_Clicked4(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Page9());
        }

    }
}