
namespace TransBitmap.Forms
{
    partial class ConvertSettingDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboFromRed = new System.Windows.Forms.ComboBox();
            this.comboFromGreen = new System.Windows.Forms.ComboBox();
            this.comboFromBlue = new System.Windows.Forms.ComboBox();
            this.checkReverseRed = new System.Windows.Forms.CheckBox();
            this.checkReverseGreen = new System.Windows.Forms.CheckBox();
            this.checkReverseBlue = new System.Windows.Forms.CheckBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboFromRed, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboFromGreen, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboFromBlue, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkReverseRed, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkReverseGreen, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.checkReverseBlue, 3, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(283, 102);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Red";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Green";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Blue";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "←";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(57, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(24, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "←";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 75);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "←";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // comboFromRed
            // 
            this.comboFromRed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboFromRed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFromRed.FormattingEnabled = true;
            this.comboFromRed.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.comboFromRed.Location = new System.Drawing.Point(87, 3);
            this.comboFromRed.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.comboFromRed.Name = "comboFromRed";
            this.comboFromRed.Size = new System.Drawing.Size(121, 28);
            this.comboFromRed.TabIndex = 6;
            // 
            // comboFromGreen
            // 
            this.comboFromGreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboFromGreen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFromGreen.FormattingEnabled = true;
            this.comboFromGreen.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.comboFromGreen.Location = new System.Drawing.Point(87, 37);
            this.comboFromGreen.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.comboFromGreen.Name = "comboFromGreen";
            this.comboFromGreen.Size = new System.Drawing.Size(121, 28);
            this.comboFromGreen.TabIndex = 7;
            // 
            // comboFromBlue
            // 
            this.comboFromBlue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboFromBlue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboFromBlue.FormattingEnabled = true;
            this.comboFromBlue.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.comboFromBlue.Location = new System.Drawing.Point(87, 71);
            this.comboFromBlue.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.comboFromBlue.Name = "comboFromBlue";
            this.comboFromBlue.Size = new System.Drawing.Size(121, 28);
            this.comboFromBlue.TabIndex = 8;
            // 
            // checkReverseRed
            // 
            this.checkReverseRed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkReverseRed.AutoSize = true;
            this.checkReverseRed.Location = new System.Drawing.Point(219, 5);
            this.checkReverseRed.Name = "checkReverseRed";
            this.checkReverseRed.Size = new System.Drawing.Size(61, 24);
            this.checkReverseRed.TabIndex = 9;
            this.checkReverseRed.Text = "反転";
            this.checkReverseRed.UseVisualStyleBackColor = true;
            // 
            // checkReverseGreen
            // 
            this.checkReverseGreen.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkReverseGreen.AutoSize = true;
            this.checkReverseGreen.Location = new System.Drawing.Point(219, 39);
            this.checkReverseGreen.Name = "checkReverseGreen";
            this.checkReverseGreen.Size = new System.Drawing.Size(61, 24);
            this.checkReverseGreen.TabIndex = 10;
            this.checkReverseGreen.Text = "反転";
            this.checkReverseGreen.UseVisualStyleBackColor = true;
            // 
            // checkReverseBlue
            // 
            this.checkReverseBlue.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkReverseBlue.AutoSize = true;
            this.checkReverseBlue.Location = new System.Drawing.Point(219, 73);
            this.checkReverseBlue.Name = "checkReverseBlue";
            this.checkReverseBlue.Size = new System.Drawing.Size(61, 24);
            this.checkReverseBlue.TabIndex = 11;
            this.checkReverseBlue.Text = "反転";
            this.checkReverseBlue.UseVisualStyleBackColor = true;
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(101, 125);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(94, 29);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(201, 125);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 3);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(94, 29);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // ConvertSettingDialog
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(307, 166);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConvertSettingDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "変換設定";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboFromRed;
        private System.Windows.Forms.ComboBox comboFromGreen;
        private System.Windows.Forms.ComboBox comboFromBlue;
        private System.Windows.Forms.CheckBox checkReverseRed;
        private System.Windows.Forms.CheckBox checkReverseGreen;
        private System.Windows.Forms.CheckBox checkReverseBlue;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}