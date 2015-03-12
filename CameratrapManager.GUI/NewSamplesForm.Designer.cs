/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 27/05/2011
 * Hora: 13:49
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace CameratrapManager
{
	partial class NewSamplesForm
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btSelectSamplesFolder = new System.Windows.Forms.Button();
			this.txtPicturesFolder = new System.Windows.Forms.TextBox();
			this.btCancelSamples = new System.Windows.Forms.Button();
			this.btCreateSamples = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btSelectSamplesFolder);
			this.groupBox1.Controls.Add(this.txtPicturesFolder);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(386, 86);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Select the folder containing all the current station pictures";
			// 
			// btSelectSamplesFolder
			// 
			this.btSelectSamplesFolder.Location = new System.Drawing.Point(6, 22);
			this.btSelectSamplesFolder.Name = "btSelectSamplesFolder";
			this.btSelectSamplesFolder.Size = new System.Drawing.Size(100, 32);
			this.btSelectSamplesFolder.TabIndex = 1;
			this.btSelectSamplesFolder.Text = "Select folder";
			this.btSelectSamplesFolder.UseVisualStyleBackColor = true;
			this.btSelectSamplesFolder.Click += new System.EventHandler(this.BtSelectSamplesFolderClick);
			// 
			// txtPicturesFolder
			// 
			this.txtPicturesFolder.Location = new System.Drawing.Point(112, 22);
			this.txtPicturesFolder.Name = "txtPicturesFolder";
			this.txtPicturesFolder.Size = new System.Drawing.Size(261, 20);
			this.txtPicturesFolder.TabIndex = 0;
			// 
			// btCancelSamples
			// 
			this.btCancelSamples.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancelSamples.Location = new System.Drawing.Point(192, 104);
			this.btCancelSamples.Name = "btCancelSamples";
			this.btCancelSamples.Size = new System.Drawing.Size(95, 35);
			this.btCancelSamples.TabIndex = 7;
			this.btCancelSamples.Text = "Cancel";
			this.btCancelSamples.UseVisualStyleBackColor = true;
			// 
			// btCreateSamples
			// 
			this.btCreateSamples.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btCreateSamples.Location = new System.Drawing.Point(302, 104);
			this.btCreateSamples.Name = "btCreateSamples";
			this.btCreateSamples.Size = new System.Drawing.Size(95, 35);
			this.btCreateSamples.TabIndex = 6;
			this.btCreateSamples.Text = "Import samples";
			this.btCreateSamples.UseVisualStyleBackColor = true;
			this.btCreateSamples.Click += new System.EventHandler(this.BtCreateSamplesClick);
			// 
			// NewSamplesForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(410, 162);
			this.Controls.Add(this.btCancelSamples);
			this.Controls.Add(this.btCreateSamples);
			this.Controls.Add(this.groupBox1);
			this.Name = "NewSamplesForm";
			this.Text = "NewSamplesForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button btCreateSamples;
		private System.Windows.Forms.Button btCancelSamples;
		private System.Windows.Forms.TextBox txtPicturesFolder;
		private System.Windows.Forms.Button btSelectSamplesFolder;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
