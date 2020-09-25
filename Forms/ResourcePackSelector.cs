using MCResourcePackUtil.ResourcePacks;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCResourcePackUtil.Forms
{
	class ResourcePackSelector
	{
		public ResourcePackType ResourcePackType { get; private set; }
		public readonly List<string> ResourcePackPaths = new List<string>();

		private readonly CommonOpenFileDialog zipDialog;
		private readonly CommonOpenFileDialog folderDialog;
		private readonly CommonOpenFileDialog modDialog;
		private readonly CommonOpenFileDialog plainFolderDialog;

		public ResourcePackSelector()
		{
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

		/// <summary>
		/// ダイアログを表示してユーザーにリソースパックを選択することを求める
		/// </summary>
		/// <returns>ユーザーがキャンセルしたらfalse</returns>
		public bool ShowDialog()
		{
			var packTypeDialog = new ResourcePackTypeDialog();
			if(packTypeDialog.ShowDialog() != DialogResult.OK) {
				return false;
			}
			this.ResourcePackType = packTypeDialog.ResourcePackType;

			var packPathDialog = packTypeDialog.ResourcePackType.value switch
			{
				EnumResourcePackType.Zip => this.zipDialog,
				EnumResourcePackType.Folder => this.folderDialog,
				EnumResourcePackType.Mod => this.modDialog,
				EnumResourcePackType.PlainFolder => this.plainFolderDialog,
				_ => null,
			};

			if(packPathDialog.ShowDialog() != CommonFileDialogResult.Ok) {
				return false;
			}

			this.ResourcePackPaths.Clear();
			this.ResourcePackPaths.AddRange(packPathDialog.FileNames);
			return true;
		}
	}
}
