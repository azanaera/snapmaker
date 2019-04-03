namespace Snapshot_Maker
{
    partial class SnapshotForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timeBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.sfdPicture = new System.Windows.Forms.SaveFileDialog();
            this.ofdPicture = new System.Windows.Forms.OpenFileDialog();
            this.picCropped = new System.Windows.Forms.PictureBox();
            this.Reset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(13, 12);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(100, 28);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "&Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(147, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Snapshot time:";
            // 
            // timeBox
            // 
            this.timeBox.Location = new System.Drawing.Point(253, 15);
            this.timeBox.Margin = new System.Windows.Forms.Padding(4);
            this.timeBox.Name = "timeBox";
            this.timeBox.ReadOnly = true;
            this.timeBox.Size = new System.Drawing.Size(199, 22);
            this.timeBox.TabIndex = 3;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "JPEG images (*.jpg)|*.jpg|PNG images (*.png)|*.png|BMP images (*.bmp)|*.bmp";
            this.saveFileDialog.Title = "Save snapshot";
            // 
            // ofdPicture
            // 
            this.ofdPicture.FileName = "openFileDialog1";
            // 
            // picCropped
            // 
            this.picCropped.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picCropped.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCropped.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picCropped.Location = new System.Drawing.Point(13, 48);
            this.picCropped.Margin = new System.Windows.Forms.Padding(4);
            this.picCropped.Name = "picCropped";
            this.picCropped.Size = new System.Drawing.Size(579, 363);
            this.picCropped.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picCropped.TabIndex = 4;
            this.picCropped.TabStop = false;
            this.picCropped.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picCropped_MouseDown);
            this.picCropped.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picCropped_MouseMove);
            this.picCropped.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picCropped_MouseUp);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(650, 12);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(123, 30);
            this.Reset.TabIndex = 5;
            this.Reset.Text = "button1";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.mnuPictureReset_Click);
            // 
            // SnapshotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 423);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.picCropped);
            this.Controls.Add(this.timeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.saveButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SnapshotForm";
            this.Text = "Snapshot";
            ((System.ComponentModel.ISupportInitialize)(this.picCropped)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox timeBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.SaveFileDialog sfdPicture;
        private System.Windows.Forms.OpenFileDialog ofdPicture;
        private System.Windows.Forms.PictureBox picCropped;
        private System.Windows.Forms.Button Reset;
    }
}