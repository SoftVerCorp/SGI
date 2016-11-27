using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Interactivity;
using System.Windows.Threading;

namespace SGI.Stuffs
{
    public class TakeFocusAndSelectTextOnVisibleBehavior : TriggerAction<TextBox>
    {
        protected override void Invoke(object parameter)
        {
            Dispatcher.BeginInvoke(
                DispatcherPriority.Loaded,
                new Action(() =>
                {
                    AssociatedObject.Focus();
                    AssociatedObject.SelectAll();
                }));
        }
    }
}
