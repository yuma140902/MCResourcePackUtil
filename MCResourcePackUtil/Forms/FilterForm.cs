using MCResourcePackUtil.GraphicFilters;
using MCResourcePackUtil.ResourcePacks;
using MCResourcePackUtil.Util;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MCResourcePackUtil.Forms
{
    public partial class FilterForm : Form
    {
        private CommonSaveFileDialog zipSaveDialog;
        private CommonOpenFileDialog folderSaveDialog;

        private List<string> resourcePackPaths;
        private ResourcePackType resourcePackType;

        private string outputZipPath;
        private string outputFolderPath;

        public FilterForm()
        {
            InitializeComponent();

            this.zipSaveDialog = new CommonSaveFileDialog("保存先を選択...");
            this.zipSaveDialog.Filters.Add(new CommonFileDialogFilter("Zipファイル", "*.zip"));
            this.zipSaveDialog.Filters.Add(new CommonFileDialogFilter("すべてのファイル", "*.*"));

            this.folderSaveDialog = new CommonOpenFileDialog("保存先フォルダを選択...");
            this.folderSaveDialog.IsFolderPicker = true;

            this.filterTypeBox.SelectedIndex = 0;
        }


        private void selectionBtn_Click(object sender, EventArgs e)
        {
            var dialog = new ResourcePackSelector();
            if (dialog.ShowDialog())
            {
                this.pathBox.Text = string.Join(", ", dialog.ResourcePackPaths);
                this.resourcePackPaths = dialog.ResourcePackPaths;
                this.resourcePackType = dialog.ResourcePackType;
            }
        }

        private void outputSelectBtn_Click(object sender, EventArgs e)
        {
            if (this.resourcePackPaths.Count == 0)
            {
                MessageBox.Show("先に入力を選択してください", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (this.resourcePackPaths.Count == 1)
            {
                this.zipSaveDialog.DefaultFileName = Path.GetFileNameWithoutExtension(this.resourcePackPaths[0]) + ".zip";
                if (this.zipSaveDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    this.outputPathBox.Text = this.zipSaveDialog.FileName;
                    this.outputZipPath = this.zipSaveDialog.FileName;
                }
            }
            else
            {
                if (this.folderSaveDialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    this.outputPathBox.Text = this.folderSaveDialog.FileName;
                    this.outputFolderPath = this.folderSaveDialog.FileName;
                }
            }
        }


        private void runBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.pathBox.Text))
            {
                MessageBox.Show("リソースパックが選択されていません", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(this.outputPathBox.Text))
            {
                MessageBox.Show("出力先が選択されていません", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var filter = this.filterTypeBox.SelectedIndex == 0 ? (IGraphicFilter)TraditionalBeautyFilter.Instance :
                         this.filterTypeBox.SelectedIndex == 1 ? (IGraphicFilter)TraditionalBeautyFilterMoreBold.Instance :
                         this.filterTypeBox.SelectedIndex == 2 ? (IGraphicFilter)TraditionalBeautyV2Filter.Instance :
                         (IGraphicFilter)TraditionalBeautyFilter.Instance;

            if (this.resourcePackPaths.Count == 1)
            {
                run(this.resourcePackType, this.resourcePackPaths[0], outputZipPath, filter);
            }
            else
            {
                foreach (string pack in this.resourcePackPaths)
                {
                    string output = Path.Combine(this.outputFolderPath, Path.GetFileNameWithoutExtension(pack) + ".zip");
                    run(this.resourcePackType, pack, output, filter);
                }
            }

        }

        private static void run(EnumResourcePackType packType, string packPath, string outputZipPath, IGraphicFilter filter)
        {
            using var tempDir = new TemporaryDirectory();
            Debug.WriteLine($"tempDir: {tempDir.Path}");
            var resourcePack = ResourcePackLoaders.Load(packType, packPath);
            foreach (var texture in resourcePack.EnumerateTextures())
            {
                texture.LoadPngFileToMemory();
                texture.ApplyFilter(filter);
                texture.WriteToResourcePack(tempDir.Path);
                texture.Dispose();
            }

            ZipFile.CreateFromDirectory(tempDir.Path, outputZipPath, CompressionLevel.Fastest, false, Encoding.UTF8);
            using (var ar = ZipFile.Open(outputZipPath, ZipArchiveMode.Update))
            {
                var entry = ar.CreateEntry("pack.mcmeta");
                using (var writer = new StreamWriter(entry.Open(), Encoding.UTF8))
                {
                    writer.WriteLine(
                        "{\n" +
                        "  \"pack\": {\n" +
                        "    \"pack_format\": 2,\n" +
                        "    \"description\": \"Made by MCResourcePackUtil (dev: yuma140902)\"\n" +
                        "  }\n" +
                        "}");
                }
            }
        }
    }
}
