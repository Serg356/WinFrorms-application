namespace Kursach
{
    partial class ArithmeticCodingForm
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
            this.components = new System.ComponentModel.Container();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.zoomButtonsToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.increaseSizeButton = new System.Windows.Forms.Button();
            this.decreaseSizeButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancleButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.inputTextTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.drawingPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // increaseSizeButton
            // 
            this.increaseSizeButton.Image = global::Kursach.Properties.Resources.zoom_in_32x32_;
            this.increaseSizeButton.Location = new System.Drawing.Point(494, 11);
            this.increaseSizeButton.Name = "increaseSizeButton";
            this.increaseSizeButton.Size = new System.Drawing.Size(43, 44);
            this.increaseSizeButton.TabIndex = 1;
            this.zoomButtonsToolTip.SetToolTip(this.increaseSizeButton, "Ctrl +");
            this.increaseSizeButton.UseVisualStyleBackColor = true;
            this.increaseSizeButton.Click += new System.EventHandler(this.increaseSizeButton_Click);
            // 
            // decreaseSizeButton
            // 
            this.decreaseSizeButton.Image = global::Kursach.Properties.Resources.zoom_out_32x32_;
            this.decreaseSizeButton.Location = new System.Drawing.Point(445, 11);
            this.decreaseSizeButton.Name = "decreaseSizeButton";
            this.decreaseSizeButton.Size = new System.Drawing.Size(43, 44);
            this.decreaseSizeButton.TabIndex = 2;
            this.zoomButtonsToolTip.SetToolTip(this.decreaseSizeButton, "Ctrl -");
            this.decreaseSizeButton.UseVisualStyleBackColor = true;
            this.decreaseSizeButton.Click += new System.EventHandler(this.decreaseSizeButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(365, 620);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(204, 41);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancleButton
            // 
            this.cancleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancleButton.Location = new System.Drawing.Point(660, 620);
            this.cancleButton.Name = "cancleButton";
            this.cancleButton.Size = new System.Drawing.Size(204, 41);
            this.cancleButton.TabIndex = 2;
            this.cancleButton.Text = "Отмена";
            this.cancleButton.UseVisualStyleBackColor = true;
            this.cancleButton.Click += new System.EventHandler(this.cancleButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.listBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "ef33fe",
            "889",
            "cwedscd",
            "d",
            "dsc",
            "",
            "cd",
            "d",
            "s",
            "d",
            "ds",
            "d",
            "d",
            "ds",
            "",
            "",
            "d"});
            this.listBox1.Location = new System.Drawing.Point(0, 288);
            this.listBox1.Margin = new System.Windows.Forms.Padding(4);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(628, 312);
            this.listBox1.TabIndex = 0;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(421, 277);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 3;
            // 
            // drawingPanel
            // 
            this.drawingPanel.AutoScroll = true;
            this.drawingPanel.AutoSize = true;
            this.drawingPanel.Controls.Add(this.decreaseSizeButton);
            this.drawingPanel.Controls.Add(this.increaseSizeButton);
            this.drawingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingPanel.Location = new System.Drawing.Point(0, 0);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(628, 288);
            this.drawingPanel.TabIndex = 4;
            this.drawingPanel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.zoomPanel_Scroll);
            this.drawingPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.drawingPanel_Paint);
            this.drawingPanel.Resize += new System.EventHandler(this.drawingPanel_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.AutoScroll = true;
            this.splitContainer1.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel1.Controls.Add(this.drawingPanel);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.listBox1);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.splitContainer1.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel1_Paint);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer1.Panel2.Controls.Add(this.inputTextTextBox);
            this.splitContainer1.Size = new System.Drawing.Size(1206, 602);
            this.splitContainer1.SplitterDistance = 630;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 0;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "\"Текстовые файлы (*.txt)|*.txt|\"Закодированные файлы (*.arch)|*.arch";
            // 
            // inputTextTextBox
            // 
            this.inputTextTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.inputTextTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.inputTextTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputTextTextBox.Location = new System.Drawing.Point(0, 0);
            this.inputTextTextBox.Multiline = true;
            this.inputTextTextBox.Name = "inputTextTextBox";
            this.inputTextTextBox.ReadOnly = true;
            this.inputTextTextBox.Size = new System.Drawing.Size(568, 600);
            this.inputTextTextBox.TabIndex = 1;
            // 
            // ArithmeticCodingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1207, 681);
            this.Controls.Add(this.cancleButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ArithmeticCodingForm";
            this.Text = "ArithmeticCodingForm";
            this.Load += new System.EventHandler(this.ArithmeticCodingForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ArithmeticCodingForm_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.drawingPanel.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.ToolTip zoomButtonsToolTip;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancleButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel drawingPanel;
        private System.Windows.Forms.Button decreaseSizeButton;
        private System.Windows.Forms.Button increaseSizeButton;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.TextBox inputTextTextBox;
    }
}