using System;
using Gtk;
using System.Threading;

namespace TestGtkGui
{
	public class AnimatedButton: EventBox{
		Gdk.Pixbuf imgNormal=null;
		Gdk.Pixbuf imgHover=null;
		Gdk.Pixbuf imgPressed=null;
		Image img=null;
		string lastState="";
		Thread onReleaseThread=null;
		ThreadStart orbStart=null;
		bool pressed=false;
		static Gdk.Color defaultBgColor = new Gdk.Color (255,255,255);

		public static void setButtonsDefaultBgColor(Gdk.Color defbgColor){
			defaultBgColor = defbgColor;
		}

		public AnimatedButton(Gdk.Pixbuf normal, Gdk.Pixbuf hover, Gdk.Pixbuf pressed){
			this.AboveChild=true;
			this.imgNormal=normal;
			this.imgHover=hover;
			this.imgPressed=pressed;
			img=new Image(this.imgNormal);
			img.Show();
			this.Add(img);

			this.EnterNotifyEvent+=new EnterNotifyEventHandler(onEnterWidget);
			this.LeaveNotifyEvent+=new LeaveNotifyEventHandler(onLeaveWidget);
			this.ButtonPressEvent+=new ButtonPressEventHandler(onPressWidget);
			this.ButtonReleaseEvent+=new ButtonReleaseEventHandler(onReleasedWidget);
			this.Show();
			orbStart=new ThreadStart(empty_run);
			onReleaseThread=new Thread(orbStart);
			this.ModifyBg (StateType.Normal, defaultBgColor);
		}

		protected void onEnterWidget(object o, EnterNotifyEventArgs args){
			Console.WriteLine (args.ToString());
			if (!pressed) {
				img.Pixbuf = this.imgHover;
				lastState = "enter";
				Console.WriteLine (args.ToString()+" Done");
			} else {
				Console.WriteLine (args.ToString()+" Not done. Button pressed.");
			}
		}

		protected void onLeaveWidget(object o, LeaveNotifyEventArgs args){
			Console.WriteLine (args.ToString());
			if(!pressed){
				img.Pixbuf = this.imgNormal;
				lastState = "leave";
				Console.WriteLine (args.ToString()+" Done");
			} else {
				Console.WriteLine (args.ToString()+" Not done. Button pressed.");
			}
		}

		protected void onPressWidget(object o, ButtonPressEventArgs args){
			Console.WriteLine (args.ToString());
			img.Pixbuf = this.imgPressed;
			pressed = true;
			lastState = "press";
		}

		protected void onReleasedWidget(object o, ButtonReleaseEventArgs args){
			Console.WriteLine (args);
			img.Pixbuf = this.imgHover;
			onReleaseThread=new Thread(orbStart);
			onReleaseThread.Start ();
			pressed = false;
			lastState = "release";
		}

		static void empty_run(){
			Console.WriteLine ("Empty thread ready method");
		}

		public void setOnReleaseMethod(ThreadStart threadStartUsingMethod){
			orbStart = threadStartUsingMethod;
		}

	}
}

