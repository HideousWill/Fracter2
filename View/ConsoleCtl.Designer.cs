namespace Fracter2.View
{
	partial class ConsoleCtl
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
			this.TheText = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// TheText
			// 
			this.TheText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TheText.BackColor = System.Drawing.SystemColors.ControlDark;
			this.TheText.Location = new System.Drawing.Point(0, 0);
			this.TheText.Name = "TheText";
			this.TheText.ReadOnly = true;
			this.TheText.Size = new System.Drawing.Size(536, 348);
			this.TheText.TabIndex = 0;
			this.TheText.Text = "";
			// 
			// ConsoleCtl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.TheText);
			this.Name = "ConsoleCtl";
			this.Size = new System.Drawing.Size(536, 348);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.RichTextBox TheText;
	}
}
