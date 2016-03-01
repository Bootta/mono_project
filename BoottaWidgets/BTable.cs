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
				
				Console.WriteLine ("Col {0},{1}",numberOfRows,numberOfColumns);
				Gdk.Color.Parse (value, ref bgColor); 
				for (int r = 0; r < numberOfRows; r++) {
					
					for (int c = 0; c < numberOfColumns; c++) {
						Console.WriteLine ("color {0},{1}",numberOfRows,numberOfColumns);
						((EventBox)tableCells [r,c]).ModifyBg (StateType.Normal, bgColor);
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
			((EventBox)tableCells [row,col]).Add (w);
			tableElements [row,col] = w;
		}

		public void initTableBasicContent(){
			tableElements=new Widget[numberOfRows,numberOfColumns];
			tableCells=new Widget[numberOfRows,numberOfColumns];

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
					eventBoxContainer.ModifyBg (StateType.Normal, bgColor);
					eventBoxContainer.CanFocus = false;

					hbcontent.PackStart (eventBoxContainer, true, true, 0); //widget

					if (column == (numberOfColumns-1)) {
						hbcontent.PackStart (vsp2, false, false, 0); //adding right border
					}
					vb.PackStart (hbcontent, true, true, 0);

					if (row == (numberOfRows-1)) {
						vb.PackStart (hsp2, false, false, 0);
					}
					tableContainer.RowSpacing = 0;
					tableContainer.ColumnSpacing = 0;
					tableContainer.Attach (vb, column, column + 1, row, row + 1);
					tableElements [row,column] = null;
				}
			}
		}


	}
}

