using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace WPFFinalproject.Classes
{
    public class ViewObject : UnviewObject
    {
        public void SizeSet(TextBox obj, int w, int h)
        {
            obj.Width = w;
            obj.Height = h;
        }

        public void SizeSet(Label obj, int w, int h)
        {
            obj.Width = w;
            obj.Height = h;
        }
        public void SizeSet(Button obj, int w, int h)
        {
            obj.Width = w;
            obj.Height = h;
        }
    }
}
