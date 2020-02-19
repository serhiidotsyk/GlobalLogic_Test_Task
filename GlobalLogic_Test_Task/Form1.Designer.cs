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
            this.SuspendLayout();
            // 
            // btn_choose_folder
            // 
            this.btn_choose_folder.Location = new System.Drawing.Point(311, 159);
            this.btn_choose_folder.Name = "btn_choose_folder";
            this.btn_choose_folder.Size = new System.Drawing.Size(149, 74);
            this.btn_choose_folder.TabIndex = 0;
            this.btn_choose_folder.Text = "Choose folder";
            this.btn_choose_folder.UseVisualStyleBackColor = true;
            this.btn_choose_folder.Click += new System.EventHandler(this.btn_choose_folder_Click);
            // 
            // label_if_success
            // 
            this.label_if_success.AutoSize = true;
            this.label_if_success.Location = new System.Drawing.Point(349, 295);
            this.label_if_success.Name = "label_if_success";
            this.label_if_success.Size = new System.Drawing.Size(67, 17);
            this.label_if_success.TabIndex = 1;
            this.label_if_success.Text = "Waiting...";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
    }
}

