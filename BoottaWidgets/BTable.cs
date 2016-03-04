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

		public BTable ()
		{
			this.Build ();
			numberOfRows = 3;
			numberOfColumns=3;
			tableContainer = tblBTableWidgetContainer;
			tableContainer.Resize (numberOfRows, numberOfColumns);
			//Gdk.Color.Parse ("red",ref bgColor);
			this.initTableBasicContent ();
			tableContainer.QueueResize ();
			tableContainer.QueueDraw ();

		}

		public uint NumberOfRows{
			get{ return numberOfRows; }
			set{ 
				numberOfRows = value;
				tableContainer.Resize (numberOfRows,numberOfColumns);
				tableContainer.QueueResize ();
				tableContainer.QueueDraw ();
			}
		}

		public uint NumberOfColumns{
			get{ return numberOfColumns; }
			set{ 
				numberOfColumns = value;
				tableContainer.Resize (numberOfRows,numberOfColumns);
				tableContainer.QueueResize ();
				tableContainer.QueueDraw ();
			}
		}

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



		public void insertElement(Widget w,uint row, uint col){
			((Fixed)tableCells [row,col]).Add (w);
			tableElements [row,col] = w;
		}


		public void insertElementBeta(Widget w,uint row, uint col,Boolean reduceToWidgetSize, Boolean expand, Boolean widgetFillCell){
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
			//eventBoxContainer.ModifyBg (StateType.Normal, bgColor);
			eventBoxContainer.CanFocus = false;

			//eventBoxContainer.Add (w);
			//eventBoxContainer.ModifyBg (StateType.Normal, new Gdk.Color(144,80,132));
			VBox vbcontent = new VBox (false, 0);
			vbcontent.Show ();

			Table tblForExpandedCell = new Table (1, 3, false);
			tblForExpandedCell.RowSpacing = 0;
			tblForExpandedCell.ColumnSpacing = 0;
			tblForExpandedCell.Show ();
			if (expand && !reduceToWidgetSize) {
				eventBoxContainer.Add (tblForExpandedCell);
				EventBox widgetbox = new EventBox ();
				//widgetbox.VisibleWindow = true;
				widgetbox.Show ();

				//widgetbox.ModifyBg (StateType.Normal, new Gdk.Color(144,122,20));
				widgetbox.CanFocus = false;
				widgetbox.Add (w);
				Alignment fixleft = new Alignment(0.5f,0.5f,1,1);
				fixleft.Show ();
				//fixleft.HasWindow = true;
				//fixleft.ModifyBg (StateType.Normal, bgColor);
				Alignment fixright = new Alignment (0.5f,0.5f,1,1);
				//fixright.HasWindow = true;
				//fixright.ModifyBg (StateType.Normal, new Gdk.Color (122,80,180));
				fixright.Show ();
				tblForExpandedCell.Attach (fixleft, 0, 1, 0,1);
				tblForExpandedCell.Attach (widgetbox, 1, 2, 0,1,AttachOptions.Fill,AttachOptions.Fill,0,0);
				tblForExpandedCell.Attach (fixright, 2, 3, 0,1);
				vbcontent.PackStart (eventBoxContainer, true, false, 0);
			} else {
				eventBoxContainer.Add (w);
				vbcontent.PackStart (eventBoxContainer, true, widgetFillCell, 0);
			}
			hbcontent.PackStart (vbcontent, true, widgetFillCell, 0); //widget
					
			/*
			Fixed fixedContainer = new Fixed ();
			tableCells [row, col] = fixedContainer;
			fixedContainer.Show ();
			fixedContainer.BorderWidth = 0;
			fixedContainer.HasWindow = true;
			fixedContainer.ModifyBg(StateType.Normal, new Gdk.Color(200,100,200));
			fixedContainer.CanFocus = false;

			hbcontent.PackStart (fixedContainer, true, true, 0); //widget
			*/
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
				tableContainer.Attach (vbholder, col, col + 1, row, row + 1, ((expand && !reduceToWidgetSize)?AttachOptions.Expand:AttachOptions.Fill), ((expand && !reduceToWidgetSize)?AttachOptions.Expand:AttachOptions.Fill), 0, 0);
			} else {
				tableContainer.Attach (vbholder, col, col + 1, row, row + 1);
			}
			//tableElements [row,col] = null;

			tableBoxes [row, col]=vbholder;

				Gtk.Application.Invoke (delegate {
				

				tableContainer.CheckResize();
			//tableElements [row,col] = w;
			});
		}

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
					//eventBoxContainer.ModifyBg (StateType.Normal, bgColor);
					eventBoxContainer.CanFocus = false;

					//eventBoxContainer.ModifyBg (StateType.Normal, bgColor);


					VBox vbcontent = new VBox (false, 0);
					vbcontent.Show ();

					vbcontent.PackStart (eventBoxContainer, true, false, 0);
					hbcontent.PackStart (vbcontent, true, false, 0); //widget

					/*
					Fixed fixedContainer = new Fixed ();
					tableCells [row, column] = fixedContainer;
					fixedContainer.Show ();
					fixedContainer.BorderWidth = 0;
					fixedContainer.HasWindow = true;
					fixedContainer.ModifyBg(StateType.Normal, new Gdk.Color(200,100,200));
					fixedContainer.CanFocus = false;
				
					hbcontent.PackStart (fixedContainer, true, true, 0); //widget
					*/
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
					//vbholder.ModifyBg (StateType.Normal, bgColor);
					vbholder.Add (vb);

					tableContainer.Attach (vbholder, column, column + 1, row, row + 1, AttachOptions.Fill, AttachOptions.Fill, 0, 0);
					tableElements [row,column] = null;
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
}

