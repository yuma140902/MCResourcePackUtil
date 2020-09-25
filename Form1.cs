using MCResourcePackUtil.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCResourcePackUtil
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void filterBtn_Click(object sender, EventArgs e)
		{
			var form = new FilterForm();
			form.ShowDialog();
		}
	}
}
