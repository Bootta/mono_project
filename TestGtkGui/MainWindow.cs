using System;
using Gtk;
using TestGtkGui;
using System.IO;


public partial class MainWindow: Gtk.Window
{
	String subtitlesFontSize="14000";
	String tempMaskValue="";
	Image [] pageImages=new Image[3];
	char pathSeparator = System.IO.Path.DirectorySeparatorChar;

	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		
		//fixed13.ModifyBg (StateType.Normal, new Gdk.Color (255,255,255));
		Build ();

		pageImages [0] = imgSchritt1;
		pageImages [1] = imgSchritt2;
		pageImages [2] = imgSchritt3;
		//notebook1age = 0;
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

		AnimatedButton btnSchritt1Animated = new AnimatedButton (new Gdk.Pixbuf("images/schritt1notactive.png"),new Gdk.Pixbuf("images/schritt2.png"),new Gdk.Pixbuf("images/schritt2.png"));
		AnimatedButton btnSchritt2Animated = new AnimatedButton (new Gdk.Pixbuf("images/schritt2normal.png"),new Gdk.Pixbuf("images/schritt2notactive.png"),new Gdk.Pixbuf("images/schritt2.png"));
		AnimatedButton btnSchritt3Animated = new AnimatedButton (new Gdk.Pixbuf("images/schritt3notactive.png"),new Gdk.Pixbuf("images/schritt2.png"),new Gdk.Pixbuf("images/schritt2.png"));

		hbox25.PackStart (btnSchritt1Animated);
		hbox25.PackEnd (btnSchritt2Animated);
		hbox26.PackStart (btnSchritt3Animated);

		*/


		AnimatedButton.setButtonsDefaultBgColor(col);
		AnimatedButton btnPreferencesAnimated = new AnimatedButton (new Gdk.Pixbuf("images"+pathSeparator+"preferences_normal.png"),new Gdk.Pixbuf("images"+pathSeparator+"preferences_hover.png"),new Gdk.Pixbuf("images"+pathSeparator+"preferences_pressed.png"));
		btnPreferencesAnimated.setXAlign (0.5f);
		hbox26.PackEnd (btnPreferencesAnimated);



		AnimatedButton btnFinish = new AnimatedButton (new Gdk.Pixbuf("images"+pathSeparator+"finish_button_normal.png"),new Gdk.Pixbuf("images"+pathSeparator+"finish_button_hover.png"),new Gdk.Pixbuf("images"+pathSeparator+"finish_button_pressed.png"));
		btnFinish.setXAlign (1);
		btnFinish.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		hbox31.PackEnd (btnFinish,false,false,0);

		imgSchritt1.Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt1notactive.png");
		btnFinish.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		table4.Resize(10,9);
		Label [] entries=new Label[100];
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
			

			for(uint column=0;column<7;column++){

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
				hbcontent.PackStart(vsp1,false,false,0); //left border
				if (column == 0) {
					CheckButton cbox = new CheckButton ();
					cbox.Show ();
					hbcontent.PackStart(cbox,true,true,5); //widget
				}else if (column == 6) {
					Button cbox = new Button ("Bewerben");
					cbox.Show ();
					hbcontent.PackStart(cbox,true,true,5); //widget
				} else {
					entries [count] = new Label ();
					entries [count].Show ();
					entries [count].Text = "Entry " + count;
					entries [count].Xpad = 15;
					entries [count].Ypad = 4;
					hbcontent.PackStart(entries[count],true,true,5); //widget
				}


				if (column == 6) {
					hbcontent.PackStart (vsp2, false, false, 0); //right border
				}
				vb.PackStart(hbcontent,true,true,0);

				if (row == 9) {
					vb.PackStart (hsp2, false, false, 0);
				}
				table4.RowSpacing = 0;
				table4.ColumnSpacing = 0;
				table4.Attach(vb, column, column+1, row, row+1);
				count++;
			}

		}

		//fill schritt 3 table

		Console.WriteLine("Childs: "+table4.Children.Length);


		//table3.
		//fixed17.ModifyFg(StateType.Normal, new Gdk.Color(245,245,245));
		eventbox9.ModifyBg(StateType.Normal,new Gdk.Color(255,255,255));
		eventbox9.ModifyBg(StateType.Normal,new Gdk.Color(255,255,255));
		eventbox4.ModifyBg(StateType.Normal,new Gdk.Color(255,255,255));
		eventbox5.ModifyBg(StateType.Normal,new Gdk.Color(255,255,255));
		eventbox6.ModifyBg(StateType.Normal,new Gdk.Color(255,255,255));
		eventbox9.ModifyBg(StateType.Normal,new Gdk.Color(245,245,245));
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

	protected void OnNotebook2ExposeEvent (object o, ExposeEventArgs args)
	{
		for (int i = 0; i < notebook2.NPages; i++) {
			if (i == notebook2.Page) {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"normal.png");
			} else {
				pageImages[i].Pixbuf = new Gdk.Pixbuf (null, "TestGtkGui.bin.Debug.images.Schritt"+(i+1)+"notactive.png");
			}
		}
	}
}
