
// This file has been generated by the GUI designer. Do not modify.
namespace BoottaWidgets
{
	public partial class EntryWithLabel
	{
		private global::Gtk.VBox vbox2;
		
		private global::Gtk.HSeparator hseparator3;
		
		private global::Gtk.Table table3;
		
		private global::Gtk.EventBox eventbox1;
		
		private global::Gtk.Entry entryText;
		
		private global::Gtk.EventBox eventbox2;
		
		private global::Gtk.Image imgAlert;
		
		private global::Gtk.EventBox eventbox3;
		
		private global::Gtk.Label lblMismatchMsg;
		
		private global::Gtk.Label lblEntry;
		
		private global::Gtk.VSeparator vseparator3;
		
		private global::Gtk.VSeparator vseparator4;
		
		private global::Gtk.HSeparator hseparator4;

		protected virtual void Build ()
		{
			global::Stetic.Gui.Initialize (this);
			// Widget BoottaWidgets.EntryWithLabel
			global::Stetic.BinContainer.Attach (this);
			this.Name = "BoottaWidgets.EntryWithLabel";
			// Container child BoottaWidgets.EntryWithLabel.Gtk.Container+ContainerChild
			this.vbox2 = new global::Gtk.VBox ();
			this.vbox2.Name = "vbox2";
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator3 = new global::Gtk.HSeparator ();
			this.hseparator3.Name = "hseparator3";
			this.vbox2.Add (this.hseparator3);
			global::Gtk.Box.BoxChild w1 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator3]));
			w1.Position = 0;
			w1.Expand = false;
			w1.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.table3 = new global::Gtk.Table (((uint)(1)), ((uint)(6)), false);
			this.table3.Name = "table3";
			// Container child table3.Gtk.Table+TableChild
			this.eventbox1 = new global::Gtk.EventBox ();
			this.eventbox1.Name = "eventbox1";
			// Container child eventbox1.Gtk.Container+ContainerChild
			this.entryText = new global::Gtk.Entry ();
			this.entryText.CanFocus = true;
			this.entryText.Name = "entryText";
			this.entryText.IsEditable = true;
			this.entryText.HasFrame = false;
			this.entryText.InvisibleChar = '●';
			this.eventbox1.Add (this.entryText);
			this.table3.Add (this.eventbox1);
			global::Gtk.Table.TableChild w3 = ((global::Gtk.Table.TableChild)(this.table3 [this.eventbox1]));
			w3.LeftAttach = ((uint)(1));
			w3.RightAttach = ((uint)(2));
			w3.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.eventbox2 = new global::Gtk.EventBox ();
			this.eventbox2.Name = "eventbox2";
			// Container child eventbox2.Gtk.Container+ContainerChild
			this.imgAlert = new global::Gtk.Image ();
			this.imgAlert.Name = "imgAlert";
			this.imgAlert.Pixbuf = global::Gdk.Pixbuf.LoadFromResource ("BoottaWidgets.alert20.png");
			this.eventbox2.Add (this.imgAlert);
			this.table3.Add (this.eventbox2);
			global::Gtk.Table.TableChild w5 = ((global::Gtk.Table.TableChild)(this.table3 [this.eventbox2]));
			w5.LeftAttach = ((uint)(3));
			w5.RightAttach = ((uint)(4));
			w5.XOptions = ((global::Gtk.AttachOptions)(4));
			w5.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.eventbox3 = new global::Gtk.EventBox ();
			this.eventbox3.Name = "eventbox3";
			// Container child eventbox3.Gtk.Container+ContainerChild
			this.lblMismatchMsg = new global::Gtk.Label ();
			this.lblMismatchMsg.Name = "lblMismatchMsg";
			this.lblMismatchMsg.LabelProp = global::Mono.Unix.Catalog.GetString ("<span size=\"7000\" background=\"#ffffff\">alert</span>");
			this.lblMismatchMsg.UseMarkup = true;
			this.eventbox3.Add (this.lblMismatchMsg);
			this.table3.Add (this.eventbox3);
			global::Gtk.Table.TableChild w7 = ((global::Gtk.Table.TableChild)(this.table3 [this.eventbox3]));
			w7.LeftAttach = ((uint)(2));
			w7.RightAttach = ((uint)(3));
			w7.XOptions = ((global::Gtk.AttachOptions)(4));
			w7.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.lblEntry = new global::Gtk.Label ();
			this.lblEntry.Name = "lblEntry";
			this.lblEntry.Xpad = 3;
			this.lblEntry.Ypad = 3;
			this.lblEntry.LabelProp = global::Mono.Unix.Catalog.GetString ("lblEntry");
			this.table3.Add (this.lblEntry);
			global::Gtk.Table.TableChild w8 = ((global::Gtk.Table.TableChild)(this.table3 [this.lblEntry]));
			w8.LeftAttach = ((uint)(4));
			w8.RightAttach = ((uint)(5));
			w8.XOptions = ((global::Gtk.AttachOptions)(4));
			w8.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.vseparator3 = new global::Gtk.VSeparator ();
			this.vseparator3.Name = "vseparator3";
			this.table3.Add (this.vseparator3);
			global::Gtk.Table.TableChild w9 = ((global::Gtk.Table.TableChild)(this.table3 [this.vseparator3]));
			w9.LeftAttach = ((uint)(5));
			w9.RightAttach = ((uint)(6));
			w9.XOptions = ((global::Gtk.AttachOptions)(4));
			w9.YOptions = ((global::Gtk.AttachOptions)(4));
			// Container child table3.Gtk.Table+TableChild
			this.vseparator4 = new global::Gtk.VSeparator ();
			this.vseparator4.Name = "vseparator4";
			this.table3.Add (this.vseparator4);
			global::Gtk.Table.TableChild w10 = ((global::Gtk.Table.TableChild)(this.table3 [this.vseparator4]));
			w10.XOptions = ((global::Gtk.AttachOptions)(4));
			w10.YOptions = ((global::Gtk.AttachOptions)(4));
			this.vbox2.Add (this.table3);
			global::Gtk.Box.BoxChild w11 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.table3]));
			w11.Position = 1;
			w11.Expand = false;
			w11.Fill = false;
			// Container child vbox2.Gtk.Box+BoxChild
			this.hseparator4 = new global::Gtk.HSeparator ();
			this.hseparator4.Name = "hseparator4";
			this.vbox2.Add (this.hseparator4);
			global::Gtk.Box.BoxChild w12 = ((global::Gtk.Box.BoxChild)(this.vbox2 [this.hseparator4]));
			w12.Position = 2;
			w12.Expand = false;
			w12.Fill = false;
			this.Add (this.vbox2);
			if ((this.Child != null)) {
				this.Child.ShowAll ();
			}
			this.Hide ();
			this.entryText.Changed += new global::System.EventHandler (this.OnEntryTextChanged);
			this.entryText.FocusOutEvent += new global::Gtk.FocusOutEventHandler (this.OnEntryTextFocusOutEvent);
		}
	}
}