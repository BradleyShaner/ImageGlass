/*
ImageGlass Project - Image viewer for Windows
Copyright (C) 2022 DUONG DIEU PHAP
Project homepage: https://imageglass.org

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <https://www.gnu.org/licenses/>.
*/

using System;
using System.Drawing;
using System.Windows.Forms;
using ImageGlass.Base;
using ImageGlass.Settings;
using ImageGlass.UI;
using ImageGlass.UI.ToolForms;

namespace ImageGlass {
    /// <summary>
    /// A "Page Navigation" dialog, to allow the user a GUI for moving between
    /// pages of a multi-page file via the mouse.
    /// </summary>
    public partial class frmPageSD: ToolForm {
        public enum SDEvent {
            Delete,
            MoveNSFW,
            MoveFav,
            ShowDiff,
            NextPic,
            PrevPic
        }

        /// <summary>
        /// The handler to send SDEvents to.
        /// </summary>
        public PageSDEvent SDEventHandler { get; set; }


        public delegate void PageSDEvent(SDEvent SDEvent);


        // default location offset on the parent form
        private static readonly Point DefaultLocationOffset = new(DPIScaling.Transform(20), DPIScaling.Transform(320));



        public frmPageSD() {
            InitializeComponent();

            _locationOffset = DefaultLocationOffset; // TODO simplify and move logic to ToolForm

            RegisterToolFormEvents();
            FormClosing += frmPageSD_FormClosing;

            btnSaveFav.Click += ButtonClick;
            btnSaveNsfw.Click += ButtonClick;
            btnDelete.Click += ButtonClick;
            btnNext.Click += ButtonClick;
            btnPrev.Click += ButtonClick;

            btnSnapTo.Click += SnapButton_Click;
        }



        #region Private Methods
        /// <summary>
        /// User has clicked on one of the navigation buttons. Fire off the appropriate event to our listener.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, EventArgs e) {
            if (SDEventHandler == null)  // no handler established, do nothing
                return;

            if (sender == btnDelete)
                SDEventHandler(SDEvent.Delete);
            if (sender == btnSaveFav)
                SDEventHandler(SDEvent.MoveFav);
            if (sender == btnSaveNsfw)
                SDEventHandler(SDEvent.MoveNSFW);
            if (sender == btnShowDiff)
                SDEventHandler(SDEvent.ShowDiff);
            if (sender == btnNext)
                SDEventHandler(SDEvent.NextPic);
            if (sender == btnPrev)
                SDEventHandler(SDEvent.PrevPic);
        }



        /// <summary>
        /// Apply theme / language
        /// </summary>
        internal void UpdateUI() {
            // Apply current theme ------------------------------------------------------
            OnDpiChanged();
            SetColors(Configs.Theme);

            // Remove white line under tool strip
            toolPageSD.Renderer = new UI.Renderers.ModernToolStripRenderer(Configs.Theme);

            toolPageSD.BackgroundImage = Configs.Theme.ToolbarBackgroundImage.Image;
            toolPageSD.BackColor = Configs.Theme.ToolbarBackgroundColor;
            toolPageSD.Alignment = ToolbarAlignment.CENTER;
            toolPageSD.HideTooltips = Configs.IsHideTooltips;

            // Overflow button and Overflow dropdown
            toolPageSD.OverflowButton.DropDown.BackColor = Configs.Theme.ToolbarBackgroundColor;
            toolPageSD.OverflowButton.AutoSize = false;
            toolPageSD.OverflowButton.Padding = new Padding(DPIScaling.Transform(10));

            //lblFormTitle.Text = Configs.Language.Items[$"{nameof(frmMain)}.mnuMainPageNav"];
            //btnNextPage.ToolTipText = Configs.Language.Items[$"{nameof(frmMain)}.mnuMainNextPage"];
            //btnPreviousPage.ToolTipText = Configs.Language.Items[$"{nameof(frmMain)}.mnuMainPrevPage"];
            //btnFirstPage.ToolTipText = Configs.Language.Items[$"{nameof(frmMain)}.mnuMainFirstPage"];
            //btnLastPage.ToolTipText = Configs.Language.Items[$"{nameof(frmMain)}.mnuMainLastPage"];

            btnSnapTo.FlatAppearance.MouseOverBackColor = Theme.LightenColor(Configs.Theme.BackgroundColor, 0.1f);
            btnSnapTo.FlatAppearance.MouseDownBackColor = Theme.DarkenColor(Configs.Theme.BackgroundColor, 0.1f);
        }


        private void OnDpiChanged() {
            // Update size of toolbar
            DPIScaling.TransformToolbar(ref toolPageSD, (int)Configs.ToolbarIconHeight);

            // Update toolbar icon according to the new size
            LoadToolbarIcons(Configs.Theme);

            // Update window size
            //this.Width = toolPageSD.PreferredSize.Width;
            //this.Height = toolPageSD.PreferredSize.Height + lblPageInfo.Height + btnClose.Height + 30;
        }


        private void LoadToolbarIcons(Theme th) {
            btnDelete.Image = th.ToolbarIcons.Delete.Image;
            btnSaveFav.Image = th.ToolbarIcons.GoToImage.Image;
            btnSaveNsfw.Image = th.ToolbarIcons.LockRatio.Image;
            btnNext.Image = th.ToolbarIcons.ViewNextImage.Image;
            btnPrev.Image = th.ToolbarIcons.ViewPreviousImage.Image;
        }
        #endregion


        #region Events
        private void frmPageSD_Load(object sender, EventArgs e) {
            UpdateUI();

            //Windows Bound (Position + Size)-------------------------------------------
            // TODO must be different from Color Picker
            var rc = Helpers.StringToRect("0;0;300;160");

            if (rc.X == 0 && rc.Y == 0) {
                _locationOffset = DefaultLocationOffset;
                parentOffset = _locationOffset;

                _SetLocationBasedOnParent();
            }
            else {
                Location = rc.Location;
            }
        }

        private void frmPageSD_Activated(object sender, EventArgs e) {
            UpdateUI();
        }

        private void frmPageSD_KeyDown(object sender, KeyEventArgs e) {
            // ESC or Ctrl+Shift+J --------------------------------------------------------
            if ((e.KeyCode == Keys.Escape && !e.Control && !e.Shift && !e.Alt) ||
                (e.KeyCode == Keys.J && e.Control && e.Shift && !e.Alt)) // CTRL + SHIFT + J
            {
                Configs.IsShowPageSDOnStartup = false;
                this.Close();
            }
        }

        private void frmPageSD_FormClosing(object sender, FormClosingEventArgs e) {
            Local.IsPageSDToolOpening = false;

            Local.ForceUpdateActions |= ForceUpdateActions.PAGE_NAV_MENU;
            SDEventHandler = null;
        }

        private void BtnClose_Click(object sender, EventArgs e) {
            Configs.IsShowPageSDOnStartup = false;
            this.Close();
        }

        #endregion

        private void lblPageInfo_DoubleClick(object sender, EventArgs e) {
            Clipboard.SetText(lblPageInfo.Text);
        }
    }
}
