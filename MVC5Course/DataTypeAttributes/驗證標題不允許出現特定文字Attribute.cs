using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace MVC5Course.DataTypeAttributes
{
    public class 驗證標題不允許出現特定文字Attribute : DataTypeAttribute
    {
        public string[] Words { get; set; }

        public 驗證標題不允許出現特定文字Attribute() : base(DataType.Text)
        {
            ErrorMessage = "驗證標題不允許出現特定文字";
            Words = new string[0];
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var str = (string)value;

            return Words.All(item => !str.Contains(item));
        }
    }
}