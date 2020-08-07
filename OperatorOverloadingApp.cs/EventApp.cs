using System;
using System.Windows.Forms;

class EventApp : Form
{
    public EventApp()
    {
        this.Click += new EventHandler(ClickEvent); //이벤트 처리기 등록
    }

    void ClickEvent(object sender, EventArgs e)
    {
        MessageBox.Show("Hello world");
    }
	public static void Main()
	{
        ApplicationException.Run(new EventApp());
	}
}
