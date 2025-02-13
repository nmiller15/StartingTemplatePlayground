using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestClassLib
{
    public class Data
    {
        public string Title { get; set; }
        public string Value { get; set; }

        public Data(string title, string value)
        {
            Title = title;
            Value = value;
        }
    }
}
