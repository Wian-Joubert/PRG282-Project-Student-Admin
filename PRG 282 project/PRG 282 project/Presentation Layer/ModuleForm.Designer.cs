namespace PRG_282_project.Presentation_Layer
{
    partial class ModuleForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            button2 = new Button();
            button3 = new Button();
            textBox3 = new TextBox();
            button4 = new Button();
            label6 = new Label();
            dataGridView1 = new DataGridView();
            button5 = new Button();
            button6 = new Button();
            richTextBox2 = new RichTextBox();
            button7 = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(17, 9);
            label1.Name = "label1";
            label1.Size = new Size(379, 54);
            label1.TabIndex = 0;
            label1.Text = "Module Information";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(550, 74);
            label2.Name = "label2";
            label2.Size = new Size(196, 32);
            label2.TabIndex = 1;
            label2.Text = "Links to Modules";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(17, 141);
            label3.Name = "label3";
            label3.Size = new Size(155, 32);
            label3.TabIndex = 2;
            label3.Text = "Module Desc";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(17, 74);
            label4.Name = "label4";
            label4.Size = new Size(168, 32);
            label4.TabIndex = 3;
            label4.Text = "Module Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(17, 107);
            label5.Name = "label5";
            label5.Size = new Size(160, 32);
            label5.TabIndex = 4;
            label5.Text = "Module Code";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(196, 81);
            textBox1.Margin = new Padding(3, 4, 3, 4);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(347, 27);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(196, 114);
            textBox2.Margin = new Padding(3, 4, 3, 4);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 6;
            // 
            // button1
            // 
            button1.Location = new Point(334, 304);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(115, 46);
            button1.TabIndex = 9;
            button1.Text = "CREATE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(197, 148);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(346, 120);
            richTextBox1.TabIndex = 7;
            richTextBox1.Text = "";
            // 
            // button2
            // 
            button2.Location = new Point(455, 304);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(115, 46);
            button2.TabIndex = 11;
            button2.Text = "UPDATE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(576, 304);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(115, 46);
            button3.TabIndex = 12;
            button3.Text = "DELETE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(12, 323);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(177, 27);
            textBox3.TabIndex = 13;
            // 
            // button4
            // 
            button4.Location = new Point(195, 324);
            button4.Margin = new Padding(3, 4, 3, 4);
            button4.Name = "button4";
            button4.Size = new Size(85, 26);
            button4.TabIndex = 14;
            button4.Text = "SEARCH";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(12, 283);
            label6.Name = "label6";
            label6.Size = new Size(275, 32);
            label6.TabIndex = 15;
            label6.Text = "Search for Module Code";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 364);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(674, 280);
            dataGridView1.TabIndex = 16;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            // 
            // button5
            // 
            button5.Location = new Point(697, 547);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(115, 44);
            button5.TabIndex = 17;
            button5.Text = "RESET TABLE";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Location = new Point(697, 599);
            button6.Margin = new Padding(3, 4, 3, 4);
            button6.Name = "button6";
            button6.Size = new Size(115, 44);
            button6.TabIndex = 18;
            button6.Text = "RETURN";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point);
            richTextBox2.ForeColor = SystemColors.MenuHighlight;
            richTextBox2.Location = new Point(550, 114);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(262, 154);
            richTextBox2.TabIndex = 8;
            richTextBox2.Text = "";
            // 
            // button7
            // 
            button7.Location = new Point(697, 494);
            button7.Name = "button7";
            button7.Size = new Size(115, 46);
            button7.TabIndex = 16;
            button7.Text = "RESET FIELDS";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(334, 119);
            label7.Name = "label7";
            label7.Size = new Size(99, 20);
            label7.TabIndex = 21;
            label7.Text = "Textbox State";
            label7.Visible = false;
            // 
            // ModuleForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 656);
            Controls.Add(label7);
            Controls.Add(button7);
            Controls.Add(richTextBox2);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(dataGridView1);
            Controls.Add(label6);
            Controls.Add(button4);
            Controls.Add(textBox3);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(richTextBox1);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ModuleForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModuleForm";
            FormClosed += ModuleForm_FormClosed;
            Load += ModuleForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private RichTextBox richTextBox1;
        private Button button2;
        private Button button3;
        private TextBox textBox3;
        private Button button4;
        private Label label6;
        private DataGridView dataGridView1;
        private Button button5;
        private Button button6;
        private RichTextBox richTextBox2;
        private Button button7;
        private Label label7;
    }
}