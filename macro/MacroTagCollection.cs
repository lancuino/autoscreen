﻿//-----------------------------------------------------------------------
// <copyright file="MacroTagCollection.cs" company="Gavin Kendall">
//     Copyright (c) Gavin Kendall. All rights reserved.
// </copyright>
// <author>Gavin Kendall</author>
// <summary></summary>
//-----------------------------------------------------------------------

using System;

namespace AutoScreenCapture
{
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// 
    /// </summary>
    public class MacroTagCollection : IEnumerable<MacroTag>
    {
        private readonly List<MacroTag> _macroTagList = new List<MacroTag>();

        /// <summary>
        /// 
        /// </summary>
        public MacroTagCollection()
        {
            Add(new MacroTag(string.Empty, string.Empty));
            Add(new MacroTag(MacroTagSpec.Name, "Name of screen or region"));
            Add(new MacroTag(MacroTagSpec.ScreenNumber, "Screen number (1, 2, 3, 4 ...)"));
            Add(new MacroTag(MacroTagSpec.Format, "Image format of screen or region"));
            Add(new MacroTag(MacroTagSpec.Date, "Date (" + DateTime.Now.ToString(MacroParser.DateFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Time, "Time (" + DateTime.Now.ToString(MacroParser.TimeFormatForWindows) + ")"));
            Add(new MacroTag(MacroTagSpec.Year, "Year of " + DateTime.Now.ToString(MacroParser.DateFormat) + " (" + DateTime.Now.ToString(MacroParser.YearFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Month, "Month of " + DateTime.Now.ToString(MacroParser.DateFormat) + " (" + DateTime.Now.ToString(MacroParser.MonthFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Day, "Day of " + DateTime.Now.ToString(MacroParser.DateFormat) + " (" + DateTime.Now.ToString(MacroParser.DayFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Hour, "Hour of " + DateTime.Now.ToString(MacroParser.TimeFormat) + " (" + DateTime.Now.ToString(MacroParser.HourFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Minute, "Minute of " + DateTime.Now.ToString(MacroParser.TimeFormat) + " (" + DateTime.Now.ToString(MacroParser.MinuteFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Second, "Second of " + DateTime.Now.ToString(MacroParser.TimeFormat) + " (" + DateTime.Now.ToString(MacroParser.SecondFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Millisecond, "Millisecond of " + DateTime.Now.ToString(MacroParser.TimeFormat) + " (" + DateTime.Now.ToString(MacroParser.MillisecondFormat) + ")"));
            Add(new MacroTag(MacroTagSpec.Count, "Number of screen capture cycles during the current screen capture session"));
            Add(new MacroTag(MacroTagSpec.User, "Name of logged in user (" + Environment.UserName + ")"));
            Add(new MacroTag(MacroTagSpec.Machine, "Name of machine being used (" + Environment.MachineName + ")"));
            Add(new MacroTag(MacroTagSpec.Title, "Title of the active window"));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MacroTag>.Enumerator GetEnumerator()
        {
            return _macroTagList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<MacroTag>)_macroTagList).GetEnumerator();
        }

        IEnumerator<MacroTag> IEnumerable<MacroTag>.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="macroTag"></param>
        public void Add(MacroTag macroTag)
        {
            _macroTagList.Add(macroTag);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<MacroTag> GetList()
        {
            return _macroTagList;
        }
    }
}
