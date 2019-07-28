using System;

using System.Windows.Forms;
using PEPlugin;

namespace PMXEP536 {
    public class PMXEP536 : PEPluginClass {
        private Form _form;

        // Constructor
        public PMXEP536() : base()
        {
            bool bootAction    = true;
            bool setPluginMenu = true;
            string pluginName  = "PMXEP536";
            m_option = new PEPluginOption(bootAction,setPluginMenu,pluginName);
        }

        // Main
        public override void Run(IPERunArgs args) {
            try {
                if (_form == null)
                {
                    _form = new Form();
                    _form.debuglog("Form object was created.");
                    _form.SetHostArgs(args); //inject system data
                    _form.debuglog("Form$SetHostArgs succeded.");
                    _form.Visible = true;
                    _form.debuglog("Turned Form.Visible to " + _form.Visible);
                }
                else
                {
                    _form.Visible = !_form.Visible;
                    _form.debuglog("Turned Form.Visible to " + _form.Visible);
                }
            } catch (Exception ex) {
                MessageBox.Show(
                    ex.Message, 
                    "Error Occurred", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation
                    );
            }
        }

        // Finalize
        public override void Dispose()
        {
            if (_form != null)
            {
                _form.Close();
                _form = null;
            }
        }
    }
}
