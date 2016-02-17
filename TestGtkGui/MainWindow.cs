using System;
using Gtk;
using TestGtkGui;

public partial class MainWindow: Gtk.Window
{
	String subtitlesFontSize="14000";
	String tempMaskValue="";
	Image [] pageImages=new Image[3];

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		//fixed13.ModifyBg (StateType.Normal, new Gdk.Color (255,255,255));
		Build ();
		pageImages [0] = imgSchritt1;
		pageImages [1] = imgSchritt2;
		pageImages [2] = imgSchritt3;
		notebook2.Page = 1;
		//notebook2.GetNthPage (0).Hide (); //hide first page
		//notebook2.GetNthPage (2).Hide (); //hide third page
		//label15.Text = "Hi";
		Gdk.Color col = new Gdk.Color(138, 196, 74);
		//Gdk.Color.Parse("red", ref col);
		this.ModifyBg (StateType.Normal, col);

		lblWgDetails.Markup="<span size='"+subtitlesFontSize+"' color='green' weight='bold'>WG Details</span>";
		lblEinzugsdatum.Markup="<span size='"+subtitlesFontSize+"' color='green' weight='bold'>Einzugsdatum</span>";
		lblAlgemeineDaten.Markup="<span size='"+subtitlesFontSize+"' color='green' weight='bold'>Algemeine Daten</span>";
		lblBeschaftigung.Markup="<span size='"+subtitlesFontSize+"' color='green' weight='bold'>Beschäftigung</span>";
		//btnPreferences.CanFocus = false;

		//statusbar1.Push (1, "Ready");
		/* 
		//add programaticly shirtt page buttons

		AnimatedButton btnSchritt1Animated = new AnimatedButton (new Gdk.Pixbuf("images\\schritt1notactive.png"),new Gdk.Pixbuf("images\\schritt2.png"),new Gdk.Pixbuf("images\\schritt2.png"));
		AnimatedButton btnSchritt2Animated = new AnimatedButton (new Gdk.Pixbuf("images\\schritt2normal.png"),new Gdk.Pixbuf("images\\schritt2notactive.png"),new Gdk.Pixbuf("images\\schritt2.png"));
		AnimatedButton btnSchritt3Animated = new AnimatedButton (new Gdk.Pixbuf("images\\schritt3notactive.png"),new Gdk.Pixbuf("images\\schritt2.png"),new Gdk.Pixbuf("images\\schritt2.png"));

		hbox25.PackStart (btnSchritt1Animated);
		hbox25.PackEnd (btnSchritt2Animated);
		hbox26.PackStart (btnSchritt3Animated);

		*/
		AnimatedButton.setButtonsDefaultBgColor(col);
		AnimatedButton btnPreferencesAnimated = new AnimatedButton (new Gdk.Pixbuf("images\\preferences_normal.png"),new Gdk.Pixbuf("images\\preferences_hover.png"),new Gdk.Pixbuf("images\\preferences_pressed.png"));
		hbox26.PackEnd (btnPreferencesAnimated);


		AnimatedButton btnFinish = new AnimatedButton (new Gdk.Pixbuf("images\\finish_button_normal.png"),new Gdk.Pixbuf("images\\finish_button_hover.png"),new Gdk.Pixbuf("images\\finish_button_pressed.png"));
		btnFinish.setXAlign (1);
		btnFinish.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		hbox31.PackEnd (btnFinish);
		/*
		imgSchritt1.Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt1notactive.png");
		btnFinish.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		table3.Resize(20,9);
		Entry [] entries=new Entry[100];
		for (int i = 0; i < 100; i++) {
			entries [i] = new Entry ();
			entries [i].Show ();
			entries [i].Text = "Entry " + i;
			table3.Add (entries [i]);
			//table3.Attach (entries [i], (i % 7), 0, (i / 7), 0);
		}
		*/
		//fill schritt 3 table

		//table3.
	
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
		notebook2.Page = 2;
	}

	protected void OnNotebook2SwitchPage (object o, SwitchPageArgs args)
	{
		Console.WriteLine ("switch"+args.PageNum);
		for (int i = 0; i < notebook2.NPages; i++) {
			if (i == args.PageNum) {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"normal.png");
			} else {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"notactive.png");
			}
		}
	}

	protected void OnButton1Clicked (object sender, EventArgs e)
	{
		notebook2.Page = 1;
	}

	protected void OnBtnBack2Clicked (object sender, EventArgs e)
	{
		notebook2.Page = 0;
	}

	protected void OnButton3Clicked (object sender, EventArgs e)
	{
		notebook2.PrevPage ();
	}
}
