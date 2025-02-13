﻿//-----------------------------------------------------------------------
// <copyright file="FormEnterPassphrase.cs" company="Gavin Kendall">
//     Copyright (c) Gavin Kendall. All rights reserved.
// </copyright>
// <author>Gavin Kendall</author>
// <summary></summary>
//-----------------------------------------------------------------------
namespace AutoScreenCapture
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// 
    /// </summary>
    public partial class FormEnterPassphrase : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FormEnterPassphrase()
        {
            InitializeComponent();
        }

        private void FormEnterPassphrase_Load(object sender, EventArgs e)
        {
            textBoxPassphrase.Text = string.Empty;
            textBoxPassphrase.Focus();
        }

        private void Click_buttonCancel(object sender, EventArgs e)
        {
            Close();
        }

        private void Click_buttonUnlock(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxPassphrase.Text)) return;

            if (Security.Hash(textBoxPassphrase.Text).Equals(Settings.User.GetByKey("StringPassphrase", defaultValue: string.Empty).Value))
            {
                Log.Write("Screen capture session was successfully unlocked by " + Environment.UserName + " on " + Environment.MachineName);

                ScreenCapture.LockScreenCaptureSession = false;
                Close();
            }
            else
            {
                Log.Write("WARNING: There was an attempt to unlock the running screen capture session! The user was " + Environment.UserName + " on " + Environment.MachineName);

                textBoxPassphrase.Clear();
                textBoxPassphrase.Focus();
            }
        }

        private void TextChanged_textBoxPassphrase(object sender, EventArgs e)
        {
            buttonUnlock.Enabled = textBoxPassphrase.Text.Length > 0;
        }
    }
}