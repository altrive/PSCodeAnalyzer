using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.PowerShell.Host.ISE;

namespace PSCodeAnalyzer.Views
{
    /// <summary>
    /// PSCodeAnalyzer.xaml の相互作用ロジック
    /// </summary>
    public partial class PSCodeAnalyzer : UserControl, IAddOnToolHostObject
    {


        public PSCodeAnalyzer()
        {
            InitializeComponent();
        }

        private ObjectModelRoot hostObject;
        public ObjectModelRoot HostObject
        {
            get
            {
                return this.hostObject;
            }
            set
            {
                this.hostObject = value;
                if (this.hostObject == null)
                    return;
                Initialize();
            }
        }

        public void Initialize()
        {
            this.hostObject.CurrentPowerShellTab.PropertyChanged += CurrentPowerShellTab_PropertyChanged;            
            this.hostObject.CurrentPowerShellTab.AddOnToolPaneOpenedOrClosed += CurrentPowerShellTab_AddOnToolPaneOpenedOrClosed;
            this.hostObject.CurrentPowerShellTab.AddOnToolAddedOrRemoved += CurrentPowerShellTab_AddOnToolAddedOrRemoved;
            this.hostObject.CurrentPowerShellTab.AddOnToolVisibilityChanged += CurrentPowerShellTab_AddOnToolVisibilityChanged;
           
        }

        private void CurrentPowerShellTab_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (!this.hostObject.CurrentPowerShellTab.CanInvoke)
                return;

            ((UIElement)Content).IsEnabled = true;
        }

        void CurrentPowerShellTab_AddOnToolVisibilityChanged(object sender, ISEAddOnToolEventArgs e)
        {
          
        }

        void CurrentPowerShellTab_AddOnToolAddedOrRemoved(object sender, ISEAddOnToolAddedOrRemovedEventArgs e)
        {
        }

        void CurrentPowerShellTab_AddOnToolPaneOpenedOrClosed(object sender, ISEAddOnToolPaneOpenOrClosedEventArgs e)
        {
        }


        private void RunScript()
        {
            string script = "";
            if (!this.HostObject.CurrentPowerShellTab.CanInvoke)
                return;
            this.HostObject.CurrentPowerShellTab.InvokeSynchronous(script, true);
        }
    }
}
