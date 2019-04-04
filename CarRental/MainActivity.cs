using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace CarRental
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        EditText vrent, vdays, vamount, vtotal;
        RadioButton rd20, rd2160, rd60, rdgps, rdchair, rdmileage;
        Button btcalculate, btclear;
        double result1, result2, total;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            vrent = (EditText)FindViewById(Resource.Id.edtrent);
            vdays = (EditText)FindViewById(Resource.Id.edtdays);
            vamount = (EditText)FindViewById(Resource.Id.edtamount);
            vtotal = (EditText)FindViewById(Resource.Id.edttotal);
            rd20 = (RadioButton)FindViewById(Resource.Id.rdb20);
            rd2160 = (RadioButton)FindViewById(Resource.Id.rdb2160);
            rd60 = (RadioButton)FindViewById(Resource.Id.rdb60);
            rdgps = (RadioButton)FindViewById(Resource.Id.rdbgps);
            rdchair = (RadioButton)FindViewById(Resource.Id.rdbchair);
            rdmileage = (RadioButton)FindViewById(Resource.Id.rdbmileage);
            btcalculate = (Button)FindViewById(Resource.Id.btncalculate);
            btclear = (Button)FindViewById(Resource.Id.btnclear);


            btcalculate.Click += delegate
      {
          double rent = double.Parse(vrent.Text);
          double days = double.Parse(vdays.Text);
          if (rd20.Checked)
          {
              result1 = (rent * days) + 5;
          }
          else if (rd2160.Checked)
          {
              result1 = (rent * days);
          }
          else if (rd60.Checked)
          {
              result1 = (rent * days);
          }
          else
          {
              Toast.MakeText(this, "Please select the age", ToastLength.Long).Show();
          }
          if (rdgps.Checked)
          {
              result2 = result1 + 5;
              total = result2 * 1.13;
          }
          else if (rdchair.Checked)
          {
              result2 = result1 + 7;
              total = result2 * 1.13;
          }
          else if (rdmileage.Checked)
          {
              result2 = result1 + 10;
              total = result2 * 1.13;
          }
          else
          {
              Toast.MakeText(this, "Please enter the input", ToastLength.Long).Show();
          }
          vamount.Text = result2.ToString();
          vtotal.Text = total.ToString();
      };
            btclear.Click += delegate
            {
                vamount.Text = "";
                vtotal.Text = "";
                vrent.Text = "";
                vdays.Text = "";


            };

            }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

