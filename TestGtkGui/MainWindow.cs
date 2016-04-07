using System;
using Gtk;
using TestGtkGui;
using System.IO;
using System.Collections.Generic;
using BoottaWidgets;

public partial class MainWindow: Gtk.Window
{
	String subtitlesFontSize="14000";
	String subtitlesFontSizeSmall="10000";
	String tempMaskValue="";
	Image [] pageImages=new Image[3];
	char pathSeparator = System.IO.Path.DirectorySeparatorChar;
	int fonts=10;
	AnimatedButton btnPreferencesAnimated,btnFinish;
	List<AnimatedButton> btnsBewerben = new List<AnimatedButton> ();
	BTable tblShritte3=null;
	List<HBox> eigenschaftenSelectedList = new List<HBox> ();
	String fontName="Segoe UI";

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
		String colString = "#8AC44A";
		//Gdk.Color.Parse("red", ref col);
		this.ModifyBg (StateType.Normal, col);

		ebStudium.Hide ();
		ebAusbildung.Hide ();

		lblWgDetails.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>WG Details</span>";
		lblWgDetails.Ypad = 15;
		lblEinzugsdatum.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Einzugsdatum</span>";
		lblEinzugsdatum.Ypad = 15;
		lblAlgemeineDaten.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Allgemeine Daten</span>";
		lblAlgemeineDaten.Ypad = 15;
		lblBeschaftigung.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Beschäftigung</span>";
		lblBeschaftigung.Ypad = 15;
		lblStudium.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Studium</span>";
		lblStudium.Ypad = 15;
		headAusbildung.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Ausbildung</span>";
		headAusbildung.Ypad = 15;
		headfEinzugsdatum.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>frühstes Einzugsdatum</span>";
		headfEinzugsdatum.Ypad = 15;
		headHobbies.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Hobbies</span>";
		headHobbies.Ypad = 15;
		headFreizeit.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Freizeit</span>";
		headFreizeit.Ypad = 15;
		headWarumSuchst.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Warum du eine WG suchst:</span>";
		headWarumSuchst.Ypad = 15;
		headWGErfahrung.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>WG Erfahrung</span>";
		headWGErfahrung.Ypad = 15;
		headEigenschaften.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Eigenschaften</span>";
		headEigenschaften.Ypad = 15;
		headEinkommen.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Einkommen</span>";
		headEinkommen.Ypad = 15;
		headArbeitnehmer.Markup = "<span size='" + subtitlesFontSize + "' color='"+colString+"' weight='bold'>Arbeitnehmer</span>";
		headArbeitnehmer.Ypad = 15;
		lblStudienbeginn.Markup = "<span size='" + subtitlesFontSizeSmall + "' color='"+colString+"' weight='bold'>Studienbeginn</span>";
		lblStudienbeginn.Ypad = 15;
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
		//table23.Resize (10, 7);
		//table23.Homogeneous = false;
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
		tblShritte3 = new BTable (10,7);
		tblShritte3.ShowTableBorders = false;
		tblShritte3.Show ();
		eventbox8.Add (tblShritte3);

		//tblShritte3.NumberOfRows = 10;
		//tblShritte3.NumberOfColumns = 7;
		tblShritte3.ShowTableBorders = true;
		tblShritte3.BackgroundColor = "#ffffff";

		Label lblAuswahl = new Label ("Auswahl");
		Label lblMidbewohner = new Label ("Mitbewohner");
		Label lblZimmergrosse = new Label ("Zimmergröße");
		Label lblStadtteil = new Label ("Stadtteil");
		Label lblFreiab = new Label ("Frei ab");
		Label lblStatus = new Label ("Status");

		lblAuswahl.Show ();
		tblShritte3.insertElement (lblAuswahl, 0, 0, true, true, false,5);
		lblMidbewohner.Show ();
		tblShritte3.insertElement (lblMidbewohner, 0, 1, false, true, false,0);
		lblZimmergrosse.Show ();
		tblShritte3.insertElement (lblZimmergrosse, 0, 2, false, true, false,0);
		lblStadtteil.Show ();
		tblShritte3.insertElement (lblStadtteil, 0, 3, false, true, false,0);
		lblFreiab.Show ();
		tblShritte3.insertElement (lblFreiab, 0, 4, false, true, false,0);
		lblStatus.Show ();
		tblShritte3.insertElement (lblStatus, 0, 5, false, true, false,0);


		for (uint row = 1; row < 10; row++) {
			

			for (uint column = 0; column < 7; column++) {
				

				if (column == 0) {
					CheckButton cbox = new CheckButton ();
					cbox.Toggled += onCheckedRow;
					cbox.Show ();
					tblShritte3.insertElement (cbox, row, column, true, true, false,0);
				}else if(column==6){
					AnimatedButton btnBewerben = new AnimatedButton (new Gdk.Pixbuf ("images" + pathSeparator + "btnBewerben_normal.png"), new Gdk.Pixbuf ("images" + pathSeparator + "btnBewerben_hover.png"), new Gdk.Pixbuf ("images" + pathSeparator + "btnBewerben_pressed.png"));
					btnsBewerben.Add (btnBewerben);
					btnBewerben.setButtonBgColor ("#ffffff");
					tblShritte3.insertElement (btnBewerben, row, column, true, true, false,0);
				}else {
					Label lbl=new Label("Entry");
					lbl.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
					lbl.Show ();
					tblShritte3.insertElement (lbl, row, column, false, true, false,0);
				}
			}

		}

		//fill schritt 3 table

		//Console.WriteLine ("Childs: " + table23.Children.Length);


		//table3.
		//fixed17.ModifyFg(StateType.Normal, new Gdk.Color(245,245,245));
		ebStudium.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebAusbildung.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebEinzugsdatum.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebSports.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebFreizeit.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebEigenschaft.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebFehltEigenscahft.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebWGErfahrung.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		ebArbeitnehmer.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox8.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox7.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox4.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox5.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		eventbox6.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));

		eventbox9.ModifyBg (StateType.Normal, new Gdk.Color (255, 255, 255));
		this.ModifyFont (Pango.FontDescription.FromString (fontName + " 16"));


		//setting radio buttons in defaul state
		radioStudiumNein.Activate();
		radioStudiumNein.Activate ();
		radioAusbuildungNein.Activate ();
		radioWGErfahrungNein.Activate ();
		radioArbeitnehmerNein.Activate ();

	}

	public  void onCheckedRow(object o, EventArgs args){
		Widget w = (Widget)o;
		CheckButton cb = (CheckButton)o;
		Console.WriteLine ("Checked"+tblShritte3.getWidgetXYPosInTable(w).getX()+" "+tblShritte3.getWidgetXYPosInTable(w).getY());
		if (cb.Active) {
			Console.WriteLine ("Active");
			tblShritte3.changeRowColor (tblShritte3.getWidgetXYPosInTable (w).getY (), "#f2ffe3");

			//btnsBewerben [(int)tblShritte3.getWidgetXYPosInTable (w).getY ()].ModifyBg (StateType.Normal, new Gdk.Color (238,238,238));
		} else {
			Console.WriteLine ("Not Active");
			tblShritte3.changeRowColor (tblShritte3.getWidgetXYPosInTable (w).getY (), "#ffffff");
		}
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
		notebook2.NextPage ();
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



	protected void OnBtnBack2Clicked (object sender, EventArgs e)
	{
		notebook2.PrevPage ();
	}



	protected void OnNotebook2ExposeEvent (object o, ExposeEventArgs args)
	{
		int s = (((vbox4.Allocation.Size.Width + vbox4.Allocation.Size.Height) / 2) / 100) ;
		btnFinish.resizeButton (250 + ((s ) * 15),35 + ((s ) * 2)); 
		foreach (AnimatedButton btnBwm in btnsBewerben) {
			btnBwm.resizeButton (70 + ((s ) * 10),30 + ((s ) * 2)); 
		}
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
				ow.ModifyFont (Pango.FontDescription.FromString(fontName + " "+s));
				ow.QueueResize ();
			}

			foreach (object o in getAllElementsOfType(vbox4,typeof(Entry))) {
				Widget ow = (Widget)o;
				ow.ModifyFont (Pango.FontDescription.FromString(fontName + " "+s));
				ow.QueueResize ();
			}

			foreach (object o in getAllElementsOfType(vbox4,typeof(TextView))) {
				Widget ow = (Widget)o;
				ow.ModifyFont (Pango.FontDescription.FromString(fontName + " "+(s+5)));
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

			foreach (AnimatedButton btnBwm in btnsBewerben) {
				btnBwm.resizeButton (80 + ((s ) * 10),40 + ((s ) * 3)); 
			}

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


	protected void OnBtnForward1Clicked (object sender, EventArgs e)
	{
		notebook2.NextPage ();
	}

	protected void OnBtnBack3Clicked (object sender, EventArgs e)
	{
		notebook2.PrevPage ();
	}



	protected void OnRadioStudiumJaClicked (object sender, EventArgs e)
	{
		ebStudium.Show ();
	}

	protected void OnRadioStudiumNeinClicked (object sender, EventArgs e)
	{
		ebStudium.Hide ();
	}

	protected void OnRadioAusbildungJaClicked (object sender, EventArgs e)
	{
		ebAusbildung.Show ();
	}

	protected void OnRadiobutton8Clicked (object sender, EventArgs e)
	{
		ebAusbildung.Hide ();
	}

	protected void OnRadioStudiumNeinGroupChanged (object sender, EventArgs e)
	{
		Console.WriteLine ("changed group");
	}


	protected void OnRadioAusbildungJaToggled (object sender, EventArgs e)
	{
		RadioButton rb = (RadioButton)sender;

		if(rb.Active){
			ebAusbildung.Show();
		}else{
			ebAusbildung.Hide();
		}
	}

	protected void OnRadioStudiumJaToggled (object sender, EventArgs e)
	{
		RadioButton rb = (RadioButton)sender;

		if(rb.Active){
			ebStudium.Show();
		}else{
			ebStudium.Hide();
		}
	}

	protected void OnCalEinzugsdatumDaySelected (object sender, EventArgs e)
	{
		Calendar cal = (Calendar)sender;
		String date = String.Format("{0:d/M/yyyy}",cal.GetDate());
		txtEinzugsdatum.Text = date;

	}

	protected void OnRadioEinzugsdatumDatumToggled (object sender, EventArgs e)
	{
		RadioButton rb = (RadioButton)sender;

		if(rb.Active){
			tblEinzugsdatum.Show();
			hboxEinzugsdatum.Show ();
		}else{
			tblEinzugsdatum.Hide();
			hboxEinzugsdatum.Hide ();
		}
	}

	protected void OnRadioWGErfahrungJaToggled (object sender, EventArgs e)
	{
		RadioButton rb = (RadioButton)sender;

		if(rb.Active){
			ebWGErfahrung.Show();
		}else{
			ebWGErfahrung.Hide();
		}
	}

	protected void OnComboEigenschaftenChanged (object sender, EventArgs e)
	{
		ComboBox cb=(ComboBox)sender;
		Console.WriteLine ("Changed combo "+ cb.ActiveText);
		if (eigenschaftenSelectedList.Count < 3) {
			EventBox eigenshaftHolder = new EventBox ();
			HBox hb = new HBox ();
			hb.Show ();
			hb.PackStart (eigenshaftHolder,false,false,0);
			Button btnx=new Button("X");
			btnx.Show();
			hb.PackStart (btnx,false,false,2);
			eigenshaftHolder.Show ();
			eigenshaftHolder.ModifyBg (StateType.Normal, new Gdk.Color (255,255,255));

			Label eigenshaft = new Label (cb.ActiveText);
			eigenshaftHolder.Add (eigenshaft);
			eigenshaft.ModifyFont (Pango.FontDescription.FromString(fontName + " "+fonts));

			eigenshaft.QueueResize ();
			eigenshaft.Show ();
			tblEigenschaften.Attach (hb, (uint)eigenschaftenSelectedList.Count, (uint)eigenschaftenSelectedList.Count + 1, 0, 1);
			eigenschaftenSelectedList.Add (hb);
			btnx.Clicked+=delegate {
				Console.WriteLine("Label press");
				eigenschaftenSelectedList.Remove(hb);
				hb.Destroy();
			};
		}
	}

	protected void OnRadioArbeitnehmerJaToggled (object sender, EventArgs e)
	{
		RadioButton rb = (RadioButton)sender;

		if(rb.Active){
			ebArbeitnehmer.Show();
		}else{
			ebArbeitnehmer.Hide();
		}
	}
}
