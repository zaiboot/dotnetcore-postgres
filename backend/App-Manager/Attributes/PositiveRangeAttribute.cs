namespace AppManager.Attributes
{
    using System.ComponentModel.DataAnnotations;

    public class PositiveRangeAttribute : RangeAttribute
    {
        public PositiveRangeAttribute(float minimum) : base(minimum, float.MaxValue)
        {
        }
        public PositiveRangeAttribute(int minimum) : base(minimum, int.MaxValue){

        }


    }
}