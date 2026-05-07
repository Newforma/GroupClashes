using System;
using Autodesk.Navisworks.Api.Plugins;

namespace BimOne.BimTrack.GroupClashes
{
    [Plugin("BimOne.BimTrack.GroupClashes", "BIMO", DisplayName = "Newforma KONEKT Group Clashes")]
    [RibbonTab("ID_GroupClashesTab", DisplayName = "Newforma KONEKT Group Clashes")]
    [Command("ID_GroupClashesButton",
        Icon = "GroupClashesIcon_Small.ico", LargeIcon = "GroupClashesIcon_Large.ico",
        DisplayName = "Group Clashes", CanToggle = false)]

    class RibbonHandler : CommandHandlerPlugin
    {
        public override int ExecuteCommand(string commandId, params string[] parameters)
        {
            if (Autodesk.Navisworks.Api.Application.IsAutomated)
            {
                throw new InvalidOperationException("Invalid when running using Automation");
            }

            //Find the plugin
            PluginRecord pr = Autodesk.Navisworks.Api.Application.Plugins.FindPlugin("BimOne.BimTrack.GroupClashes.GroupClashesPane.BIMO");

            if (pr != null && pr is DockPanePluginRecord && pr.IsEnabled)
            {
                //check if it needs loading
                if (pr.LoadedPlugin == null)
                {
                    pr.LoadPlugin();
                }

                DockPanePlugin dpp = pr.LoadedPlugin as DockPanePlugin;
                if (dpp != null)
                {
                    //switch the Visible flag
                    dpp.Visible = !dpp.Visible;
                }
            }

            return 0;
        }

        public override CommandState CanExecuteCommand(String commandId)
        {
            CommandState state = new CommandState();
            state.IsVisible = true;
            state.IsEnabled = true;
            state.IsChecked = true;

            return state;
        }

        public override bool CanExecuteRibbonTab(string name)
        {
            return false;
        }

        public override bool TryShowCommandHelp(string name)
        {
            return false;
        }
    }
}


