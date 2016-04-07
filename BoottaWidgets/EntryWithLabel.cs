using System;
using System.Text.RegularExpressions;


namespace BoottaWidgets
{
	[System.ComponentModel.Category("BoottaWidgets")]
	[System.ComponentModel.ToolboxItem (true)]
	public partial class EntryWithLabel : Gtk.Bin
	{
		private Regex regex=null;
		private Gdk.Color alertColor=new Gdk.Color(255,180,180);
		private Gdk.Color alertColorDarker=new Gdk.Color(255,77,77);
		private Gdk.Color white=new Gdk.Color(255,255,255);
		private string mismatchMessage="";
		private string lastValidtext="";
		private bool onMissmatchreturnLastValidText=false;
		private string labelText="";

		/// <summary>
		/// Initializes a new instance of the <see cref="BoottaWidgets.EntryWithLabel"/> class.
		/// </summary>
		public EntryWithLabel ()
		{
			this.Build ();
			if(labelText==""){
				
				Gtk.Application.Invoke (delegate {
					eventboxLabel_EntryWithLabel.Visible = false;
					eventboxLabel_EntryWithLabel.ModifyBg(Gtk.StateType.Normal,new Gdk.Color(245,245,245));
				});
			}
		}

		/// <summary>
		/// Gets or sets the entry label.
		/// </summary>
		/// <value>The entrylabel.</value>
		[GLib.Property("label")]
		public string Entrylabel{
			get{ return lblEntry.Text; }
			set{ 
				if (value.Length == 0) {
					Console.WriteLine ("Empty label");
					lblEntry.Text = "";
					labelText = "";
					Gtk.Application.Invoke (delegate {
						eventboxLabel_EntryWithLabel.Visible = false;
					});



				} else {
					Console.WriteLine ("not Empty label");
					labelText = value;
					lblEntry.Text = value;
					Gtk.Application.Invoke (delegate {
						eventboxLabel_EntryWithLabel.Visible = true;
					});
				}
			
			}
		}

		/// <summary>
		/// Gets or sets entry text.
		/// </summary>
		/// <value>The text.</value>
		[GLib.Property("text")]
		public string Text{
			get{ return entryText.Text; }
			set
			{
				if (regex != null) {
					if (regex.IsMatch (value)) {
						entryText.Text = value;
						lastValidtext = value;
					} else {
						entryText.Text = "Error: pattern missmatch";
						lastValidtext = "";
					}
				} else {
					entryText.Text = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the match regex for entry text validation.
		/// </summary>
		/// <value>The match regex.</value>
		[GLib.Property("regex")]
		public string MatchRegex{
			get{ 
				if (regex == null) {
					return "";
				} else {
					return regex.ToString ();
				}
			}
			set{ 
				if (value != "") {
					regex = new Regex (@value); 
				} else {
					regex = null;
				}
			}
		}

		/// <summary>
		/// Gets or sets warning message in case of mismatch regex validation.
		/// </summary>
		/// <value>The mismatch warning message.</value>
		[GLib.Property("MissmatchMessage")]
		public string MismatchWarningMessage{
			get{ return mismatchMessage; }
			set{ 
				Console.WriteLine ("Value: "+value.Length);
				if (value.Length == 0) {
					mismatchMessage = "";
				} else {
					mismatchMessage = value; 

				}
				lblMismatchMsg.Markup = "<span size='small' background='#FF4D4D' color='#ffffff' weight='bold'>" + mismatchMessage + "</span>";
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether disable enter text if mismatch regex validation.
		/// </summary>
		/// <value><c>true</c> if disable enter mismatch text; otherwise, <c>false</c>.</value>
		public bool DisableEnterMismatchText{
			get{ return onMissmatchreturnLastValidText; }
			set{ onMissmatchreturnLastValidText = value; }
		}


		/// <summary>
		/// Color entry the alert color.
		/// </summary>
		public void colorAlert(){
			Console.WriteLine ("Color alert");
			entryText.ModifyBase (Gtk.StateType.Normal, alertColor);
			eventbox1EntryWithLabel.ModifyBg (Gtk.StateType.Normal, alertColor);
			eventbox2EntryWithLabel.ModifyBg (Gtk.StateType.Normal, alertColor);
			eventbox3EntryWithLabel.ModifyBg (Gtk.StateType.Normal, alertColor);

			//imgAlert.ModifyBg (Gtk.StateType.Normal, alertColor);
			//imgAlert.Show ();
			//imgAlert.Show();
			//lblMismatchMsg.Show ();
			eventbox2EntryWithLabel.Visible = true;
			eventbox3EntryWithLabel.Visible = true;
			imgAlert.Visible = true;
			lblMismatchMsg.Visible = true;

		}

		/// <summary>
		/// Color entry in the normal color.
		/// </summary>
		public void colorNormal(){
			Console.WriteLine ("Color normal");
			entryText.ModifyBase (Gtk.StateType.Normal, white);
			eventbox1EntryWithLabel.ModifyBg (Gtk.StateType.Normal, white);
			eventbox2EntryWithLabel.ModifyBg (Gtk.StateType.Normal, white);
			eventbox3EntryWithLabel.ModifyBg (Gtk.StateType.Normal, white);
			imgAlert.ModifyBg (Gtk.StateType.Normal, white);
			//imgAlert.Hide ();
			eventbox2EntryWithLabel.Visible = false;
			eventbox3EntryWithLabel.Visible = false;
			imgAlert.Visible = false;
			lblMismatchMsg.Visible = false;
		}

		protected void OnEntryTextFocusOutEvent (object o, Gtk.FocusOutEventArgs args)
		{
			Console.WriteLine ("Inserted ");
			if (regex != null) {
				Console.WriteLine ("reg not null: "+entryText.Text+ " reg: "+regex.ToString()+" ismatch: "+regex.IsMatch (entryText.Text)+" match: "+regex.Match(entryText.Text).ToString());
				if (regex.Match (entryText.Text).ToString()==entryText.Text) {
					Console.WriteLine ("match");
					if (entryText.Text != lastValidtext) {
						this.colorNormal ();
						lastValidtext = entryText.Text;
					} else {
						lastValidtext = entryText.Text;
					}

				} else {
					Console.WriteLine ("not match");
					this.colorAlert ();
					if(onMissmatchreturnLastValidText){
					entryText.Text = lastValidtext;
					}
					lastValidtext = "";
				}
			}
		}


		protected void OnVbox2Realized (object sender, EventArgs e)
		{
			eventbox2EntryWithLabel.Visible = false;
			eventbox3EntryWithLabel.Visible = false;
			imgAlert.Visible = false;
			lblMismatchMsg.Visible = false;

		}
	}
}

