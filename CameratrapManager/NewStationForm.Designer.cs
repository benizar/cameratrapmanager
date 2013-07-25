/*
 * Creado por SharpDevelop.
 * Usuario: BENITO
 * Fecha: 25/05/2011
 * Hora: 14:25
 * 
 * Para cambiar esta plantilla use Herramientas | Opciones | Codificación | Editar Encabezados Estándar
 */
namespace CameratrapManager
{
	partial class NewStationForm
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
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtMainPicture = new System.Windows.Forms.TextBox();
			this.btSelectMainPicture = new System.Windows.Forms.Button();
			this.btCancelStation = new System.Windows.Forms.Button();
			this.btCreateStation = new System.Windows.Forms.Button();
			this.txtStationID = new System.Windows.Forms.TextBox();
			this.txtWKT = new System.Windows.Forms.TextBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtWKT);
			this.groupBox1.Controls.Add(this.txtStationID);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtMainPicture);
			this.groupBox1.Controls.Add(this.btSelectMainPicture);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(438, 157);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Define a new station";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(11, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 18);
			this.label2.TabIndex = 5;
			this.label2.Text = "WKT Polygon:";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(11, 34);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Station ID:";
			// 
			// txtMainPicture
			// 
			this.txtMainPicture.Location = new System.Drawing.Point(117, 110);
			this.txtMainPicture.Name = "txtMainPicture";
			this.txtMainPicture.Size = new System.Drawing.Size(315, 20);
			this.txtMainPicture.TabIndex = 3;
			// 
			// btSelectMainPicture
			// 
			this.btSelectMainPicture.Location = new System.Drawing.Point(6, 102);
			this.btSelectMainPicture.Name = "btSelectMainPicture";
			this.btSelectMainPicture.Size = new System.Drawing.Size(105, 34);
			this.btSelectMainPicture.TabIndex = 1;
			this.btSelectMainPicture.Text = "Select Main Picture";
			this.btSelectMainPicture.UseVisualStyleBackColor = true;
			this.btSelectMainPicture.Click += new System.EventHandler(this.BtSelectMainPictureClick);
			// 
			// btCancelStation
			// 
			this.btCancelStation.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btCancelStation.Location = new System.Drawing.Point(245, 175);
			this.btCancelStation.Name = "btCancelStation";
			this.btCancelStation.Size = new System.Drawing.Size(95, 35);
			this.btCancelStation.TabIndex = 5;
			this.btCancelStation.Text = "Cancel";
			this.btCancelStation.UseVisualStyleBackColor = true;
			this.btCancelStation.Click += new System.EventHandler(this.BtCancelStationClick);
			// 
			// btCreateStation
			// 
			this.btCreateStation.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btCreateStation.Location = new System.Drawing.Point(355, 175);
			this.btCreateStation.Name = "btCreateStation";
			this.btCreateStation.Size = new System.Drawing.Size(95, 35);
			this.btCreateStation.TabIndex = 4;
			this.btCreateStation.Text = "Create Station";
			this.btCreateStation.UseVisualStyleBackColor = true;
			this.btCreateStation.Click += new System.EventHandler(this.BtCreateStationClick);
			// 
			// txtStationID
			// 
			this.txtStationID.Location = new System.Drawing.Point(116, 34);
			this.txtStationID.Name = "txtStationID";
			this.txtStationID.Size = new System.Drawing.Size(315, 20);
			this.txtStationID.TabIndex = 6;
			// 
			// txtWKT
			// 
			this.txtWKT.Location = new System.Drawing.Point(116, 65);
			this.txtWKT.Name = "txtWKT";
			this.txtWKT.Size = new System.Drawing.Size(315, 20);
			this.txtWKT.TabIndex = 7;
			// 
			// NewStationForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(464, 224);
			this.Controls.Add(this.btCancelStation);
			this.Controls.Add(this.btCreateStation);
			this.Controls.Add(this.groupBox1);
			this.Name = "NewStationForm";
			this.Text = "NewStationForm";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TextBox txtStationID;
		private System.Windows.Forms.TextBox txtWKT;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btCreateStation;
		private System.Windows.Forms.Button btCancelStation;
		private System.Windows.Forms.Button btSelectMainPicture;
		private System.Windows.Forms.TextBox txtMainPicture;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
