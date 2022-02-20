namespace PGS
{
    public static partial class Extensions
    {
        public static uint ToInt(this bool value) => (uint)(value ? 1 : 0);

        public static int CountOnes(this int value)
        {
            value -= ((value >> 1) & 0x55555555);
            value = (value & 0x33333333) + ((value >> 2) & 0x33333333);
            return (((value + (value >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        public static int PositionOfRightmostSetBit(this int value) => (int)(Math.Log10(value) / Math.Log10(2));

        public static int Pow(this int @base, int exponent)
        {
            var powedValue = 1;
            while (exponent != 0)
            {
                if ((exponent & 1) == 1)
                    powedValue *= @base;
                @base *= @base;
                exponent >>= 1;
            }
            return powedValue;
        }
    }
}
