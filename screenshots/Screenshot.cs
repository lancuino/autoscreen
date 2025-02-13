﻿//-----------------------------------------------------------------------
// <copyright file="Screenshot.cs" company="Gavin Kendall">
//     Copyright (c) Gavin Kendall. All rights reserved.
// </copyright>
// <author>Gavin Kendall</author>
// <summary></summary>
//-----------------------------------------------------------------------
namespace AutoScreenCapture
{
    using System;

    /// <summary>
    /// 
    /// </summary>
    public class Screenshot
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid ViewId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ImageFormat Format { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Screen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Component { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Slide Slide { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WindowTitle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProcessName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ScreenshotType ScreenshotType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Saved { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Screenshot()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="path"></param>
        /// <param name="format"></param>
        /// <param name="component"></param>
        /// <param name="screenshotType"></param>
        /// <param name="windowTitle"></param>
        /// <param name="processName"></param>
        /// <param name="viewId"></param>
        /// <param name="label"></param>
        public Screenshot(DateTime dateTime, string path, ImageFormat format, int component, ScreenshotType screenshotType, string windowTitle, string processName, Guid viewId, string label)
        {
            if (string.IsNullOrEmpty(windowTitle)) return;

            ViewId = viewId;
            Date = dateTime.ToString(MacroParser.DateFormat);
            Time = dateTime.ToString(MacroParser.TimeFormat);
            Path = path;
            Format = format;
            Component = component;
            ScreenshotType = screenshotType;
            WindowTitle = windowTitle;
            ProcessName = processName + ".exe";
            Label = label;
            Saved = false;

            Slide = new Slide()
            {
                Name = "{date=" + Date + "}{time=" + Time + "}",
                Date = Date,
                Value = Time + " [" + windowTitle + "]"
            };
        }
    }
}