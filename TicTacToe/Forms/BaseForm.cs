using System.Windows.Forms;

namespace TicTacToe.Forms
{
	internal class BaseForm : Form
	{
		const int WS_MINIMIZEBOX = 0x20000;
		const int CS_DBLCLKS = 0x8;

		protected override CreateParams CreateParams
		{// Property for collapsing an open form
			get
			{
				CreateParams cp = base.CreateParams;
				cp.Style |= WS_MINIMIZEBOX;
				cp.ClassStyle |= CS_DBLCLKS;
				return cp;
			}
		}
	}
}
