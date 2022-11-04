namespace ImageGlass {
    partial class frmPageSD {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.btnClose = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSnapTo = new System.Windows.Forms.Button();
            this.toolPageSD = new ImageGlass.UI.ModernToolbar();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSaveFav = new System.Windows.Forms.ToolStripButton();
            this.btnSaveNsfw = new System.Windows.Forms.ToolStripButton();
            this.btnShowDiff = new System.Windows.Forms.ToolStripButton();
            this.btnPrev = new System.Windows.Forms.ToolStripButton();
            this.btnNext = new System.Windows.Forms.ToolStripButton();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.toolPageSD.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.AutoSize = true;
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(15)))), ((int)(((byte)(29)))));
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(74)))), ((int)(((byte)(72)))));
            this.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(62)))), ((int)(((byte)(74)))));
            this.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(43)))), ((int)(((byte)(28)))));
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(449, 1);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(49, 27);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.ShowAlways = true;
            // 
            // btnSnapTo
            // 
            this.btnSnapTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSnapTo.AutoSize = true;
            this.btnSnapTo.BackColor = System.Drawing.Color.Teal;
            this.btnSnapTo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(74)))), ((int)(((byte)(72)))));
            this.btnSnapTo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSnapTo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.btnSnapTo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSnapTo.ForeColor = System.Drawing.Color.White;
            this.btnSnapTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSnapTo.Location = new System.Drawing.Point(399, 1);
            this.btnSnapTo.Name = "btnSnapTo";
            this.btnSnapTo.Size = new System.Drawing.Size(49, 27);
            this.btnSnapTo.TabIndex = 6;
            this.btnSnapTo.Text = "^";
            this.btnSnapTo.UseVisualStyleBackColor = false;
            // 
            // toolPageSD
            // 
            this.toolPageSD.Alignment = ImageGlass.UI.ToolbarAlignment.LEFT;
            this.toolPageSD.AllowMerge = false;
            this.toolPageSD.AutoFocus = true;
            this.toolPageSD.AutoSize = false;
            this.toolPageSD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(74)))), ((int)(((byte)(72)))));
            this.toolPageSD.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolPageSD.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolPageSD.HideTooltips = false;
            this.toolPageSD.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolPageSD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDelete,
            this.btnSaveFav,
            this.btnSaveNsfw,
            this.btnShowDiff,
            this.btnPrev,
            this.btnNext});
            this.toolPageSD.Location = new System.Drawing.Point(0, 84);
            this.toolPageSD.Name = "toolPageSD";
            this.toolPageSD.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolPageSD.ShowItemToolTips = false;
            this.toolPageSD.Size = new System.Drawing.Size(500, 43);
            this.toolPageSD.TabIndex = 8;
            this.toolPageSD.ToolTipShowUp = false;
            // 
            // btnDelete
            // 
            this.btnDelete.AutoSize = false;
            this.btnDelete.BackColor = System.Drawing.Color.Transparent;
            this.btnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDelete.Image = global::ImageGlass.Properties.Resources.info;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(33, 33);
            this.btnDelete.ToolTipText = "Delete and Next";
            // 
            // btnSaveFav
            // 
            this.btnSaveFav.AutoSize = false;
            this.btnSaveFav.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveFav.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveFav.Image = global::ImageGlass.Properties.Resources.info;
            this.btnSaveFav.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaveFav.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveFav.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSaveFav.Name = "btnSaveFav";
            this.btnSaveFav.Size = new System.Drawing.Size(33, 33);
            this.btnSaveFav.ToolTipText = "Move to Fav folder";
            // 
            // btnSaveNsfw
            // 
            this.btnSaveNsfw.AutoSize = false;
            this.btnSaveNsfw.BackColor = System.Drawing.Color.Transparent;
            this.btnSaveNsfw.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveNsfw.Image = global::ImageGlass.Properties.Resources.info;
            this.btnSaveNsfw.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSaveNsfw.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveNsfw.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnSaveNsfw.Name = "btnSaveNsfw";
            this.btnSaveNsfw.Size = new System.Drawing.Size(33, 33);
            this.btnSaveNsfw.ToolTipText = "Move to NSFW Folder";
            // 
            // btnShowDiff
            // 
            this.btnShowDiff.AutoSize = false;
            this.btnShowDiff.BackColor = System.Drawing.Color.Transparent;
            this.btnShowDiff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowDiff.Image = global::ImageGlass.Properties.Resources.info;
            this.btnShowDiff.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnShowDiff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowDiff.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnShowDiff.Name = "btnShowDiff";
            this.btnShowDiff.Size = new System.Drawing.Size(33, 33);
            this.btnShowDiff.ToolTipText = "Toggle ShowDiff";
            // 
            // btnPrev
            // 
            this.btnPrev.AutoSize = false;
            this.btnPrev.BackColor = System.Drawing.Color.Transparent;
            this.btnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrev.Image = global::ImageGlass.Properties.Resources.info;
            this.btnPrev.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrev.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(33, 33);
            this.btnPrev.ToolTipText = "Previous Pic";
            // 
            // btnNext
            // 
            this.btnNext.AutoSize = false;
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNext.Image = global::ImageGlass.Properties.Resources.info;
            this.btnNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNext.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(33, 33);
            this.btnNext.ToolTipText = "Next Pic";
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPageInfo.Location = new System.Drawing.Point(-2, 25);
            this.lblPageInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(502, 69);
            this.lblPageInfo.TabIndex = 9;
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFormTitle.AutoEllipsis = true;
            this.lblFormTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 4);
            this.lblFormTitle.Margin = new System.Windows.Forms.Padding(10, 0, 3, 0);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblFormTitle.Size = new System.Drawing.Size(393, 21);
            this.lblFormTitle.TabIndex = 28;
            this.lblFormTitle.Text = "Stable Diffusion Helper";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmPageSD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(74)))), ((int)(((byte)(72)))));
            this.ClientSize = new System.Drawing.Size(500, 127);
            this.Controls.Add(this.lblFormTitle);
            this.Controls.Add(this.toolPageSD);
            this.Controls.Add(this.lblPageInfo);
            this.Controls.Add(this.btnSnapTo);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(211, 80);
            this.Name = "frmPageSD";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SD Tools";
            this.Activated += new System.EventHandler(this.frmPageSD_Activated);
            this.Load += new System.EventHandler(this.frmPageSD_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmPageSD_KeyDown);
            this.toolPageSD.ResumeLayout(false);
            this.toolPageSD.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSnapTo;
        private ImageGlass.UI.ModernToolbar toolPageSD;
        private System.Windows.Forms.ToolStripButton btnSaveNsfw;
        private System.Windows.Forms.ToolStripButton btnSaveFav;
        private System.Windows.Forms.ToolStripButton btnDelete;
        private System.Windows.Forms.ToolStripButton btnShowDiff;
        private System.Windows.Forms.ToolStripButton btnNext;
        private System.Windows.Forms.ToolStripButton btnPrev;
        public System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Label lblFormTitle;
    }
}
