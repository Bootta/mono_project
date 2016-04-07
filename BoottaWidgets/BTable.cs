using System;
using Gtk;
using System.Collections.Generic;

namespace BoottaWidgets
{
	[System.ComponentModel.Category("BoottaWidgets")]
	[System.ComponentModel.ToolboxItem (true)]
	public partial class BTable : Gtk.Bin
	{
		uint numberOfRows=3, numberOfColumns=3;

		Widget [,] tableElements = null;
		Widget [,] tableCells = null;
		EventBox [,] tableBoxes=null;
		Table tableContainer=null;
		bool showTableBorders=true;
		Gdk.Color bgColor=new Gdk.Color(255,255,255);
		List<Separator> borders=new List<Separator>();
		Dictionary<Widget, XYPos> wxy = new Dictionary<Widget, XYPos> ();

		/// <summary>
		/// Initializes a new instance of the <see cref="BoottaWidgets.BTable"/> class.
		/// </summary>
		/// <param name="rows">Rows.</param>
		/// <param name="cols">Cols.</param>
		public BTable (uint rows, uint cols)
		{
			this.Build ();
			numberOfRows = rows;
			numberOfColumns=cols;
			tableContainer = tblBTableWidgetContainer;
			tableContainer.Resize (numberOfRows, numberOfColumns);
			//Gdk.Color.Parse ("red",ref bgColor);
			this.initTableBasicContent ();
			tableContainer.QueueResize ();
			tableContainer.QueueDraw ();

		}

		/// <summary>
		/// Gets or sets the number of rows.
		/// </summary>
		/// <value>The number of rows.</value>
		public uint NumberOfRows{
			get{ return numberOfRows; }
			set{ 
				numberOfRows = value;
				tableContainer.Resize (numberOfRows,numberOfColumns);
				initTableBasicContent ();
				tableContainer.QueueResize ();
				tableContainer.QueueDraw ();
			}
		}

		/// <summary>
		/// Gets or sets the number of columns.
		/// </summary>
		/// <value>The number of columns.</value>
		public uint NumberOfColumns{
			get{ return numberOfColumns; }
			set{ 
				numberOfColumns = value;
				tableContainer.Resize (numberOfRows,numberOfColumns);
				initTableBasicContent ();
				tableContainer.QueueResize ();
				tableContainer.QueueDraw ();
			}
		}

		/// <summary>
		/// Gets or sets the color of the background.
		/// Always run after all elements in table initialized!!!
		/// </summary>
		/// <value>The color of the background.</value>
		public String BackgroundColor{
			get{ return bgColor.ToString();}
			set{ 
				
				Console.WriteLine ("Col {0},{1} value: {2}",numberOfRows,numberOfColumns,value);
				Gdk.Color.Parse (value, ref bgColor); 
				for (int r = 0; r < numberOfRows; r++) {
					
					for (int c = 0; c < numberOfColumns; c++) {
						Console.WriteLine ("color {0},{1}",numberOfRows,numberOfColumns);
						((EventBox)tableBoxes [r,c]).ModifyBg (StateType.Normal, bgColor);
						foreach (object o in getAllElementsOfType(tableBoxes [r,c], typeof(EventBox))) {
							Console.WriteLine ("Colbg: " + o.ToString ());

							((EventBox)o).ModifyBg (StateType.Normal, bgColor);


							//ow.QueueResize ();
							//o.QueueDraw ();

						}

					}
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="BoottaWidgets.BTable"/> show table borders.
		/// </summary>
		/// <value><c>true</c> if show table borders; otherwise, <c>false</c>.</value>
		public bool ShowTableBorders{
			get{ return showTableBorders; }
			set{ showTableBorders = value; 
				foreach (Separator s in borders) {
					s.Visible = showTableBorders;
					Gtk.Application.Invoke (delegate {
						s.Visible = showTableBorders;
					});
				}
			}

		}


		/// <summary>
		/// Inserts the element simple(maybe not working right).
		/// </summary>
		/// <param name="w">The width.</param>
		/// <param name="row">Row.</param>
		/// <param name="col">Col.</param>
		public void insertElementSimple(Widget w,uint row, uint col){
			((EventBox)tableCells [row,col]).Add (w);
			tableElements [row,col] = w;
			wxy.Add (w, new XYPos (col, row));
		}

		/// <summary>
		/// Gets the widget XY position in table.
		/// </summary>
		/// <returns>The widget XY position in table.</returns>
		/// <param name="w">The width.</param>
		public XYPos getWidgetXYPosInTable(Widget w){
			if (wxy.ContainsKey (w)) {
				XYPos ret = new XYPos (0, 0);
				wxy.TryGetValue (w, out ret);
				return ret;
			} else {
				return null;
			}
		}

		/// <summary>
		/// Inserts the element beta version(advanced version).
		/// </summary>
		/// <param name="w">The width.</param>
		/// <param name="row">Row.</param>
		/// <param name="col">Col.</param>
		/// <param name="reduceToWidgetSize">If set to <c>true</c> reduce to widget size.</param>
		/// <param name="expand">If set to <c>true</c> expand.</param>
		/// <param name="widgetFillCell">If set to <c>true</c> widget fill cell.</param>
		/// <param name="padding">Padding.</param>
		public void insertElement(Widget w,uint row, uint col,Boolean reduceToWidgetSize, Boolean expand, Boolean widgetFillCell, uint padding){
			tableBoxes [row, col].Destroy();
			VBox vb = new VBox (false, 0);
			vb.Show ();

			//top border
			HSeparator hsp1 = new HSeparator ();
			hsp1.Visible=showTableBorders?true:false;

			//bottom border
			HSeparator hsp2 = new HSeparator ();
			hsp2.Visible=showTableBorders?true:false;

			borders.Add (hsp1);
			borders.Add (hsp2);

			vb.PackStart (hsp1, false, false, 0); //adding top border

			//content
			HBox hbcontent = new HBox (false, 0);
			hbcontent.Show ();

			VSeparator vsp1 = new VSeparator ();
			vsp1.Visible=showTableBorders?true:false;
			VSeparator vsp2 = new VSeparator ();
			vsp2.Visible=showTableBorders?true:false;
			borders.Add (vsp1);
			borders.Add (vsp2);
			hbcontent.PackStart (vsp1, false, false, 0); // adding left border
			EventBox eventBoxContainer = new EventBox ();
	        tableCells [row,col] = eventBoxContainer;
			eventBoxContainer.Show ();
			eventBoxContainer.BorderWidth = 0;
			eventBoxContainer.CanFocus = false;
			VBox vbcontent = new VBox (false, 0);
			vbcontent.Show ();

			Table tblForExpandedCell = new Table (1, 3, false);
			tblForExpandedCell.RowSpacing = 0;
			tblForExpandedCell.ColumnSpacing = 0;
			tblForExpandedCell.Show ();
			if ((expand) && !reduceToWidgetSize ) {
				eventBoxContainer.Add (tblForExpandedCell);
				EventBox widgetbox = new EventBox ();
				widgetbox.Show ();
				widgetbox.CanFocus = false;
				widgetbox.Add (w);
				Alignment fixleft = new Alignment(0.5f,0.5f,1,1);
				fixleft.Show ();
				Alignment fixright = new Alignment (0.5f,0.5f,1,1);
				fixright.Show ();
				tblForExpandedCell.Attach (fixleft, 0, 1, 0,1);
				tblForExpandedCell.Attach (widgetbox, 1, 2, 0,1,((expand)?AttachOptions.Expand:AttachOptions.Fill),((expand)?AttachOptions.Expand:AttachOptions.Fill),0,0);
				tblForExpandedCell.Attach (fixright, 2, 3, 0,1);
				vbcontent.PackStart (eventBoxContainer, true, false, padding);
			} else {
				eventBoxContainer.Add (w);
				vbcontent.PackStart (eventBoxContainer, true, widgetFillCell, padding);
			}
			hbcontent.PackStart (vbcontent, true, widgetFillCell, padding); //widget
					
			if (col == (numberOfColumns-1)) {
				hbcontent.PackStart (vsp2, false, false, 0); //adding right border
			}
			vb.PackStart (hbcontent, true, true, 0);

			if (row == (numberOfRows-1)) {
				vb.PackStart (hsp2, false, false, 0);
			}
			tableContainer.RowSpacing = 0;
			tableContainer.ColumnSpacing = 0;

			EventBox vbholder = new EventBox ();
			vbholder.Show ();
			vbholder.ModifyBg (StateType.Normal, bgColor);

			vbholder.Add (vb);
			if (reduceToWidgetSize) {
				//tableContainer.Attach (vbholder, col, col + 1, row, row + 1);
				tableContainer.Attach (vbholder, col, col + 1, row, row + 1, AttachOptions.Fill, AttachOptions.Fill, 0, 0);
			} else {
				tableContainer.Attach (vbholder, col, col + 1, row, row + 1);
			}
			tableElements [row,col] = w;
			wxy.Add (w, new XYPos (col, row));


			tableBoxes [row, col]=vbholder;

				Gtk.Application.Invoke (delegate {
				

				tableContainer.CheckResize();
			});



			((EventBox)tableBoxes [row,col]).ModifyBg (StateType.Normal, bgColor);
			foreach (object o in getAllElementsOfType(tableBoxes [row,col], typeof(EventBox))) {
				Console.WriteLine ("Setting background color: " + o.ToString ());

				((EventBox)o).ModifyBg (StateType.Normal, bgColor);

			}
		}

		/// <summary>
		/// Inits the content of the table.
		/// </summary>
		public void initTableBasicContent(){
			
			tableElements=new Widget[numberOfRows,numberOfColumns];

			tableCells=new Widget[numberOfRows,numberOfColumns];

			tableBoxes = new EventBox[numberOfRows, numberOfColumns];
			tableContainer.Homogeneous = false;

			for (uint row = 0; row < numberOfRows; row++) {
				for (uint column = 0; column < numberOfColumns; column++) {
					VBox vb = new VBox (false, 0);
					vb.Show ();


					//top border
					HSeparator hsp1 = new HSeparator ();
					hsp1.Visible=showTableBorders?true:false;
					//bottom border
					HSeparator hsp2 = new HSeparator ();
					hsp2.Visible=showTableBorders?true:false;

					borders.Add (hsp1);
					borders.Add (hsp2);
					vb.PackStart (hsp1, false, false, 0); //adding top border

					//content
					HBox hbcontent = new HBox (false, 0);
					hbcontent.Show ();
					VSeparator vsp1 = new VSeparator ();
					vsp1.Visible=showTableBorders?true:false;
					VSeparator vsp2 = new VSeparator ();
					vsp2.Visible=showTableBorders?true:false;
					borders.Add (vsp1);
					borders.Add (vsp2);
					hbcontent.PackStart (vsp1, false, false, 0); // adding left border
					EventBox eventBoxContainer = new EventBox ();
					tableCells [row,column] = eventBoxContainer;
					eventBoxContainer.Show ();
					eventBoxContainer.BorderWidth = 0;
					eventBoxContainer.CanFocus = false;
					VBox vbcontent = new VBox (false, 0);
					vbcontent.Show ();

					vbcontent.PackStart (eventBoxContainer, true, false, 0);
					hbcontent.PackStart (vbcontent, true, false, 0); //insert widget to cell

					if (column == (numberOfColumns-1)) {
						hbcontent.PackStart (vsp2, false, false, 0); //adding right border
					}

					vb.PackStart (hbcontent, true, true, 0);

					if (row == (numberOfRows-1)) {
						vb.PackStart (hsp2, false, false, 0);
					}

					tableContainer.RowSpacing = 0;
					tableContainer.ColumnSpacing = 0;
					EventBox vbholder = new EventBox ();
					vbholder.Show ();
					vbholder.Add (vb);
					tableContainer.Attach (vbholder, column, column + 1, row, row + 1, AttachOptions.Fill, AttachOptions.Fill, 0, 0);
					tableElements [row,column] = null;

					if (tableBoxes [row, column] != null) {
						tableBoxes [row, column].Destroy ();
					}

					tableBoxes [row, column]=vbholder;

					Gtk.Application.Invoke (delegate {
						
					
						foreach (object o in getAllElementsOfType(tableContainer,null)) {
							Widget ow = (Widget)o;

							ow.QueueResize ();
							ow.QueueDraw ();
						}

					});
				}
			}
		}

		/// <summary>
		/// Gets the type of the all elements of.
		/// </summary>
		/// <returns>All found elements of requested type.</returns>
		/// <param name="widgetholder">Widgetholder(scan all Widgetholder children).</param>
		/// <param name="type">Type.</param>
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
		/// <summary>
		/// Changes the color of the row.
		/// </summary>
		/// <param name="row">Row.</param>
		/// <param name="color">Color.</param>
		public void changeRowColor(uint row, String color){
			Gdk.Color rowcolor = new Gdk.Color ();
			Gdk.Color.Parse (color,ref rowcolor);
			Gtk.Application.Invoke (delegate {
				
			
				for (uint i = 0; i < numberOfColumns; i++) {
					((EventBox)tableBoxes [row,i]).ModifyBg (StateType.Normal, rowcolor);
					foreach (object o in getAllElementsOfType(tableBoxes [row,i], typeof(EventBox))) {
						Console.WriteLine ("Rowbg: " + o.ToString ());

						((EventBox)o).ModifyBg (StateType.Normal, rowcolor);
					}
				}
			});
		}

		/// <summary>
		/// Helper class for storing element(widget) position in table.
		/// </summary>
		public class XYPos{
			private uint x;
			private uint y;
		
					public XYPos(uint x, uint y){
						this.x=x;
						this.y=y;
					}

			public uint getX(){
				return x;
			}

			public uint getY(){
				return y;
			}
		}
	}
}

