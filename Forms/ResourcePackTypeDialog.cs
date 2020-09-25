using MCResourcePackUtil.ResourcePacks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCResourcePackUtil.Forms
{
	public partial class ResourcePackTypeDialog : Form
	{
		public ResourcePackType ResourcePackType { get; private set; }

		public ResourcePackTypeDialog()
		{
			InitializeComponent();
			 
			this.packTypeComboBox.DataSource = ResourcePackType.GetValues();
			this.packTypeComboBox.SelectedIndex = 0;
		}


		private void okBtn_Click(object sender, EventArgs e)
		{
			this.ResourcePackType = (ResourcePackType)this.packTypeComboBox.SelectedValue;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
