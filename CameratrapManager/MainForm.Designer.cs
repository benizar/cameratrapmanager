/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 11:50
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace CameratrapManager
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			this.msMain = new System.Windows.Forms.MenuStrip();
			this.projectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.newProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.existingProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.saveProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitProgramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.cameraStationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.loadStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbRemoveStation = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbSelectStationImage = new System.Windows.Forms.ToolStripMenuItem();
			this.photoSamplesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.uploadSamplesToStationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.removeCurrentSampleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbDataToExcel = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbCompletePDF = new System.Windows.Forms.ToolStripMenuItem();
			this.tsbCreateAbundancesShapefiles = new System.Windows.Forms.ToolStripMenuItem();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.tvProject = new System.Windows.Forms.TreeView();
			this.cmsTreeView = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctxtsbAddStationImage = new System.Windows.Forms.ToolStripMenuItem();
			this.ctxtsbRemoveStation = new System.Windows.Forms.ToolStripMenuItem();
			this.cntxtsbRemoveSample = new System.Windows.Forms.ToolStripMenuItem();
			this.cntxtsbUploadSamples = new System.Windows.Forms.ToolStripMenuItem();
			this.imgListForm = new System.Windows.Forms.ImageList(this.components);
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.splitContainer3 = new System.Windows.Forms.SplitContainer();
			this.tabControl = new System.Windows.Forms.TabControl();
			this.tabPag1 = new System.Windows.Forms.TabPage();
			this.label1 = new System.Windows.Forms.Label();
			this.lblUnknown = new System.Windows.Forms.Label();
			this.lblInvalid = new System.Windows.Forms.Label();
			this.lblManagement = new System.Windows.Forms.Label();
			this.btEmpty = new System.Windows.Forms.Button();
			this.btUnknown = new System.Windows.Forms.Button();
			this.btInvalid = new System.Windows.Forms.Button();
			this.btManagement = new System.Windows.Forms.Button();
			this.tabPag2 = new System.Windows.Forms.TabPage();
			this.lstViewData = new System.Windows.Forms.ListView();
			this.dgvSelectCount = new System.Windows.Forms.DataGridView();
			this.dgvSelectSpecies = new System.Windows.Forms.DataGridView();
			this.cmbSelectSpecies = new System.Windows.Forms.ComboBox();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.txtProcessStatus = new System.Windows.Forms.ToolStripStatusLabel();
			this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
			this.txtProcessStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
			this.msMain.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.cmsTreeView.SuspendLayout();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.splitContainer3.Panel1.SuspendLayout();
			this.splitContainer3.Panel2.SuspendLayout();
			this.splitContainer3.SuspendLayout();
			this.tabControl.SuspendLayout();
			this.tabPag1.SuspendLayout();
			this.tabPag2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvSelectCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSelectSpecies)).BeginInit();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// msMain
			// 
			this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.projectToolStripMenuItem,
									this.cameraStationsToolStripMenuItem,
									this.photoSamplesToolStripMenuItem,
									this.reportsToolStripMenuItem});
			this.msMain.Location = new System.Drawing.Point(0, 0);
			this.msMain.Name = "msMain";
			this.msMain.Size = new System.Drawing.Size(744, 24);
			this.msMain.TabIndex = 0;
			this.msMain.Text = "menuStrip1";
			// 
			// projectToolStripMenuItem
			// 
			this.projectToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newProjectToolStripMenuItem,
									this.existingProjectToolStripMenuItem,
									this.toolStripSeparator3,
									this.saveProjectToolStripMenuItem,
									this.toolStripSeparator2,
									this.closeProjectToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitProgramToolStripMenuItem});
			this.projectToolStripMenuItem.Name = "projectToolStripMenuItem";
			this.projectToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
			this.projectToolStripMenuItem.Text = "Project";
			// 
			// newProjectToolStripMenuItem
			// 
			this.newProjectToolStripMenuItem.Name = "newProjectToolStripMenuItem";
			this.newProjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.newProjectToolStripMenuItem.Text = "New project";
			this.newProjectToolStripMenuItem.Click += new System.EventHandler(this.NewProjectToolStripMenuItemClick);
			// 
			// existingProjectToolStripMenuItem
			// 
			this.existingProjectToolStripMenuItem.Name = "existingProjectToolStripMenuItem";
			this.existingProjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.existingProjectToolStripMenuItem.Text = "Existing project";
			this.existingProjectToolStripMenuItem.Click += new System.EventHandler(this.ExistingProjectToolStripMenuItemClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(151, 6);
			// 
			// saveProjectToolStripMenuItem
			// 
			this.saveProjectToolStripMenuItem.Name = "saveProjectToolStripMenuItem";
			this.saveProjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.saveProjectToolStripMenuItem.Text = "Save project";
			this.saveProjectToolStripMenuItem.Click += new System.EventHandler(this.SaveProjectToolStripMenuItemClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(151, 6);
			// 
			// closeProjectToolStripMenuItem
			// 
			this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
			this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.closeProjectToolStripMenuItem.Text = "Close project";
			this.closeProjectToolStripMenuItem.Click += new System.EventHandler(this.CloseProjectToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(151, 6);
			// 
			// exitProgramToolStripMenuItem
			// 
			this.exitProgramToolStripMenuItem.Name = "exitProgramToolStripMenuItem";
			this.exitProgramToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
			this.exitProgramToolStripMenuItem.Text = "Exit program";
			this.exitProgramToolStripMenuItem.Click += new System.EventHandler(this.ExitProgramToolStripMenuItemClick);
			// 
			// cameraStationsToolStripMenuItem
			// 
			this.cameraStationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.loadStationToolStripMenuItem,
									this.tsbRemoveStation,
									this.tsbSelectStationImage});
			this.cameraStationsToolStripMenuItem.Name = "cameraStationsToolStripMenuItem";
			this.cameraStationsToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
			this.cameraStationsToolStripMenuItem.Text = "Camera Stations";
			// 
			// loadStationToolStripMenuItem
			// 
			this.loadStationToolStripMenuItem.Name = "loadStationToolStripMenuItem";
			this.loadStationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.loadStationToolStripMenuItem.Text = "New station";
			this.loadStationToolStripMenuItem.Click += new System.EventHandler(this.NewStationToolStripMenuItemClick);
			// 
			// tsbRemoveStation
			// 
			this.tsbRemoveStation.Name = "tsbRemoveStation";
			this.tsbRemoveStation.Size = new System.Drawing.Size(180, 22);
			this.tsbRemoveStation.Text = "Remove station";
			this.tsbRemoveStation.Click += new System.EventHandler(this.tsbRemoveStationClick);
			// 
			// tsbSelectStationImage
			// 
			this.tsbSelectStationImage.Name = "tsbSelectStationImage";
			this.tsbSelectStationImage.Size = new System.Drawing.Size(180, 22);
			this.tsbSelectStationImage.Text = "Select station Image";
			this.tsbSelectStationImage.Click += new System.EventHandler(this.TsbSelectStationImageClick);
			// 
			// photoSamplesToolStripMenuItem
			// 
			this.photoSamplesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.uploadSamplesToStationToolStripMenuItem,
									this.removeCurrentSampleToolStripMenuItem});
			this.photoSamplesToolStripMenuItem.Name = "photoSamplesToolStripMenuItem";
			this.photoSamplesToolStripMenuItem.Size = new System.Drawing.Size(98, 20);
			this.photoSamplesToolStripMenuItem.Text = "Photo Samples";
			// 
			// uploadSamplesToStationToolStripMenuItem
			// 
			this.uploadSamplesToStationToolStripMenuItem.Name = "uploadSamplesToStationToolStripMenuItem";
			this.uploadSamplesToStationToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.uploadSamplesToStationToolStripMenuItem.Text = "Upload samples to current station";
			this.uploadSamplesToStationToolStripMenuItem.Click += new System.EventHandler(this.tsbUploadSamplesClick);
			// 
			// removeCurrentSampleToolStripMenuItem
			// 
			this.removeCurrentSampleToolStripMenuItem.Name = "removeCurrentSampleToolStripMenuItem";
			this.removeCurrentSampleToolStripMenuItem.Size = new System.Drawing.Size(252, 22);
			this.removeCurrentSampleToolStripMenuItem.Text = "Remove current sample";
			this.removeCurrentSampleToolStripMenuItem.Click += new System.EventHandler(this.tsbRemoveSampleClick);
			// 
			// reportsToolStripMenuItem
			// 
			this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.tsbDataToExcel,
									this.tsbCompletePDF,
									this.tsbCreateAbundancesShapefiles});
			this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
			this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
			this.reportsToolStripMenuItem.Text = "Reports";
			// 
			// tsbDataToExcel
			// 
			this.tsbDataToExcel.Name = "tsbDataToExcel";
			this.tsbDataToExcel.Size = new System.Drawing.Size(196, 22);
			this.tsbDataToExcel.Text = "Export to Excel";
			this.tsbDataToExcel.Click += new System.EventHandler(this.tsbExportToExcelClick);
			// 
			// tsbCompletePDF
			// 
			this.tsbCompletePDF.Name = "tsbCompletePDF";
			this.tsbCompletePDF.Size = new System.Drawing.Size(196, 22);
			this.tsbCompletePDF.Text = "Complete PDF Report";
			this.tsbCompletePDF.Click += new System.EventHandler(this.tsbCompletePDFClick);
			// 
			// tsbCreateAbundancesShapefiles
			// 
			this.tsbCreateAbundancesShapefiles.Name = "tsbCreateAbundancesShapefiles";
			this.tsbCreateAbundancesShapefiles.Size = new System.Drawing.Size(196, 22);
			this.tsbCreateAbundancesShapefiles.Text = "Abundances Shapefiles";
			this.tsbCreateAbundancesShapefiles.Click += new System.EventHandler(this.tsbCreateAbundanceShapefilesClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer1.Location = new System.Drawing.Point(0, 24);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.tvProject);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Size = new System.Drawing.Size(744, 474);
			this.splitContainer1.SplitterDistance = 131;
			this.splitContainer1.TabIndex = 2;
			// 
			// tvProject
			// 
			this.tvProject.ContextMenuStrip = this.cmsTreeView;
			this.tvProject.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tvProject.HideSelection = false;
			this.tvProject.ImageIndex = 0;
			this.tvProject.ImageList = this.imgListForm;
			this.tvProject.Location = new System.Drawing.Point(0, 0);
			this.tvProject.Name = "tvProject";
			this.tvProject.SelectedImageIndex = 0;
			this.tvProject.Size = new System.Drawing.Size(127, 470);
			this.tvProject.TabIndex = 0;
			this.tvProject.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TvProjectAfterSelect);
			// 
			// cmsTreeView
			// 
			this.cmsTreeView.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.ctxtsbAddStationImage,
									this.ctxtsbRemoveStation,
									this.cntxtsbRemoveSample,
									this.cntxtsbUploadSamples});
			this.cmsTreeView.Name = "cmsTreeView";
			this.cmsTreeView.Size = new System.Drawing.Size(214, 92);
			// 
			// ctxtsbAddStationImage
			// 
			this.ctxtsbAddStationImage.Name = "ctxtsbAddStationImage";
			this.ctxtsbAddStationImage.Size = new System.Drawing.Size(213, 22);
			this.ctxtsbAddStationImage.Text = "Select Station Image";
			this.ctxtsbAddStationImage.Click += new System.EventHandler(this.CtxtsbSelectStationImageClick);
			// 
			// ctxtsbRemoveStation
			// 
			this.ctxtsbRemoveStation.Name = "ctxtsbRemoveStation";
			this.ctxtsbRemoveStation.Size = new System.Drawing.Size(213, 22);
			this.ctxtsbRemoveStation.Text = "Remove Station";
			this.ctxtsbRemoveStation.Click += new System.EventHandler(this.CtxtsbRemoveStationClick);
			// 
			// cntxtsbRemoveSample
			// 
			this.cntxtsbRemoveSample.Name = "cntxtsbRemoveSample";
			this.cntxtsbRemoveSample.Size = new System.Drawing.Size(213, 22);
			this.cntxtsbRemoveSample.Text = "Remove Sample";
			this.cntxtsbRemoveSample.Click += new System.EventHandler(this.CntxtsbRemoveSampleClick);
			// 
			// cntxtsbUploadSamples
			// 
			this.cntxtsbUploadSamples.Name = "cntxtsbUploadSamples";
			this.cntxtsbUploadSamples.Size = new System.Drawing.Size(213, 22);
			this.cntxtsbUploadSamples.Text = "Upload Samples to Station";
			this.cntxtsbUploadSamples.Click += new System.EventHandler(this.cntxttbUploadSamplesClick);
			// 
			// imgListForm
			// 
			this.imgListForm.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgListForm.ImageStream")));
			this.imgListForm.TransparentColor = System.Drawing.Color.Transparent;
			this.imgListForm.Images.SetKeyName(0, "Folder-64.png");
			this.imgListForm.Images.SetKeyName(1, "Green-Camera-Symbol-128.png");
			this.imgListForm.Images.SetKeyName(2, "Black-Camera-Symbol-128.png");
			this.imgListForm.Images.SetKeyName(3, "Orange-Camera-Symbol-128.png");
			this.imgListForm.Images.SetKeyName(4, "Question.png");
			this.imgListForm.Images.SetKeyName(5, "Comment-empty-48.png");
			this.imgListForm.Images.SetKeyName(6, "Blue-Camera-Symbol-128.png");
			// 
			// splitContainer2
			// 
			this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.pictureBox1);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
			this.splitContainer2.Size = new System.Drawing.Size(609, 474);
			this.splitContainer2.SplitterDistance = 485;
			this.splitContainer2.TabIndex = 1;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(481, 470);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			// 
			// splitContainer3
			// 
			this.splitContainer3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer3.Location = new System.Drawing.Point(0, 0);
			this.splitContainer3.Name = "splitContainer3";
			this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer3.Panel1
			// 
			this.splitContainer3.Panel1.Controls.Add(this.tabControl);
			// 
			// splitContainer3.Panel2
			// 
			this.splitContainer3.Panel2.Controls.Add(this.dgvSelectCount);
			this.splitContainer3.Panel2.Controls.Add(this.dgvSelectSpecies);
			this.splitContainer3.Panel2.Controls.Add(this.cmbSelectSpecies);
			this.splitContainer3.Size = new System.Drawing.Size(120, 474);
			this.splitContainer3.SplitterDistance = 205;
			this.splitContainer3.TabIndex = 0;
			// 
			// tabControl
			// 
			this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl.Controls.Add(this.tabPag1);
			this.tabControl.Controls.Add(this.tabPag2);
			this.tabControl.Location = new System.Drawing.Point(-2, -2);
			this.tabControl.Name = "tabControl";
			this.tabControl.SelectedIndex = 0;
			this.tabControl.Size = new System.Drawing.Size(120, 205);
			this.tabControl.TabIndex = 0;
			// 
			// tabPag1
			// 
			this.tabPag1.Controls.Add(this.label1);
			this.tabPag1.Controls.Add(this.lblUnknown);
			this.tabPag1.Controls.Add(this.lblInvalid);
			this.tabPag1.Controls.Add(this.lblManagement);
			this.tabPag1.Controls.Add(this.btEmpty);
			this.tabPag1.Controls.Add(this.btUnknown);
			this.tabPag1.Controls.Add(this.btInvalid);
			this.tabPag1.Controls.Add(this.btManagement);
			this.tabPag1.Location = new System.Drawing.Point(4, 22);
			this.tabPag1.Name = "tabPag1";
			this.tabPag1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPag1.Size = new System.Drawing.Size(112, 179);
			this.tabPag1.TabIndex = 0;
			this.tabPag1.Text = "Identify";
			this.tabPag1.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(47, 137);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 24);
			this.label1.TabIndex = 7;
			this.label1.Text = "Empty";
			// 
			// lblUnknown
			// 
			this.lblUnknown.Location = new System.Drawing.Point(47, 96);
			this.lblUnknown.Name = "lblUnknown";
			this.lblUnknown.Size = new System.Drawing.Size(85, 24);
			this.lblUnknown.TabIndex = 6;
			this.lblUnknown.Text = "Unknown";
			// 
			// lblInvalid
			// 
			this.lblInvalid.Location = new System.Drawing.Point(47, 55);
			this.lblInvalid.Name = "lblInvalid";
			this.lblInvalid.Size = new System.Drawing.Size(85, 23);
			this.lblInvalid.TabIndex = 5;
			this.lblInvalid.Text = "Invalid";
			// 
			// lblManagement
			// 
			this.lblManagement.Location = new System.Drawing.Point(47, 14);
			this.lblManagement.Name = "lblManagement";
			this.lblManagement.Size = new System.Drawing.Size(85, 23);
			this.lblManagement.TabIndex = 4;
			this.lblManagement.Text = "Management";
			// 
			// btEmpty
			// 
			this.btEmpty.ImageKey = "Comment-empty-48.png";
			this.btEmpty.ImageList = this.imgListForm;
			this.btEmpty.Location = new System.Drawing.Point(3, 126);
			this.btEmpty.Name = "btEmpty";
			this.btEmpty.Size = new System.Drawing.Size(38, 35);
			this.btEmpty.TabIndex = 3;
			this.btEmpty.UseVisualStyleBackColor = true;
			this.btEmpty.Click += new System.EventHandler(this.BtEmptyClick);
			// 
			// btUnknown
			// 
			this.btUnknown.ImageKey = "Question.png";
			this.btUnknown.ImageList = this.imgListForm;
			this.btUnknown.Location = new System.Drawing.Point(3, 85);
			this.btUnknown.Name = "btUnknown";
			this.btUnknown.Size = new System.Drawing.Size(38, 35);
			this.btUnknown.TabIndex = 2;
			this.btUnknown.UseVisualStyleBackColor = true;
			this.btUnknown.Click += new System.EventHandler(this.BtUnknownClick);
			// 
			// btInvalid
			// 
			this.btInvalid.ImageKey = "Orange-Camera-Symbol-128.png";
			this.btInvalid.ImageList = this.imgListForm;
			this.btInvalid.Location = new System.Drawing.Point(3, 44);
			this.btInvalid.Name = "btInvalid";
			this.btInvalid.Size = new System.Drawing.Size(38, 35);
			this.btInvalid.TabIndex = 1;
			this.btInvalid.UseVisualStyleBackColor = true;
			this.btInvalid.Click += new System.EventHandler(this.BtInvalidClick);
			// 
			// btManagement
			// 
			this.btManagement.ImageKey = "Blue-Camera-Symbol-128.png";
			this.btManagement.ImageList = this.imgListForm;
			this.btManagement.Location = new System.Drawing.Point(3, 3);
			this.btManagement.Name = "btManagement";
			this.btManagement.Size = new System.Drawing.Size(38, 35);
			this.btManagement.TabIndex = 0;
			this.btManagement.UseVisualStyleBackColor = true;
			this.btManagement.Click += new System.EventHandler(this.BtManagementClick);
			// 
			// tabPag2
			// 
			this.tabPag2.Controls.Add(this.lstViewData);
			this.tabPag2.Location = new System.Drawing.Point(4, 22);
			this.tabPag2.Name = "tabPag2";
			this.tabPag2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPag2.Size = new System.Drawing.Size(112, 179);
			this.tabPag2.TabIndex = 1;
			this.tabPag2.Text = "Metadata";
			this.tabPag2.UseVisualStyleBackColor = true;
			// 
			// lstViewData
			// 
			this.lstViewData.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstViewData.GridLines = true;
			this.lstViewData.Location = new System.Drawing.Point(3, 3);
			this.lstViewData.Name = "lstViewData";
			this.lstViewData.Size = new System.Drawing.Size(106, 173);
			this.lstViewData.TabIndex = 1;
			this.lstViewData.UseCompatibleStateImageBehavior = false;
			// 
			// dgvSelectCount
			// 
			this.dgvSelectCount.AllowUserToAddRows = false;
			this.dgvSelectCount.AllowUserToDeleteRows = false;
			this.dgvSelectCount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dgvSelectCount.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dgvSelectCount.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSelectCount.ColumnHeadersVisible = false;
			this.dgvSelectCount.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.dgvSelectCount.Location = new System.Drawing.Point(0, 170);
			this.dgvSelectCount.Name = "dgvSelectCount";
			this.dgvSelectCount.ReadOnly = true;
			this.dgvSelectCount.RowHeadersVisible = false;
			this.dgvSelectCount.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.dgvSelectCount.Size = new System.Drawing.Size(116, 91);
			this.dgvSelectCount.TabIndex = 1;
			this.dgvSelectCount.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSelectCountClick);
			// 
			// dgvSelectSpecies
			// 
			this.dgvSelectSpecies.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvSelectSpecies.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.dgvSelectSpecies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvSelectSpecies.ColumnHeadersVisible = false;
			this.dgvSelectSpecies.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvSelectSpecies.Location = new System.Drawing.Point(0, 21);
			this.dgvSelectSpecies.Name = "dgvSelectSpecies";
			this.dgvSelectSpecies.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.dgvSelectSpecies.RowTemplate.Height = 30;
			this.dgvSelectSpecies.Size = new System.Drawing.Size(116, 240);
			this.dgvSelectSpecies.TabIndex = 26;
			this.dgvSelectSpecies.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvSelectSpeciesClick);
			this.dgvSelectSpecies.UserDeletedRow += new System.Windows.Forms.DataGridViewRowEventHandler(this.DgvSelectSpeciesUserDeletedRow);
			// 
			// cmbSelectSpecies
			// 
			this.cmbSelectSpecies.AutoCompleteCustomSource.AddRange(new string[] {
									"Erinaceus europaeus",
									"Atelerix algirus",
									"Microtus arvalis",
									"Microtus cabrerae",
									"Microtus agrestis",
									"Microtus lusitanicus",
									"Microtus duodecimcostatus",
									"Microtus gerbei",
									"Chionomys nivalis",
									"Arvicola terrestris",
									"Arvicola sapidus",
									"Myodes glareolus",
									"Ondatra zibethicus",
									"Micromys minutus",
									"Apodemus flavicollis",
									"Apodemus sylvaticus",
									"Mus musculus",
									"Mus spretus",
									"Rattus norvegicus",
									"Rattus rattus",
									"Eliomys quercinus",
									"Glis glis",
									"Sciurus vulgaris",
									"Atlantoxerus getulus",
									"Marmota marmota",
									"Myocastor coipus",
									"Lepus europaeus",
									"Lepus castroviejoi",
									"Lepus granatensis",
									"Oryctolagus cuniculus",
									"Ursus arctos",
									"Canis lupus",
									"Vulpes vulpes",
									"Mustela erminea",
									"Mustela nivalis",
									"Mustela lutreola",
									"Neovison vison",
									"Mustela putorius",
									"Martes martes",
									"Martes foina",
									"Lutra lutra",
									"Meles meles",
									"Herpestes ichneumon",
									"Genetta genetta",
									"Lynx pardinus",
									"Felis silvestris",
									"Sus scrofa",
									"Ovis orientalis",
									"Capra pyrenaica",
									"Rupicapra pyrenaica",
									"Ammotragus lervia",
									"Cervus elaphus",
									"Dama dama",
									"Capreolus capreolus"});
			this.cmbSelectSpecies.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
			this.cmbSelectSpecies.Dock = System.Windows.Forms.DockStyle.Top;
			this.cmbSelectSpecies.FormattingEnabled = true;
			this.cmbSelectSpecies.Location = new System.Drawing.Point(0, 0);
			this.cmbSelectSpecies.Name = "cmbSelectSpecies";
			this.cmbSelectSpecies.Size = new System.Drawing.Size(116, 21);
			this.cmbSelectSpecies.TabIndex = 26;
			this.cmbSelectSpecies.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmbSelectSpeciesKeyDown);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.StatusStrip);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(744, 501);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.LeftToolStripPanelVisible = false;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.RightToolStripPanelVisible = false;
			this.toolStripContainer1.Size = new System.Drawing.Size(744, 523);
			this.toolStripContainer1.TabIndex = 4;
			this.toolStripContainer1.Text = "toolStripContainer1";
			this.toolStripContainer1.TopToolStripPanelVisible = false;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Dock = System.Windows.Forms.DockStyle.None;
			this.StatusStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.txtProcessStatus,
									this.toolStripProgressBar1,
									this.txtProcessStatus2});
			this.StatusStrip.Location = new System.Drawing.Point(0, 0);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(744, 22);
			this.StatusStrip.TabIndex = 0;
			// 
			// txtProcessStatus
			// 
			this.txtProcessStatus.Name = "txtProcessStatus";
			this.txtProcessStatus.Size = new System.Drawing.Size(84, 17);
			this.txtProcessStatus.Text = "Process status:";
			// 
			// toolStripProgressBar1
			// 
			this.toolStripProgressBar1.Name = "toolStripProgressBar1";
			this.toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
			// 
			// txtProcessStatus2
			// 
			this.txtProcessStatus2.Name = "txtProcessStatus2";
			this.txtProcessStatus2.Size = new System.Drawing.Size(60, 17);
			this.txtProcessStatus2.Text = "Image x/X";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(744, 523);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.msMain);
			this.Controls.Add(this.toolStripContainer1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.msMain;
			this.Name = "MainForm";
			this.Text = "CameratrapManager";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.msMain.ResumeLayout(false);
			this.msMain.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.cmsTreeView.ResumeLayout(false);
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.splitContainer3.Panel1.ResumeLayout(false);
			this.splitContainer3.Panel2.ResumeLayout(false);
			this.splitContainer3.ResumeLayout(false);
			this.tabControl.ResumeLayout(false);
			this.tabPag1.ResumeLayout(false);
			this.tabPag2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvSelectCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvSelectSpecies)).EndInit();
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridView dgvSelectCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblManagement;
		private System.Windows.Forms.Label lblInvalid;
		private System.Windows.Forms.Label lblUnknown;
		private System.Windows.Forms.Button btInvalid;
		private System.Windows.Forms.Button btUnknown;
		private System.Windows.Forms.Button btEmpty;
		private System.Windows.Forms.Button btManagement;
		private System.Windows.Forms.TabPage tabPag2;
		private System.Windows.Forms.TabPage tabPag1;
		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel txtProcessStatus;
		private System.Windows.Forms.ToolStripStatusLabel txtProcessStatus2;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.ToolStripMenuItem cntxtsbUploadSamples;
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.ImageList imgListForm;
		private System.Windows.Forms.ComboBox cmbSelectSpecies;
		private System.Windows.Forms.TreeView tvProject;
		private System.Windows.Forms.DataGridView dgvSelectSpecies;
		private System.Windows.Forms.ToolStripMenuItem tsbSelectStationImage;
		private System.Windows.Forms.ToolStripMenuItem cntxtsbRemoveSample;
		private System.Windows.Forms.ToolStripMenuItem ctxtsbAddStationImage;
		private System.Windows.Forms.ToolStripMenuItem ctxtsbRemoveStation;
		private System.Windows.Forms.ToolStripMenuItem tsbRemoveStation;
		private System.Windows.Forms.ToolStripMenuItem tsbDataToExcel;
		private System.Windows.Forms.ToolStripMenuItem tsbCreateAbundancesShapefiles;
		private System.Windows.Forms.ToolStripMenuItem tsbCompletePDF;
		private System.Windows.Forms.ContextMenuStrip cmsTreeView;
		private System.Windows.Forms.MenuStrip msMain;
		private System.Windows.Forms.ListView lstViewData;
		private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem removeCurrentSampleToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitProgramToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.SplitContainer splitContainer3;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ToolStripMenuItem uploadSamplesToStationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem photoSamplesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem existingProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem loadStationToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cameraStationsToolStripMenuItem;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripMenuItem newProjectToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem projectToolStripMenuItem;
	}
}
