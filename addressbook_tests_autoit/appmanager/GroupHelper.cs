﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITLE = "Group editor";
        public static string DELETEWINTITLE = "Delete group";

        public GroupHelper(ApplicationManager manager) : base(manager) { }

        List<GroupData> list = new List<GroupData>();
        public List<GroupData> GetGroupList()
        {
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(
                GROUPWINTITLE,"", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "GetItemCount","#0","");
            for (int i = 0; i < int.Parse(count); i++)
            {
                string item = aux.ControlTreeView(
                     GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                     "GetText", "#0|#" + i, "");

                list.Add(new GroupData()
               {
                   Name = item
               });

            }
            CloseGroupsDialogue();
            return list;
        }

        public void Add(GroupData newGroup)
        {
            //edit
            OpenGroupsDialogue();
            //new
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");
            //close
            CloseGroupsDialogue();


        }

        public void Remove(int group)
        {
            OpenGroupsDialogue();
            SelectGroup(group);
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.WinWait(DELETEWINTITLE);
            aux.ControlClick(DELETEWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
            aux.ControlClick(DELETEWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            CloseGroupsDialogue();
        }

        public void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        public void OpenGroupsDialogue()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITLE);
        }


       

        public void SelectGroup(int group)
        {
            aux.ControlTreeView(
                GROUPWINTITLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51",
                "Select", "#0|#" + group, "");
        }
    }
}