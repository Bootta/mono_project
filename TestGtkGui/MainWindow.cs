using System;
using Gtk;
using TestGtkGui;

public partial class MainWindow: Gtk.Window
{
	String subtitlesFontSize="14000";
	String tempMaskValue="";

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		notebook2.Page = 1;
		//notebook2.GetNthPage (0).Hide (); //hide first page
		//notebook2.GetNthPage (2).Hide (); //hide third page
		//label15.Text = "Hi";
		Gdk.Color col = new Gdk.Color(138, 196, 74);
		//Gdk.Color.Parse("red", ref col);
		this.ModifyBg (StateType.Normal, col);

		lblWgDetails.Markup="<span size='"+subtitlesFontSize+"' color='green' weight='bold'>WG Details</span>";
		lblEinzugsdatum.Markup="<span size='"+subtitlesFontSize+"' color='green' weight='bold'>Einzugsdatum</span>";
		//btnPreferences.CanFocus = false;

		//statusbar1.Push (1, "Ready");
		 
		//statusbar2.PackStart(new Image("run.png"), false, false, 0); 
		//btnForward2.Image = Image.LoadFromResource ("TestGtkGui.wg_detektiv_logo.png");
		AnimatedButton.setButtonsDefaultBgColor(col);

		AnimatedButton btnSchritt1Animated = new AnimatedButton (new Gdk.Pixbuf("images\\schritt1notactive.png"),new Gdk.Pixbuf("images\\schritt2.png"),new Gdk.Pixbuf("images\\schritt2.png"));
		AnimatedButton btnSchritt2Animated = new AnimatedButton (new Gdk.Pixbuf("images\\schritt2normal.png"),new Gdk.Pixbuf("images\\schritt2notactive.png"),new Gdk.Pixbuf("images\\schritt2.png"));
		AnimatedButton btnSchritt3Animated = new AnimatedButton (new Gdk.Pixbuf("images\\schritt3notactive.png"),new Gdk.Pixbuf("images\\schritt2.png"),new Gdk.Pixbuf("images\\schritt2.png"));
		AnimatedButton btnPreferencesAnimated = new AnimatedButton (new Gdk.Pixbuf("images\\preferences_normal.png"),new Gdk.Pixbuf("images\\preferences_hover.png"),new Gdk.Pixbuf("images\\preferences_pressed.png"));

		//btnSchritt2Animated.wid
		hbox25.PackStart (btnSchritt1Animated);
		hbox25.PackEnd (btnSchritt2Animated);
		hbox26.PackStart (btnSchritt3Animated);
		hbox26.PackEnd (btnPreferencesAnimated);

	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}


	protected void OnTxtMinGrosseFocusGrabbed (object sender, EventArgs e)
	{
		hideTxtMask (sender);
	}

	protected void OnTxtMinGrosseFocusOutEvent (object o, FocusOutEventArgs args)
	{
		showTxtMask (o);
	}

	protected void showTxtMask(object o){
		Entry txtField = (Entry)o;
		if (txtField.Text == "") {
			txtField.Text=tempMaskValue;
			txtField.Xalign = 1;
			tempMaskValue = "";
		}

	}

	protected void hideTxtMask(object o){
		Entry txtField = (Entry)o;
		if (txtField.Xalign == 1) {
			tempMaskValue = txtField.Text;
			txtField.Text = "";
			txtField.Xalign = 0;
		}
	}

	protected void OnTxtMaxMieteFocusGrabbed (object sender, EventArgs e)
	{
		hideTxtMask (sender);
	}

	protected void OnTxtMaxMieteFocusOutEvent (object o, FocusOutEventArgs args)
	{
		showTxtMask (o);
	}

	protected void OnToggleCalendarFromActivated (object sender, EventArgs e)
	{
		throw new NotImplementedException ();
	}

	protected void OnToggleCalendarFromToggled (object sender, EventArgs e)
	{
		ToggleButton tglBtn = (ToggleButton)sender;
		if (tglBtn.Active) {
			calFrom.Show ();
		} else {
			calFrom.Hide();
		}
	}

	protected void OnToggleCalendarToToggled (object sender, EventArgs e)
	{
		ToggleButton tglBtn = (ToggleButton)sender;
		if (tglBtn.Active) {
			calTo.Show ();
		} else {
			calTo.Hide();
		}
	}

	protected void OnCalFromDaySelected (object sender, EventArgs e)
	{
		Calendar cal = (Calendar)sender;
		String date = String.Format("{0:d/M/yyyy}",cal.GetDate());
		txtFruhestens.Text = date;
	}

	protected void OnCalFromDaySelectedDoubleClick (object sender, EventArgs e)
	{
		Calendar cal = (Calendar)sender;
		String date = String.Format("{0:d/M/yyyy}",cal.GetDate());
		txtFruhestens.Text = date;
		cal.Hide ();
		toggleCalendarFrom.Active=false;

	}

	protected void OnCalToDaySelected (object sender, EventArgs e)
	{
		Calendar cal = (Calendar)sender;
		String date = String.Format("{0:d/M/yyyy}",cal.GetDate());
		txtSpatestens.Text = date;
	}

	protected void OnCalToDaySelectedDoubleClick (object sender, EventArgs e)
	{
		Calendar cal = (Calendar)sender;
		String date = String.Format("{0:d/M/yyyy}",cal.GetDate());
		txtSpatestens.Text = date;
		cal.Hide ();
		toggleCalendarTo.Active=false;
	}

	protected void OnNotebook2SelectPage (object o, SelectPageArgs args)
	{
		//notebook2.GetNthPage (1);
	}

	protected void OnNotebook2ChangeCurrentPage (object o, ChangeCurrentPageArgs args)
	{
		//notebook2.Page = 1;
	}

	protected void OnBtnForward2Clicked (object sender, EventArgs e)
	{
		notebook2.Page = 0;
	}

	protected void OnNotebook2SwitchPage (object o, SwitchPageArgs args)
	{
		notebook2.Page = 1;
	}
}
