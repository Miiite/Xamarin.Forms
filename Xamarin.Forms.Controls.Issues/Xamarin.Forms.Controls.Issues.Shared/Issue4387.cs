using System;
using Xamarin.Forms.CustomAttributes;
using Xamarin.Forms.Internals;
using System.Threading.Tasks;

namespace Xamarin.Forms.Controls.Issues
{
	[Preserve(AllMembers = true)]
	[Issue(IssueTracker.Github, 4387, "Appearing doesn't fire on MacOs when navigating backwards")]
	public class Issue4387 : TestNavigationPage
	{
		MyMainPage page;
		protected override async void Init()
		{
			page = new MyMainPage();
			await Navigation.PushAsync(page);

			var p1 = new TestPage1();
			await this.Navigation.PushAsync(p1);

			this.Navigation.InsertPageBefore(new TestPage2(), p1);

			await this.Navigation.PopAsync();
		}

		public Issue4387()
		{
		}

	}

	class MyMainPage : ContentPage
	{
		//public async void LoadAsync()
		//{
		//	var p1 = new TestPage1();
		//	var p2 = new TestPage2();


		//	this.Navigation.InsertPageBefore(p2, p1);

		//	await this.Navigation.PopAsync();
		//}


	}

	class TestPage1 : ContentPage
	{
		private static bool firstAppearance = true;

		override


		protected override void OnAppearing()
		{
			base.OnAppearing();

			Console.WriteLine("TestPage1 OnAppearing");

			//if (firstAppearance)
			//{
			//	await this.Navigation.PushAsync(new TestPage2());
			//	firstAppearance = false;
			//}
		}

	}

	class TestPage2 : ContentPage
	{
		private static bool firstAppearance = true;

		protected override void OnAppearing()
		{
			base.OnAppearing();

			Console.WriteLine("TestPage2 OnAppearing");

			//if (firstAppearance)
			//{
			//	await this.Navigation.PopAsync();
			//	firstAppearance = false;
			//}
		}
	}
}
