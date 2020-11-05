using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MyOverrideMethod
{
    class MyCombox:ComboBox
    {
        //static MyCombox()
        //{
        //    DefaultStyleKeyProperty.OverrideMetadata(typeof(MyCombox), new FrameworkPropertyMetadata(typeof(MyCombox)));
        //}

        protected override void OnSelectionChanged(SelectionChangedEventArgs e)
        {
            base.OnSelectionChanged(e);
        }


    }
}
