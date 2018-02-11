namespace ServerPicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.localhost = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // localhost
            // 
            this.localhost.Location = new System.Drawing.Point(19, 46);
            this.localhost.Name = "localhost";
            this.localhost.Size = new System.Drawing.Size(87, 44);
            this.localhost.TabIndex = 0;
            this.localhost.Text = "localhost";
            this.localhost.UseVisualStyleBackColor = true;
            this.localhost.Click += new System.EventHandler(this.Apply_Click_LocalHost);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLabel.Location = new System.Drawing.Point(8, 381);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(98, 20);
            this.resultLabel.TabIndex = 1;
            this.resultLabel.Text = "resultLabel";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Local";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(163, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "AL_*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(313, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Staging";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(464, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Prod";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 46);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 44);
            this.button1.TabIndex = 6;
            this.button1.Text = "AL_15";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Apply_Click_AL_15);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(307, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(87, 44);
            this.button2.TabIndex = 7;
            this.button2.Text = "STG_1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Apply_Click_Stg_1);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(452, 46);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 44);
            this.button3.TabIndex = 8;
            this.button3.Text = "Prod";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Apply_Click_Prod);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(146, 113);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(87, 44);
            this.button4.TabIndex = 9;
            this.button4.Text = "AL_13";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Apply_Click_AL_13);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(146, 185);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(87, 44);
            this.button5.TabIndex = 10;
            this.button5.Text = "AL_7";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Apply_Click_AL_7);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(146, 256);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(87, 44);
            this.button6.TabIndex = 11;
            this.button6.Text = "AL_19";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.Apply_Click_AL_19);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(146, 329);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(87, 44);
            this.button7.TabIndex = 12;
            this.button7.Text = "AL_21";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.Apply_Click_AL_21);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(307, 185);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(87, 44);
            this.button8.TabIndex = 13;
            this.button8.Text = "STG_3";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.Apply_Click_Stg_3);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(307, 113);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(87, 44);
            this.button9.TabIndex = 14;
            this.button9.Text = "STG_2";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.Apply_Click_Stg_2);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 410);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.localhost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "ServerPicker@SeaRos";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button localhost;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
    }
}

