namespace Tetris
{
    partial class SharpGLForm
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
            this.openGLControl = new SharpGL.OpenGLControl();
            this.Scoore = new System.Windows.Forms.Label();
            this.Speed = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openGLControl.DrawFPS = false;
            this.openGLControl.FrameRate = 1000;
            this.openGLControl.Location = new System.Drawing.Point(0, 0);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL3_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(444, 402);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.OpenGLInitialized += new System.EventHandler(this.openGLControl_OpenGLInitialized);
            this.openGLControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGLControl_OpenGLDraw);
            this.openGLControl.Resized += new System.EventHandler(this.openGLControl_Resized);
            // 
            // Scoore
            // 
            this.Scoore.AutoSize = true;
            this.Scoore.BackColor = System.Drawing.Color.Gray;
            this.Scoore.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Scoore.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Scoore.Location = new System.Drawing.Point(334, 9);
            this.Scoore.Name = "Scoore";
            this.Scoore.Size = new System.Drawing.Size(76, 23);
            this.Scoore.TabIndex = 1;
            this.Scoore.Text = "Scoore";
            this.Scoore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Speed
            // 
            this.Speed.AutoSize = true;
            this.Speed.BackColor = System.Drawing.Color.Gray;
            this.Speed.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Speed.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Speed.Location = new System.Drawing.Point(332, 64);
            this.Speed.Name = "Speed";
            this.Speed.Size = new System.Drawing.Size(76, 23);
            this.Speed.TabIndex = 2;
            this.Speed.Text = "label1";
            this.Speed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SharpGLForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 402);
            this.Controls.Add(this.Speed);
            this.Controls.Add(this.Scoore);
            this.Controls.Add(this.openGLControl);
            this.KeyPreview = true;
            this.Name = "SharpGLForm";
            this.Text = "SharpGL Form";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SharpGLForm_FormClosed);
            this.Load += new System.EventHandler(this.SharpGLForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SharpGLForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Label Scoore;
        private System.Windows.Forms.Label Speed;
    }
}

