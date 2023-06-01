
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Plugins;

namespace BimOne.BimTrack.GroupClashes
{
    [Plugin("BimOne.BimTrack.GroupClashes.GroupClashesPane", "BIMO", DisplayName = "Newforma KONEKT Group Clashes",ToolTip = "Newforma KONEKT Group clashes")]
    [DockPanePlugin(300, 380)]
    class GroupClashesPane : DockPanePlugin
    {
        public override Control CreateControlPane()
        {
            //create the control that will be used to display in the pane
            GroupClashesHostingControl control = new GroupClashesHostingControl();

            control.Dock = DockStyle.Fill;

            //create the control
            control.CreateControl();

            return control;
        }

        public override void DestroyControlPane(Control pane)
        {
            pane.Dispose();
        }
    }
}
