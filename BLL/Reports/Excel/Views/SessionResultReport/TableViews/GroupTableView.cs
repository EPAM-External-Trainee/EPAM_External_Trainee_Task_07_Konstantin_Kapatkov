﻿using BLL.Reports.Excel.Views.Interfaces.SessionResultReport.TableViews;
using BLL.Reports.Excel.Views.SessionResultReport;
using System.Collections.Generic;

namespace BLL.Reports.Views.SessionResultReport.TableView
{
    /// <summary>Class describing the view of the group table</summary>
    public class GroupTableView : IGroupTableView
    {
        /// <summary>Default constructor</summary>
        public GroupTableView()
        {
        }

        /// <summary>Creating an instance of <see cref="GroupTableView"/> via table raw views, group name, session name</summary>
        /// <param name="tableRawViews">Table raw views</param>
        /// <param name="groupName">Group name</param>
        /// <param name="sessionName">Session name</param>
        public GroupTableView(IEnumerable<GroupTableRowView> tableRawViews, string groupName, string sessionName) => (TableRawViews, GroupName, SessionName) = (tableRawViews, groupName, sessionName);

        /// <inheritdoc cref="IGroupTableView.Headers"/>
        public string[] Headers { get; } = { "Surname", "Name", "Patronymic", "Subject", "Form", "Date", "Assessment" };

        /// <inheritdoc cref="IGroupTableView.TableRawViews"/>
        public IEnumerable<GroupTableRowView> TableRawViews { get; set; }

        /// <inheritdoc cref="IGroupTableView.GroupName"/>
        public string GroupName { get; set; }

        /// <inheritdoc cref="IGroupTableView.SessionName"/>
        public string SessionName { get; set; }
    }
}