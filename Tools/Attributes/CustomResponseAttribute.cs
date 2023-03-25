
using System.ComponentModel.DataAnnotations;

namespace Tools.Attributes
{
    public class CustomResponseAttribute : ValidationAttribute {
        public string Parent { get; set; }
        public string Child { get; set; }
        public override bool IsValid(object value) => true;
    }
}
