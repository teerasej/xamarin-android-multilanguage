using Android.App;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Util;

namespace multilanguage
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            var buttonSwitchLanguage = FindViewById<Button>(Resource.Id.buttonSwitchLanguage);
            var textHello = FindViewById<TextView>(Resource.Id.textHello);

            buttonSwitchLanguage.Click += (sender, e) =>
            {
                var languageCode = "th";

                Configuration overrideConfiguration = this.Resources.Configuration;
                Locale locale = new Locale(languageCode);
                overrideConfiguration.SetLocale(locale);

                var context = CreateConfigurationContext(overrideConfiguration);
                var stringHello = context.GetString(Resource.String.hello);
                textHello.Text = stringHello;
            };

        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}