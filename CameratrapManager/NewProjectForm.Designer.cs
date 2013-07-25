/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 24/05/2011
 * Hora: 19:21
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace CameratrapManager
{
	partial class NewProjectForm
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
			this.txtProjectName = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btLoadSHP = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.txtProjectDescription = new System.Windows.Forms.TextBox();
			this.txtProjectSubject = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtProjectCreator = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cmbProjectType = new System.Windows.Forms.ComboBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btCreateProject = new System.Windows.Forms.Button();
			this.btCancelProject = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtGridSize = new System.Windows.Forms.MaskedTextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtProjectName
			// 
			this.txtProjectName.Location = new System.Drawing.Point(89, 19);
			this.txtProjectName.Name = "txtProjectName";
			this.txtProjectName.Size = new System.Drawing.Size(315, 20);
			this.txtProjectName.TabIndex = 0;
			this.txtProjectName.Text = "New Project";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtGridSize);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.btLoadSHP);
			this.groupBox1.Controls.Add(this.textBox1);
			this.groupBox1.Controls.Add(this.txtProjectDescription);
			this.groupBox1.Controls.Add(this.txtProjectSubject);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtProjectCreator);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.cmbProjectType);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtProjectName);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(457, 466);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Project Metadata (all required)";
			// 
			// btLoadSHP
			// 
			this.btLoadSHP.Location = new System.Drawing.Point(8, 45);
			this.btLoadSHP.Name = "btLoadSHP";
			this.btLoadSHP.Size = new System.Drawing.Size(77, 35);
			this.btLoadSHP.TabIndex = 11;
			this.btLoadSHP.Text = "Load Shapefile";
			this.btLoadSHP.UseVisualStyleBackColor = true;
			this.btLoadSHP.Click += new System.EventHandler(this.BtLoadSHPClick);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(89, 53);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(315, 20);
			this.textBox1.TabIndex = 10;
			this.textBox1.Text = "Load the Study Area Shapefile";
			// 
			// txtProjectDescription
			// 
			this.txtProjectDescription.Location = new System.Drawing.Point(89, 253);
			this.txtProjectDescription.Multiline = true;
			this.txtProjectDescription.Name = "txtProjectDescription";
			this.txtProjectDescription.Size = new System.Drawing.Size(354, 207);
			this.txtProjectDescription.TabIndex = 9;
			this.txtProjectDescription.Text = "Intento crear una aplicación que hace muchas cosas";
			// 
			// txtProjectSubject
			// 
			this.txtProjectSubject.Location = new System.Drawing.Point(89, 169);
			this.txtProjectSubject.Multiline = true;
			this.txtProjectSubject.Name = "txtProjectSubject";
			this.txtProjectSubject.Size = new System.Drawing.Size(354, 78);
			this.txtProjectSubject.TabIndex = 8;
			this.txtProjectSubject.Text = "Proyecto de pruebas";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 288);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(77, 24);
			this.label5.TabIndex = 7;
			this.label5.Text = "Description:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 180);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(77, 24);
			this.label4.TabIndex = 6;
			this.label4.Text = "Subject:";
			// 
			// txtProjectCreator
			// 
			this.txtProjectCreator.Location = new System.Drawing.Point(89, 143);
			this.txtProjectCreator.Name = "txtProjectCreator";
			this.txtProjectCreator.Size = new System.Drawing.Size(315, 20);
			this.txtProjectCreator.TabIndex = 5;
			this.txtProjectCreator.Text = "Benito Zaragozi";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 143);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "Creator:";
			// 
			// cmbProjectType
			// 
			this.cmbProjectType.FormattingEnabled = true;
			this.cmbProjectType.Items.AddRange(new object[] {
									"Abundance Project"});
			this.cmbProjectType.Location = new System.Drawing.Point(89, 116);
			this.cmbProjectType.Name = "cmbProjectType";
			this.cmbProjectType.Size = new System.Drawing.Size(161, 21);
			this.cmbProjectType.TabIndex = 3;
			this.cmbProjectType.Text = "AbundanceProject";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "Project Type:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 22);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 24);
			this.label1.TabIndex = 1;
			this.label1.Text = "Project Name:";
			// 
			// btCreateProject
			// 
			this.btCreateProject.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btCreateProject.Location = new System.Drawing.Point(360, 484);
			this.btCreateProject.Name = "btCreateProject";
			this.btCreateProject.Size = new System.Drawing.Size(95, 35);
			this.btCreateProject.TabIndex = 2;
			this.btCreateProject.Text = "Create Project";
			this.btCreateProject.UseVisualStyleBackColor = true;
			this.btCreateProject.Click += new System.EventHandler(this.BtCreateProjectClick);
			// 
			// btCancelProject
			// 
			this.btCancelProject.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancelProject.Location = new System.Drawing.Point(250, 484);
			this.btCancelProject.Name = "btCancelProject";
			this.btCancelProject.Size = new System.Drawing.Size(95, 35);
			this.btCancelProject.TabIndex = 3;
			this.btCancelProject.Text = "Cancel";
			this.btCancelProject.UseVisualStyleBackColor = true;
			this.btCancelProject.Click += new System.EventHandler(this.BtCancelProjectClick);
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(8, 89);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(77, 19);
			this.label6.TabIndex = 12;
			this.label6.Text = "Grid Size";
			// 
			// txtGridSize
			// 
			this.txtGridSize.Location = new System.Drawing.Point(89, 88);
			this.txtGridSize.Mask = "9999";
			this.txtGridSize.Name = "txtGridSize";
			this.txtGridSize.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.txtGridSize.Size = new System.Drawing.Size(63, 20);
			this.txtGridSize.TabIndex = 13;
			this.txtGridSize.Text = "2000";
			// 
			// NewProjectForm
			// 
			this.AcceptButton = this.btCreateProject;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btCancelProject;
			this.ClientSize = new System.Drawing.Size(482, 531);
			this.Controls.Add(this.btCancelProject);
			this.Controls.Add(this.btCreateProject);
			this.Controls.Add(this.groupBox1);
			this.Name = "NewProjectForm";
			this.Text = "NewProjectForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.MaskedTextBox txtGridSize;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btLoadSHP;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox txtProjectName;
		private System.Windows.Forms.ComboBox cmbProjectType;
		private System.Windows.Forms.TextBox txtProjectCreator;
		private System.Windows.Forms.TextBox txtProjectDescription;
		private System.Windows.Forms.TextBox txtProjectSubject;
		private System.Windows.Forms.Button btCancelProject;
		private System.Windows.Forms.Button btCreateProject;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
