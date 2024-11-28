using System;
using System.Windows.Forms;

namespace TicTacToe.Models.Utilities.FormUtilities
{
	internal class LabelNoCopy : Label
	{// Label that is not copied after double clicking
		private string text;

		public override string Text
		{
			get
			{ return text; }
			set
			{
				if (value == null)
					value = "";

				if (text != value)
				{
					text = value;
					Refresh();
					OnTextChanged(EventArgs.Empty);
				}
			}
		}
	}
}