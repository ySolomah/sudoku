using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Collections.Generic;

namespace sukoduSolver
{
	[Activity(Label = "sukoduSolver", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		string[,] inputMatrix = new string[4,4];



		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it

			Button button = FindViewById<Button>(Resource.Id.myButton);

			Intent smsIntent2 = new Intent(Intent.ActionSendto, Android.Net.Uri.Parse("smsto:4169088609"));
			smsIntent2.PutExtra("sms_body", "hello world");
			StartActivity(smsIntent2);

			button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };


			Button clearButton = FindViewById<Button>(Resource.Id.clearButton);
			Button solveButton = FindViewById<Button>(Resource.Id.solveButton);
			Button checkButton = FindViewById<Button>(Resource.Id.checkButton);

			EditText editTextValue00 = FindViewById<EditText>(Resource.Id.sudokuGrid00);
			EditText editTextValue01 = FindViewById<EditText>(Resource.Id.sudokuGrid01);
			EditText editTextValue02 = FindViewById<EditText>(Resource.Id.sudokuGrid02);
			EditText editTextValue03 = FindViewById<EditText>(Resource.Id.sudokuGrid03);

			EditText editTextValue10 = FindViewById<EditText>(Resource.Id.sudokuGrid10);
			EditText editTextValue11 = FindViewById<EditText>(Resource.Id.sudokuGrid11);
			EditText editTextValue12 = FindViewById<EditText>(Resource.Id.sudokuGrid12);
			EditText editTextValue13 = FindViewById<EditText>(Resource.Id.sudokuGrid13);

			EditText editTextValue20 = FindViewById<EditText>(Resource.Id.sudokuGrid20);
			EditText editTextValue21 = FindViewById<EditText>(Resource.Id.sudokuGrid21);
			EditText editTextValue22 = FindViewById<EditText>(Resource.Id.sudokuGrid22);
			EditText editTextValue23 = FindViewById<EditText>(Resource.Id.sudokuGrid23);

			EditText editTextValue30 = FindViewById<EditText>(Resource.Id.sudokuGrid30);
			EditText editTextValue31 = FindViewById<EditText>(Resource.Id.sudokuGrid31);
			EditText editTextValue32 = FindViewById<EditText>(Resource.Id.sudokuGrid32);
			EditText editTextValue33 = FindViewById<EditText>(Resource.Id.sudokuGrid33);

			int clean = 0;
			solveButton.Enabled = false;
			checkButton.Enabled = true;
			clearButton.Enabled = true;

			List<EditText> editText = new List<EditText>();

			editText.Add(editTextValue00);
			editText.Add(editTextValue01);
			editText.Add(editTextValue02);
			editText.Add(editTextValue03);

			editText.Add(editTextValue10);
			editText.Add(editTextValue11);
			editText.Add(editTextValue12);
			editText.Add(editTextValue13);

			editText.Add(editTextValue20);
			editText.Add(editTextValue21);
			editText.Add(editTextValue22);
			editText.Add(editTextValue23);

			editText.Add(editTextValue30);
			editText.Add(editTextValue31);
			editText.Add(editTextValue32);
			editText.Add(editTextValue33);


			clearButton.Click += (object sender, EventArgs e) =>
			{
				var clearDialog = new AlertDialog.Builder(this);
				clearDialog.SetMessage("Are you sure you wish to clear?");
				clearDialog.SetNeutralButton("Clear", delegate
				{
					foreach (EditText obj in editText)
					{
						obj.SetText("", TextView.BufferType.Editable);
					}
					/*
					editTextValue00.SetText("", TextView.BufferType.Editable);
					editTextValue01.SetText("", TextView.BufferType.Editable);
					editTextValue02.SetText("", TextView.BufferType.Editable);
					editTextValue03.SetText("", TextView.BufferType.Editable);

					editTextValue10.SetText("", TextView.BufferType.Editable);
					editTextValue11.SetText("", TextView.BufferType.Editable);
					editTextValue12.SetText("", TextView.BufferType.Editable);
					editTextValue13.SetText("", TextView.BufferType.Editable);

					editTextValue20.SetText("", TextView.BufferType.Editable);
					editTextValue21.SetText("", TextView.BufferType.Editable);
					editTextValue22.SetText("", TextView.BufferType.Editable);
					editTextValue23.SetText("", TextView.BufferType.Editable);

					editTextValue30.SetText("", TextView.BufferType.Editable);
					editTextValue31.SetText("", TextView.BufferType.Editable);
					editTextValue32.SetText("", TextView.BufferType.Editable);
					editTextValue33.SetText("", TextView.BufferType.Editable);
					*/
					Intent smsIntent = new Intent(Intent.ActionSendto, Android.Net.Uri.Parse("smsto:4169088609"));
					smsIntent.PutExtra("sms_body", "hello world");
					StartActivity(smsIntent);
				});
				clearDialog.SetNegativeButton("Cancel", delegate { });

				clearDialog.Show();
			};

			checkButton.Click += (object sender, EventArgs e) =>
			{
				solveButton.Enabled = true;
			};

			solveButton.Click += (object sender, EventArgs e) =>
			{
				for (int i = 0; i < 4; i++)
				{
					for (int j = 0; j < 4; j++)
					{
						inputMatrix[i, j] = editText[4 * i + j].Text;

						//string str = "editTextValue" + i + j;
						//EditText editText = str;
						//inputMatrix[i, j] = editText.Text();
					}
				}
				var solveDialog = new AlertDialog.Builder(this);
				solveDialog.SetMessage("Do you wish to solve what you presented?");
				solveDialog.SetNeutralButton("Solve", delegate
				{
					Intent smsIntent = new Intent(Intent.ActionSendto, Android.Net.Uri.Parse("smsto:4169088609"));
					smsIntent.PutExtra("sms_body", "we shall solve now");
					StartActivity(smsIntent);

					Core.innerSudokuSolver sudokuSolver = new Core.innerSudokuSolver();
					string[,] sudokuSolution = new string[4, 4];
					sudokuSolution = sudokuSolver.sudokuSolver(inputMatrix);

					for (int i = 0; i < 4; i++)
					{
						for (int j = 0; j < 4; j++)
						{
							editText[4 * i + j].SetText(inputMatrix[i, j], TextView.BufferType.Editable);
							//string str = "editTextValue" + i + j;
							//EditText editText = str;
							//editText.SetText(inputMatrix[i, j], TextView.BufferType.Editable);
						}
					}

				});
				solveDialog.SetNegativeButton("Cancel", delegate
				{


				});

				solveDialog.Show();

			};
				                                 


		}
	}
}

