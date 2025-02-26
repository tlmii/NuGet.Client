using System.Windows.Forms;
namespace NuGet.Options
{
    partial class PackageSourcesOptionsControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageSourcesOptionsControl));
            this.HeaderLabel = new System.Windows.Forms.Label();
            this.PackageSourcesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CopyPackageSourceStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeButton = new System.Windows.Forms.Button();
            this.images16px = new System.Windows.Forms.ImageList(this.components);
            this.packageListToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.updateButton = new System.Windows.Forms.Button();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.NewPackageSourceLabel = new System.Windows.Forms.Label();
            this.NewPackageSource = new System.Windows.Forms.TextBox();
            this.NewPackageNameLabel = new System.Windows.Forms.Label();
            this.NewPackageName = new System.Windows.Forms.TextBox();
            this.PackageSourcesListBox = new NuGet.Options.PackageSourceCheckedListBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.MachineWideSourcesLabel = new System.Windows.Forms.Label();
            this.MachineWidePackageSourcesListBox = new NuGet.Options.PackageSourceCheckedListBox();
            this.images32px = new System.Windows.Forms.ImageList(this.components);
            this.images64px = new System.Windows.Forms.ImageList(this.components);
            this.PackageSourcesContextMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // HeaderLabel
            // 
            resources.ApplyResources(this.HeaderLabel, "HeaderLabel");
            this.HeaderLabel.Name = "HeaderLabel";
            // 
            // PackageSourcesContextMenu
            // 
            this.PackageSourcesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CopyPackageSourceStripMenuItem});
            this.PackageSourcesContextMenu.Name = "contextMenuStrip1";
            resources.ApplyResources(this.PackageSourcesContextMenu, "PackageSourcesContextMenu");
            this.PackageSourcesContextMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.PackageSourcesContextMenu_ItemClicked);
            // 
            // CopyPackageSourceStripMenuItem
            // 
            this.CopyPackageSourceStripMenuItem.Name = "CopyPackageSourceStripMenuItem";
            resources.ApplyResources(this.CopyPackageSourceStripMenuItem, "CopyPackageSourceStripMenuItem");
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.ImageList = this.images16px;
            this.removeButton.Name = "removeButton";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.OnRemoveButtonClick);
            // 
            // images16px
            // 
            this.images16px.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images16px.ImageStream")));
            this.images16px.TransparentColor = System.Drawing.Color.Transparent;
            this.images16px.Images.SetKeyName(0, "up_512.png");
            this.images16px.Images.SetKeyName(1, "down_512.png");
            this.images16px.Images.SetKeyName(2, "cancel_512.png");
            this.images16px.Images.SetKeyName(3, "add_512.png");
            // 
            // updateButton
            // 
            resources.ApplyResources(this.updateButton, "updateButton");
            this.updateButton.Name = "updateButton";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.OnUpdateButtonClick);
            // 
            // BrowseButton
            // 
            resources.ApplyResources(this.BrowseButton, "BrowseButton");
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.OnBrowseButtonClicked);
            // 
            // NewPackageSourceLabel
            // 
            resources.ApplyResources(this.NewPackageSourceLabel, "NewPackageSourceLabel");
            this.NewPackageSourceLabel.Name = "NewPackageSourceLabel";
            // 
            // NewPackageSource
            // 
            resources.ApplyResources(this.NewPackageSource, "NewPackageSource");
            this.NewPackageSource.Name = "NewPackageSource";
            // 
            // NewPackageNameLabel
            // 
            resources.ApplyResources(this.NewPackageNameLabel, "NewPackageNameLabel");
            this.NewPackageNameLabel.Name = "NewPackageNameLabel";
            // 
            // NewPackageName
            // 
            resources.ApplyResources(this.NewPackageName, "NewPackageName");
            this.NewPackageName.Name = "NewPackageName";
            // 
            // PackageSourcesListBox
            // 
            resources.ApplyResources(this.PackageSourcesListBox, "PackageSourcesListBox");
            this.PackageSourcesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PackageSourcesListBox.CheckBoxSize = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.SetColumnSpan(this.PackageSourcesListBox, 4);
            this.PackageSourcesListBox.ContextMenuStrip = this.PackageSourcesContextMenu;
            this.PackageSourcesListBox.FormattingEnabled = true;
            this.PackageSourcesListBox.Name = "PackageSourcesListBox";
            this.PackageSourcesListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PackageSourcesListBox_KeyUp);
            this.PackageSourcesListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PackageSourcesListBox_MouseMove);
            this.PackageSourcesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PackageSourcesListBox_ItemCheck);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PackageSourcesListBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.MachineWideSourcesLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.MachineWidePackageSourcesListBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.NewPackageNameLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.NewPackageName, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.NewPackageSourceLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.NewPackageSource, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.BrowseButton, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.updateButton, 3, 5);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 4);
            this.tableLayoutPanel2.Controls.Add(this.HeaderLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.addButton, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.removeButton, 2, 0);
            this.tableLayoutPanel2.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.ImageList = this.images16px;
            this.addButton.Name = "addButton";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnAddButtonClick);
            // 
            // MachineWideSourcesLabel
            // 
            resources.ApplyResources(this.MachineWideSourcesLabel, "MachineWideSourcesLabel");
            this.tableLayoutPanel1.SetColumnSpan(this.MachineWideSourcesLabel, 4);
            this.MachineWideSourcesLabel.Name = "MachineWideSourcesLabel";
            // 
            // MachineWidePackageSourcesListBox
            // 
            resources.ApplyResources(this.MachineWidePackageSourcesListBox, "MachineWidePackageSourcesListBox");
            this.MachineWidePackageSourcesListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MachineWidePackageSourcesListBox.CheckBoxSize = new System.Drawing.Size(0, 0);
            this.tableLayoutPanel1.SetColumnSpan(this.MachineWidePackageSourcesListBox, 4);
            this.MachineWidePackageSourcesListBox.ContextMenuStrip = this.PackageSourcesContextMenu;
            this.MachineWidePackageSourcesListBox.FormattingEnabled = true;
            this.MachineWidePackageSourcesListBox.Name = "MachineWidePackageSourcesListBox";
            this.MachineWidePackageSourcesListBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.PackageSourcesListBox_KeyUp);
            this.MachineWidePackageSourcesListBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PackageSourcesListBox_MouseMove);
            this.MachineWidePackageSourcesListBox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.PackageSourcesListBox_ItemCheck);
            // 
            // images32px
            // 
            this.images32px.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images32px.ImageStream")));
            this.images32px.TransparentColor = System.Drawing.Color.Transparent;
            this.images32px.Images.SetKeyName(0, "up_512.png");
            this.images32px.Images.SetKeyName(1, "down_512.png");
            this.images32px.Images.SetKeyName(2, "cancel_512.png");
            this.images32px.Images.SetKeyName(3, "add_512.png");
            // 
            // images64px
            // 
            this.images64px.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("images64px.ImageStream")));
            this.images64px.TransparentColor = System.Drawing.Color.Transparent;
            this.images64px.Images.SetKeyName(0, "up_512.png");
            this.images64px.Images.SetKeyName(1, "down_512.png");
            this.images64px.Images.SetKeyName(2, "cancel_512.png");
            this.images64px.Images.SetKeyName(3, "add_512.png");
            // 
            // PackageSourcesOptionsControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PackageSourcesOptionsControl";
            this.PackageSourcesContextMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HeaderLabel;
        private System.Windows.Forms.Button removeButton;
        private ContextMenuStrip PackageSourcesContextMenu;
        private ToolStripMenuItem CopyPackageSourceStripMenuItem;
        private ToolTip packageListToolTip;
        private Button updateButton;
        private Button BrowseButton;
        private Label NewPackageSourceLabel;
        private TextBox NewPackageSource;
        private Label NewPackageNameLabel;
        private TextBox NewPackageName;
        private TableLayoutPanel tableLayoutPanel1;
        private PackageSourceCheckedListBox PackageSourcesListBox;
        private TableLayoutPanel tableLayoutPanel2;
        private ImageList images16px;
        private Button addButton;
        private Label MachineWideSourcesLabel;
        private PackageSourceCheckedListBox MachineWidePackageSourcesListBox;
        private ImageList images32px;
        private ImageList images64px;
    }
}
