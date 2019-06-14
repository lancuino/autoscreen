﻿//-----------------------------------------------------------------------
// <copyright file="Settings.cs" company="Gavin Kendall">
//     Copyright (c) Gavin Kendall. All rights reserved.
// </copyright>
// <author>Gavin Kendall</author>
// <summary></summary>
//-----------------------------------------------------------------------
namespace AutoScreenCapture
{
    using System;
    using System.IO;

    public static class Settings
    {
        public static readonly string ApplicationName = "Auto Screen Capture";
        public static readonly string ApplicationVersion = "2.2.0.7";
        public static readonly string ApplicationCodename = "Dalek";

        public static SettingCollection Application;
        public static SettingCollection User;

        public static VersionManager VersionManager;
        private static VersionCollection _versionCollection;

        public static void Initialize()
        {
            _versionCollection = new VersionCollection();

            // This version.
            _versionCollection.Add(new Version(ApplicationCodename, ApplicationVersion, isCurrentVersion: true));

            // Older versions should be listed here.
            _versionCollection.Add(new Version("Clara", "2.1.8.2"));
            _versionCollection.Add(new Version("Dalek", "2.2.0.0"));
            _versionCollection.Add(new Version("Dalek", "2.2.0.1"));
            _versionCollection.Add(new Version("Dalek", "2.2.0.2"));
            _versionCollection.Add(new Version("Dalek", "2.2.0.3"));
            _versionCollection.Add(new Version("Dalek", "2.2.0.4"));
            _versionCollection.Add(new Version("Dalek", "2.2.0.5"));
            _versionCollection.Add(new Version("Dalek", "2.2.0.6"));

            Application = new SettingCollection();
            Application.Filepath = FileSystem.SettingsFolder + FileSystem.ApplicationSettingsFile;

            User = new SettingCollection();
            User.Filepath = FileSystem.SettingsFolder + FileSystem.UserSettingsFile;

            // Construct the version manager using the version collection and setting collection (containing the user's settings) we just prepared.
            VersionManager = new VersionManager(_versionCollection, User);

            if (!Directory.Exists(FileSystem.SettingsFolder))
            {
                Directory.CreateDirectory(FileSystem.SettingsFolder);
            }

            if (Application != null)
            {
                if (File.Exists(Application.Filepath))
                {
                    Application.Load();
                }
                else
                {
                    Application.Add(new Setting("Name", ApplicationName));
                    Application.Add(new Setting("Version", ApplicationVersion));
                    Application.Add(new Setting("DebugMode", false));

                    Application.Save();
                }
            }

            if (User != null && !File.Exists(User.Filepath))
            {
                User.Add(new Setting("IntScreenCaptureInterval", 60000));
                User.Add(new Setting("IntCaptureLimit", 0));
                User.Add(new Setting("BoolCaptureLimit", false));
                User.Add(new Setting("BoolTakeInitialScreenshot", false));
                User.Add(new Setting("BoolShowSystemTrayIcon", true));
                User.Add(new Setting("BoolCaptureStopAt", false));
                User.Add(new Setting("BoolCaptureStartAt", false));
                User.Add(new Setting("BoolCaptureOnSunday", false));
                User.Add(new Setting("BoolCaptureOnMonday", false));
                User.Add(new Setting("BoolCaptureOnTuesday", false));
                User.Add(new Setting("BoolCaptureOnWednesday", false));
                User.Add(new Setting("BoolCaptureOnThursday", false));
                User.Add(new Setting("BoolCaptureOnFriday", false));
                User.Add(new Setting("BoolCaptureOnSaturday", false));
                User.Add(new Setting("BoolCaptureOnTheseDays", false));
                User.Add(new Setting("DateTimeCaptureStopAtValue", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 17, 0, 0)));
                User.Add(new Setting("DateTimeCaptureStartAtValue", new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0)));
                User.Add(new Setting("BoolLockScreenCaptureSession", false));
                User.Add(new Setting("StringPassphrase", string.Empty));
                User.Add(new Setting("IntKeepScreenshotsForDays", 30));
                User.Add(new Setting("StringScreenshotLabel", string.Empty));
                User.Add(new Setting("BoolApplyScreenshotLabel", false));

                User.Save();
            }
        }
    }
}