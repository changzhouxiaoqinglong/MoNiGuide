
public static class StringExtension
{
    public static int ToInt(this string selfStr, int defaultValue = 0)
    {
        int resValue;
        return int.TryParse(selfStr, out resValue) ? resValue : defaultValue;
    }

    public static float ToFloat(this string selfStr, float defaultValue = 0)
    {
        float resValue;
        return float.TryParse(selfStr, out resValue) ? resValue : defaultValue;
    }
}
