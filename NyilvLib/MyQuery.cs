using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NyilvLib
{
    public class MyQuery
    {
        public const string EqualsCondition = "Equals";
        public const string ContainsCondition = "Contains";
        public const string TrueCondition = "True";
        public const string FalseCondition = "False";

        public string Item2Find { get; set; }
        public string Condition { get; set; }
        public string Value { get; set; }
    }
}
