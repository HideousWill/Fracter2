namespace Fracter2.View
{
	partial class LayerLegendItem
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
			this.MyButton = new System.Windows.Forms.Button();
			this.MyCheckbox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// MyButton
			// 
			this.MyButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.MyButton.Location = new System.Drawing.Point(0, 0);
			this.MyButton.Name = "MyButton";
			this.MyButton.Size = new System.Drawing.Size(100, 23);
			this.MyButton.TabIndex = 0;
			this.MyButton.UseVisualStyleBackColor = true;
			// 
			// MyCheckbox
			// 
			this.MyCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.MyCheckbox.AutoSize = true;
			this.MyCheckbox.Location = new System.Drawing.Point(106, 5);
			this.MyCheckbox.Name = "MyCheckbox";
			this.MyCheckbox.Size = new System.Drawing.Size(15, 14);
			this.MyCheckbox.TabIndex = 1;
			this.MyCheckbox.UseVisualStyleBackColor = true;
			// 
			// LayerButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.MyCheckbox);
			this.Controls.Add(this.MyButton);
			this.Name = "LayerLegendItem";
			this.Size = new System.Drawing.Size(126, 23);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button MyButton;
		private System.Windows.Forms.CheckBox MyCheckbox;
	}
}
