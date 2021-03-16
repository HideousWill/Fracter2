namespace Fracter2.View
{
	partial class MeshEditorControlPanel
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
			this.OperationGroupBox = new System.Windows.Forms.GroupBox();
			this.TbdRadioButton = new System.Windows.Forms.RadioButton();
			this.StripsRadioButton = new System.Windows.Forms.RadioButton();
			this.PointsRadioButton = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.PanelToolTip = new System.Windows.Forms.ToolTip(this.components);
			this.ClearButton = new System.Windows.Forms.Button();
			this.OperationGroupBox.SuspendLayout();
			this.SuspendLayout();
			// 
			// OperationGroupBox
			// 
			this.OperationGroupBox.Controls.Add(this.TbdRadioButton);
			this.OperationGroupBox.Controls.Add(this.StripsRadioButton);
			this.OperationGroupBox.Controls.Add(this.PointsRadioButton);
			this.OperationGroupBox.Location = new System.Drawing.Point(3, 16);
			this.OperationGroupBox.Name = "OperationGroupBox";
			this.OperationGroupBox.Size = new System.Drawing.Size(91, 98);
			this.OperationGroupBox.TabIndex = 0;
			this.OperationGroupBox.TabStop = false;
			this.OperationGroupBox.Text = "Operation";
			// 
			// TbdRadioButton
			// 
			this.TbdRadioButton.AutoSize = true;
			this.TbdRadioButton.Location = new System.Drawing.Point(6, 65);
			this.TbdRadioButton.Name = "TbdRadioButton";
			this.TbdRadioButton.Size = new System.Drawing.Size(53, 17);
			this.TbdRadioButton.TabIndex = 2;
			this.TbdRadioButton.TabStop = true;
			this.TbdRadioButton.Text = "[TBD]";
			this.TbdRadioButton.UseVisualStyleBackColor = true;
			this.TbdRadioButton.CheckedChanged += new System.EventHandler(this.HandleRadioButtonChanged);
			// 
			// StripsRadioButton
			// 
			this.StripsRadioButton.AutoSize = true;
			this.StripsRadioButton.Location = new System.Drawing.Point(5, 42);
			this.StripsRadioButton.Name = "StripsRadioButton";
			this.StripsRadioButton.Size = new System.Drawing.Size(51, 17);
			this.StripsRadioButton.TabIndex = 1;
			this.StripsRadioButton.TabStop = true;
			this.StripsRadioButton.Text = "Strips";
			this.StripsRadioButton.UseVisualStyleBackColor = true;
			this.StripsRadioButton.CheckedChanged += new System.EventHandler(this.HandleRadioButtonChanged);
			// 
			// PointsRadioButton
			// 
			this.PointsRadioButton.AutoSize = true;
			this.PointsRadioButton.Checked = true;
			this.PointsRadioButton.Location = new System.Drawing.Point(5, 19);
			this.PointsRadioButton.Name = "PointsRadioButton";
			this.PointsRadioButton.Size = new System.Drawing.Size(54, 17);
			this.PointsRadioButton.TabIndex = 0;
			this.PointsRadioButton.TabStop = true;
			this.PointsRadioButton.Text = "Points";
			this.PanelToolTip.SetToolTip(this.PointsRadioButton, "Add:        Shift-Click\r\nRemove: Ctl-Click\r\nMove:      Click-Drag");
			this.PointsRadioButton.UseVisualStyleBackColor = true;
			this.PointsRadioButton.CheckedChanged += new System.EventHandler(this.HandleRadioButtonChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.SystemColors.ControlDark;
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Location = new System.Drawing.Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(169, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Mesh Editor";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// ClearButton
			// 
			this.ClearButton.Location = new System.Drawing.Point(4, 189);
			this.ClearButton.Name = "ClearButton";
			this.ClearButton.Size = new System.Drawing.Size(75, 23);
			this.ClearButton.TabIndex = 2;
			this.ClearButton.Text = "Clear";
			this.ClearButton.UseVisualStyleBackColor = true;
			this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
			// 
			// MeshEditorControlPanel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.ClearButton);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.OperationGroupBox);
			this.Name = "MeshEditorControlPanel";
			this.Size = new System.Drawing.Size(169, 215);
			this.OperationGroupBox.ResumeLayout(false);
			this.OperationGroupBox.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox OperationGroupBox;
		private System.Windows.Forms.RadioButton TbdRadioButton;
		private System.Windows.Forms.RadioButton StripsRadioButton;
		private System.Windows.Forms.RadioButton PointsRadioButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolTip PanelToolTip;
		private System.Windows.Forms.Button ClearButton;
	}
}
