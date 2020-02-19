namespace GlobalLogic_Test_Task
{
    partial class Form1
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
            this.btn_choose_folder = new System.Windows.Forms.Button();
            this.label_if_success = new System.Windows.Forms.Label();
            this.textBox_input = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_choose_folder
            // 
            this.btn_choose_folder.Location = new System.Drawing.Point(320, 168);
            this.btn_choose_folder.Name = "btn_choose_folder";
            this.btn_choose_folder.Size = new System.Drawing.Size(149, 28);
            this.btn_choose_folder.TabIndex = 0;
            this.btn_choose_folder.Text = "Choose folder";
            this.btn_choose_folder.UseVisualStyleBackColor = true;
            this.btn_choose_folder.Click += new System.EventHandler(this.btn_choose_folder_Click);
            // 
            // label_if_success
            // 
            this.label_if_success.AutoSize = true;
            this.label_if_success.Location = new System.Drawing.Point(317, 219);
            this.label_if_success.Name = "label_if_success";
            this.label_if_success.Size = new System.Drawing.Size(0, 17);
            this.label_if_success.TabIndex = 1;
            // 
            // textBox_input
            // 
            this.textBox_input.Location = new System.Drawing.Point(124, 95);
            this.textBox_input.Name = "textBox_input";
            this.textBox_input.ReadOnly = true;
            this.textBox_input.Size = new System.Drawing.Size(664, 22);
            this.textBox_input.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Input folder:";
            // 
            // textBox_output
            // 
            this.textBox_output.Location = new System.Drawing.Point(124, 279);
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.ReadOnly = true;
            this.textBox_output.Size = new System.Drawing.Size(664, 22);
            this.textBox_output.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Output file:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_input);
            this.Controls.Add(this.label_if_success);
            this.Controls.Add(this.btn_choose_folder);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_choose_folder;
        private System.Windows.Forms.Label label_if_success;
        private System.Windows.Forms.TextBox textBox_input;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.Label label2;
    }
}

