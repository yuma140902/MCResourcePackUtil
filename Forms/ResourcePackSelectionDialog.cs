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
	public partial class ResourcePackSelectionDialog : Form
	{
		public ResourcePackType ResourcePackType { get; private set; }
		public List<string> ResourcePackPaths { get; private set; } = new List<string>();

		private readonly CommonOpenFileDialog zipDialog;
		private readonly CommonOpenFileDialog folderDialog;
		private readonly CommonOpenFileDialog modDialog;
		private readonly CommonOpenFileDialog plainFolderDialog;


		public ResourcePackSelectionDialog()
		{
			InitializeComponent();

			this.packTypeComboBox.DataSource = ResourcePackType.GetValues();
			this.packTypeComboBox.SelectedIndex = 0;

			this.zipDialog = new CommonOpenFileDialog("Zip型リソースパックを選択...");
			this.zipDialog.Filters.Add(new CommonFileDialogFilter("Zipファイル", "*.zip"));
			this.zipDialog.Filters.Add(new CommonFileDialogFilter("すべてのファイル", "*.*"));
			this.zipDialog.Multiselect = true;

			this.folderDialog = new CommonOpenFileDialog("フォルダ型リソースパックを選択...") { IsFolderPicker = true };

			this.modDialog = new CommonOpenFileDialog("MODファイルを選択...");
			this.modDialog.Filters.Add(new CommonFileDialogFilter("MODファイル", "*.jar;*.zip"));
			this.modDialog.Filters.Add(new CommonFileDialogFilter("すべてのファイル", "*.*"));
			this.modDialog.Multiselect = true;

			this.plainFolderDialog = new CommonOpenFileDialog("フォルダを選択...") { IsFolderPicker = true };
		}


		private void okBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void cancelBtn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void selectBtn_Click(object sender, EventArgs e)
		{
			var packType = (ResourcePackType)this.packTypeComboBox.SelectedValue;
			switch (packType.value) {
				case EnumResourcePackType.Zip:
					openDialog(this.zipDialog);
					break;
				case EnumResourcePackType.Folder:
					openDialog(this.folderDialog);
					break;
				case EnumResourcePackType.Mod:
					openDialog(this.modDialog);
					break;
				case EnumResourcePackType.PlainFolder:
					openDialog(this.plainFolderDialog);
					break;
			}
		}

		private void openDialog(CommonOpenFileDialog dialog)
		{
			if(dialog.ShowDialog() == CommonFileDialogResult.Ok) {
				this.pathBox.Text = string.Join(", ", dialog.FileNames);

				this.ResourcePackPaths.AddRange(dialog.FileNames);
				this.ResourcePackType = (ResourcePackType)this.packTypeComboBox.SelectedValue;
			}
		}
	}
}
