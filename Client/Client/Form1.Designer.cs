namespace Client
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.grOption = new System.Windows.Forms.GroupBox();
            this.rbShutdown = new System.Windows.Forms.RadioButton();
            this.rbRestart = new System.Windows.Forms.RadioButton();
            this.rbLogoff = new System.Windows.Forms.RadioButton();
            this.rbSleep = new System.Windows.Forms.RadioButton();
            this.grOption.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port:";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(156, 30);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(153, 20);
            this.txtAddress.TabIndex = 2;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(156, 62);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(153, 20);
            this.txtPort.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(193, 284);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(116, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "Connect&&Send";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // grOption
            // 
            this.grOption.Controls.Add(this.rbShutdown);
            this.grOption.Controls.Add(this.rbRestart);
            this.grOption.Controls.Add(this.rbLogoff);
            this.grOption.Controls.Add(this.rbSleep);
            this.grOption.Location = new System.Drawing.Point(82, 106);
            this.grOption.Name = "grOption";
            this.grOption.Size = new System.Drawing.Size(234, 162);
            this.grOption.TabIndex = 5;
            this.grOption.TabStop = false;
            this.grOption.Text = "Option";
            // 
            // rbShutdown
            // 
            this.rbShutdown.AutoSize = true;
            this.rbShutdown.Location = new System.Drawing.Point(39, 122);
            this.rbShutdown.Name = "rbShutdown";
            this.rbShutdown.Size = new System.Drawing.Size(76, 17);
            this.rbShutdown.TabIndex = 3;
            this.rbShutdown.TabStop = true;
            this.rbShutdown.Text = "Shut down";
            this.rbShutdown.UseVisualStyleBackColor = true;
            // 
            // rbRestart
            // 
            this.rbRestart.AutoSize = true;
            this.rbRestart.Location = new System.Drawing.Point(39, 90);
            this.rbRestart.Name = "rbRestart";
            this.rbRestart.Size = new System.Drawing.Size(59, 17);
            this.rbRestart.TabIndex = 2;
            this.rbRestart.TabStop = true;
            this.rbRestart.Text = "Restart";
            this.rbRestart.UseVisualStyleBackColor = true;
            // 
            // rbLogoff
            // 
            this.rbLogoff.AutoSize = true;
            this.rbLogoff.Location = new System.Drawing.Point(39, 58);
            this.rbLogoff.Name = "rbLogoff";
            this.rbLogoff.Size = new System.Drawing.Size(58, 17);
            this.rbLogoff.TabIndex = 1;
            this.rbLogoff.TabStop = true;
            this.rbLogoff.Text = "Log off";
            this.rbLogoff.UseVisualStyleBackColor = true;
            // 
            // rbSleep
            // 
            this.rbSleep.AutoSize = true;
            this.rbSleep.Checked = true;
            this.rbSleep.Location = new System.Drawing.Point(39, 26);
            this.rbSleep.Name = "rbSleep";
            this.rbSleep.Size = new System.Drawing.Size(52, 17);
            this.rbSleep.TabIndex = 0;
            this.rbSleep.TabStop = true;
            this.rbSleep.Text = "Sleep";
            this.rbSleep.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 322);
            this.Controls.Add(this.grOption);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Client";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grOption.ResumeLayout(false);
            this.grOption.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grOption;
        private System.Windows.Forms.RadioButton rbShutdown;
        private System.Windows.Forms.RadioButton rbRestart;
        private System.Windows.Forms.RadioButton rbLogoff;
        private System.Windows.Forms.RadioButton rbSleep;
    }
}

