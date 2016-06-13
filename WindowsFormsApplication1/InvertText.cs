using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    public class InvertText
    {
        string a;
        public InvertText(string a)
        {
            this.a = a;
        }

        public void settext(string a)
        {
            this.a = a;
        }

        public string returntext()
        {
            string x = this.a;
            return x;
        }
    }
}