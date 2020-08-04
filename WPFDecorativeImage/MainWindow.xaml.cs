using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;

namespace WPFDecorativeImage
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    // Prevent images that are purely decorative from being exposed programmatically
    // through the Control view of the UI Automation (UIA) tree. By doing this, we
    // inform screen readers that the images are not of interest to the app's customers.

    public class DecorativeImage : Image
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new DecorativeImageAutomationPeer(this);
        }
    }

    public class DecorativeImageAutomationPeer : ImageAutomationPeer
    {
        public DecorativeImageAutomationPeer(DecorativeImage owner) :
            base(owner)
        {
        }

        // Returning false from IsControlElementCore will remove the image
        // from the Control view of the UIA tree.
        protected override bool IsControlElementCore()
        {
            return false;
        }

        // Also prevent the image from being exposed through the lesser-used
        // Content view of the UIA tree.
        protected override bool IsContentElementCore()
        {
            return false;
        }
    }
}
