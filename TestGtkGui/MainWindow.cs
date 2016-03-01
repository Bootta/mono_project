using System;
using Gtk;
using TestGtkGui;
using System.IO;
using System.Collections.Generic;

public partial class MainWindow: Gtk.Window
{
	String subtitlesFontSize="14000";
	String tempMaskValue="";
	Image [] pageImages=new Image[3];
	char pathSeparator = System.IO.Path.DirectorySeparatorChar;
	int fonts=10;
	AnimatedButton btnPreferencesAnimated,btnFinish;


	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		
		//fixed13.ModifyBg (StateType.Normal, new Gdk.Color (255,255,255));
		this.Build ();

		pageImages [0] = imgSchritt1;
		pageImages [1] = imgSchritt2;
		pageImages [2] = imgSchritt3;
		//notebook1age = 0;
		//notebook2.GetNthPage (0).Hide (); //hide first page
		//notebook2.GetNthPage (2).Hide (); //hide third page
		//label15.Text = "Hi";
		Gdk.Color col = new Gdk.Color (138, 196, 74);
		//Gdk.Color.Parse("red", ref col);
		this.ModifyBg (StateType.Normal, col);

		lblWgDetails.Markup = "<span size='" + subtitlesFontSize + "' color='green' weight='bold'>WG Details</span>";
		lblWgDetails.Ypad = 15;
		lblEinzugsdatum.Markup = "<span size='" + subtitlesFontSize + "' color='green' weight='bold'>Einzugsdatum</span>";
		lblEinzugsdatum.Ypad = 15;
		lblAlgemeineDaten.Markup = "<span size='" + subtitlesFontSize + "' color='green' weight='bold'>Algemeine Daten</span>";
		lblAlgemeineDaten.Ypad = 15;
		lblBeschaftigung.Markup = "<span size='" + subtitlesFontSize + "' color='green' weight='bold'>Beschäftigung</span>";
		lblBeschaftigung.Ypad = 15;
		//btnPreferences.CanFocus = false;

		//statusbar1.Push (1, "Ready");
		/* 
		//add programaticly shirtt page buttons

		AnimatedButton btnSchritt1Animated = new AnimatedButton (new Gdk.Pixbuf("images/schritt1notactive.png"),new Gdk.Pixbuf("images/schritt2.png"),new Gdk.Pixbuf("images/schritt2.png"));
		AnimatedButton btnSchritt2Animated = new AnimatedButton (new Gdk.Pixbuf("images/schritt2normal.png"),new Gdk.Pixbuf("images/schritt2notactive.png"),new Gdk.Pixbuf("images/schritt2.png"));
		AnimatedButton btnSchritt3Animated = new AnimatedButton (new Gdk.Pixbuf("images/schritt3notactive.png"),new Gdk.Pixbuf("images/schritt2.png"),new Gdk.Pixbuf("images/schritt2.png"));

		hbox25.PackStart (btnSchritt1Animated);
		hbox25.PackEnd (btnSchritt2Animated);
		hbox26.PackStart (btnSchritt3Animated);

		*/


		AnimatedButton.setButtonsDefaultBgColor (col);
		btnPreferencesAnimated = new AnimatedButton (new Gdk.Pixbuf ("images" + pathSeparator + "preferences_normal.png"), new Gdk.Pixbuf ("images" + pathSeparator + "preferences_hover.png"), new Gdk.Pixbuf ("images" + pathSeparator + "preferences_pressed.png"));
		btnPreferencesAnimated.setXAlign (0.5f);
	
		hbox26.PackEnd (btnPreferencesAnimated, false, false, 5);



	    btnFinish = new AnimatedButton (new Gdk.Pixbuf ("images" + pathSeparator + "finish_button_normal_big.png"), new Gdk.Pixbuf ("images" + pathSeparator + "finish_button_hover_big.png"), new Gdk.Pixbuf ("images" + pathSeparator + "finish_button_pressed_big.png"));
		btnFinish.setXAlign (1);
		btnFinish.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		hbox31.PackEnd (btnFinish, false, false, 0);

		imgSchritt1.Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt1notactive.png");
		btnFinish.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		table23.Resize (10, 9);
		Label[] entries = new Label[100];
		int count = 0;
		/*
		for (uint i = 0; i < 70; i++) {
			entries [i] = new Label ();
			entries [i].Show ();
			entries [i].Text = "Entry " + i;
			//table3.Add (entries [i]);

			Console.WriteLine(((i%7)+1) + " " +((i%7)+2) +" "+ ((i / 7)+1)+ " "+ ((i / 7)+2));
			table3.Attach(entries [i], (i%7)+1, (i%7)+2, (i / 7)+1, (i / 7)+2);

			//table3.att
		}
		*/

		for (uint row = 1; row < 10; row++) {
			

			for (uint column = 0; column < 7; column++) {

				VBox vb = new VBox (false, 0);
				vb.Show ();

				//top border
				HSeparator hsp1 = new HSeparator ();

				hsp1.Show ();
				HSeparator hsp2 = new HSeparator ();
				hsp2.Show ();
				vb.PackStart (hsp1, false, false, 0);


				//content
				HBox hbcontent = new HBox (false, 0);

				hbcontent.Show ();
				VSeparator vsp1 = new VSeparator ();
				vsp1.Show ();
				VSeparator vsp2 = new VSeparator ();
				vsp2.Show ();
				hbcontent.PackStart (vsp1, false, false, 0); //left border
				if (column == 0) {
					CheckButton cbox = new CheckButton ();
					cbox.Show ();
					cbox.Xalign = 1;

					cbox.ModifyBg (StateType.Normal, new Gdk.Color (77, 77, 77));
					cbox.CanFocus = false;
					hbcontent.PackStart (cbox, true, true, 5); //widget
				} else if (column == 6) {
					Button button = new Button ("Bewerben");
					button.Show ();
					button.CanFocus = false;
					hbcontent.PackStart (button, true, true, 5); //widget
				} else {
					entries [count] = new Label ();
					entries [count].Show ();
					entries [count].Text = "Entry " + count;
					entries [count].Xpad = 15;
					entries [count].Ypad = 4;
					hbcontent.PackStart (entries [count], true, true, 5); //widget
				}


				if (column == 6) {
					hbcontent.PackStart (vsp2, false, false, 0); //right border
				}
				vb.PackStart (hbcontent, true, true, 0);

				if (row == 9) {
					vb.PackStart (hsp2, false, false, 0);
				}
				table23.RowSpacing = 0;
				table23.ColumnSpacing = 0;
				table23.Attach (vb, column, column + 1, row, row + 1);
				count++;
			}

		}

		//fill schritt 3 table

		Console.WriteLine ("Childs: " + table23.Children.Length);


		//table3.
		//fixed17.ModifyFg(StateType.Normal, new Gdk.Color(245,245,245));
		eventbox8.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox7.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox4.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox5.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox6.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));

		eventbox9.ModifyBg (StateType.Normal, new Gdk.Color (245, 245, 245));
		this.ModifyFont (Pango.FontDescription.FromString ("Courier 16"));
		//entry2.ModifyFont(Pango.FontDescription.FromString("Courier 16"));
		//Console.WriteLine ("Object length: " + combobox6.Cells.Length);
		Button bttest=new Button("Test");
		bttest.Show ();
		btable1.insertElement (bttest, 1, 1);

		//textview1.font
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
			if (i == notebook2.Page) {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"normal_big.png").ScaleSimple(178 + ((fonts ) * 7),25 + ((fonts ) * 1),Gdk.InterpType.Bilinear);
			} else {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"notactive_big.png").ScaleSimple(178 + ((fonts ) * 7),25 + ((fonts ) * 1),Gdk.InterpType.Bilinear);
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

	protected void OnNotebook2ExposeEvent (object o, ExposeEventArgs args)
	{
		for (int i = 0; i < notebook2.NPages; i++) {
			if (i == notebook2.Page) {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"normal_big.png").ScaleSimple(178 + ((fonts ) * 7),25 + ((fonts ) * 1),Gdk.InterpType.Bilinear);
			} else {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"notactive_big.png").ScaleSimple(178 + ((fonts ) * 7),25 + ((fonts ) * 1),Gdk.InterpType.Bilinear);
			}
		}
	}

	protected void ResizeCheckedEvent (object sender, EventArgs e)
	{
		Console.WriteLine ("-f8: " + e.ToString());

		foreach(object o in getAllElementsOfType (vbox4,null)){
			Widget ow = (Widget)o;

			//Console.WriteLine ("Widget name: " + ow.Name + " type: " + ow.GetType ());
			//ow.QueueResize ();
		}

		Console.WriteLine ("size: " + vbox1.Allocation.Size.Width + " x " + vbox1.Allocation.Size.Height);
		int s = (((vbox4.Allocation.Size.Width + vbox4.Allocation.Size.Height) / 2) / 100) ;
		//int s=13;
		Console.WriteLine ("SSS: " + s);
		if (fonts != s && s>7) {

			foreach (object o in getAllElementsOfType(vbox4,typeof(Label))) {
				Widget ow = (Widget)o;
				ow.ModifyFont (Pango.FontDescription.FromString("Arial "+s));
				ow.QueueResize ();
			}

			foreach (object o in getAllElementsOfType(vbox4,typeof(Entry))) {
				Widget ow = (Widget)o;
				ow.ModifyFont (Pango.FontDescription.FromString("Arial "+s));
				ow.QueueResize ();
			}

			foreach (object o in getAllElementsOfType(vbox4,typeof(TextView))) {
				Widget ow = (Widget)o;
				ow.ModifyFont (Pango.FontDescription.FromString("Arial "+(s+5)));
				ow.QueueResize ();
			}

			foreach (object o in getAllElementsOfType(vbox4,typeof(ComboBox))) {
				ComboBox ow = (ComboBox)o;
				//Console.WriteLine ("Combo box: "+ow.Name);

				foreach (CellRenderer obj in ow.Cells) {
					CellRendererText crt = (CellRendererText)obj;
					//Console.WriteLine ("Objectcbox: " + crt.Text);
					crt.Font="Arial "+s;

				}
				//ow.Popup();
				//ow.Popdown();
				ow.QueueResize();

			}

			foreach (object o in getAllElementsOfType(vbox4,null)) {
				Widget ow = (Widget)o;

				ow.QueueResize ();
			}

			btnForward1.WidthRequest = 40 + ((s ) * 2);
			btnForward1.HeightRequest = 40 + ((s ) * 2);
			btnBack2.WidthRequest = 40 + ((s ) * 2);
			btnBack2.HeightRequest = 40 + ((s ) * 2);
			btnForward2.WidthRequest = 40 + ((s ) * 2);
			btnForward2.HeightRequest = 40 + ((s ) * 2);
			btnBack3.WidthRequest = 40 + ((s ) * 2);
			btnBack3.HeightRequest = 40 + ((s ) * 2);
			btnFinish.resizeButton (250 + ((s ) * 15),35 + ((s ) * 2)); 

			for (int i = 0; i < notebook2.NPages; i++) {
				if (i == notebook2.Page) {
					pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"normal_big.png").ScaleSimple(178 + ((s ) * 7),25 + ((s ) * 1),Gdk.InterpType.Bilinear);
				} else {
					pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"notactive_big.png").ScaleSimple(178 + ((s ) * 7),25 + ((s ) * 1),Gdk.InterpType.Bilinear);
				}
			}

			fonts = s;
		}
	}

	public object[] getAllElementsOfType(Container widgetholder, Type type){
		//widgetholder.GetType ().IsSubclassOf (Container);
		List<object> ret=new List<object>();
		foreach (Widget w in widgetholder.Children) {
			//Console.WriteLine (w.Name+" is type of "+w.GetType()+" and is subclass of container= "+w.GetType().IsSubclassOf(typeof(Container)));
			if (type == null) {
				ret.Add (w);
			} else {
				//Console.WriteLine ("w type " + w.GetType () + " typecomp: " + type);
				if ( w.GetType ().Equals(type)) {
					ret.Add (w);
				} 
			}
			if (w.GetType ().IsSubclassOf (typeof(Container))) {
				ret.AddRange( getAllElementsOfType ((Container)w,type));
			}
		}


		return ret.ToArray();
	}

}
