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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ImageGlass.Base;
using ImageGlass.Settings;
using ImageGlass.UI;
using ImageGlass.UI.ToolForms;

namespace ImageGlass {
    /// <summary>
    /// A "SD Helper" dialog, to assist user in managing SD images
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
        public string previousPrompt = "";
        public string currentPrompt = "";
        public string currentNegativePrompt = "";
        public bool showingNegativePrompt = false;

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

        public void UpdatePrompts() {
            if (!string.IsNullOrEmpty(currentPrompt)) {
                if (Configs.SDToolShowDiff == false) {
                    rtbSDInfo.Text = currentPrompt;
                    return;
                }
                if (string.IsNullOrWhiteSpace(previousPrompt)) {
                    rtbSDInfo.Text = currentPrompt;
                }
                else {
                    var oPrompt = previousPrompt.Split(',');
                    var nPrompt = currentPrompt.Split(',');
                    List<string> found = new List<string>();
                    List<string> exact = new List<string>();
                    string diff = @"{\rtf1\ansi ";
                    for (int np = 0; np < nPrompt.Count(); np++) {
                        if (nPrompt[np].Length <= 2) continue;
                        for (int op = 0; op < oPrompt.Count(); op++) {
                            if (nPrompt[np] == oPrompt[op]) {
                                if (np == op) {
                                    exact.Add(nPrompt[np]);
                                }
                                else {
                                    found.Add(nPrompt[np]);
                                }
                                break;
                            }
                        }
                        if (exact.Contains(nPrompt[np])) {
                            diff += @"\b\i\ul " + nPrompt[np].Trim() + @"\b0\i0\ul0\, ";
                        }
                        else if (found.Contains(nPrompt[np])) {
                            diff += @"\b\i " + nPrompt[np].Trim() + @"\b0\i0\, ";
                        }
                        else {
                            diff += nPrompt[np].Trim() + ", ";
                        }
                    }
                    if (diff.LastIndexOf(',') >= diff.Length - 3)
                        diff = diff.Substring(0, diff.LastIndexOf(',')).Trim();
                    rtbSDInfo.Rtf = diff + "}";
                    return;
                }
            }
            else {
                //Local.FPSDTool.rtbSDInfo.Rtf = "";
                Local.FPSDTool.rtbSDInfo.Text = "No prompts found.";
            }
        }
        public void EnableButtons() {

            btnShowDiff.Enabled = true;
            btnSaveFav.Enabled = true;
            btnSaveNsfw.Enabled = true;
            btnDelete.Enabled = true;
        }

        #region Private Methods
        /// <summary>
        /// User has clicked on one of the navigation buttons. Fire off the appropriate event to our listener.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonClick(object sender, EventArgs e) {

            btnShowDiff.Enabled = false;
            btnSaveFav.Enabled = false;
            btnSaveNsfw.Enabled = false;
            btnDelete.Enabled = false;

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

            showingNegativePrompt = false;

            EnableButtons();
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

        private void rtbSDInfo_MouseDoubleClick(object sender, MouseEventArgs e) {
            showingNegativePrompt = !showingNegativePrompt;

            if (showingNegativePrompt) {
                rtbSDInfo.Text = currentNegativePrompt;
            } else { UpdatePrompts(); }

        }
    }
}
