namespace Lab1.Helpers;

public class HsiConverter : IHsiConverter
{
    public (int, int, int) ToRgbValues(int h, double s, double i)
    {
        var hTag = h / 60.0;
        var z = 1.0 - Math.Abs(hTag % 2 - 1);
        var c = (3.0 * i * s) / (1.0 + z);
        var x = c * z;
        double r1, g1, b1;

        switch (hTag)
        {
            case >= 0 and <= 1:
                r1 = c;
                g1 = x;
                b1 = 0;
                break;
            case >= 1 and <= 2:
                r1 = x;
                g1 = c;
                b1 = 0;
                break;
            case >= 2 and <= 3:
                r1 = 0;
                g1 = c;
                b1 = x;
                break;
            case >= 3 and <= 4:
                r1 = 0;
                g1 = x;
                b1 = c;
                break;
            case >= 4 and <= 5:
                r1 = x;
                g1 = 0;
                b1 = c;
                break;
            case >= 5 and <= 6:
                r1 = c;
                g1 = 0;
                b1 = x;
                break;
            default:
                r1 = 0;
                g1 = 0;
                b1 = 0;
                break;
        }

        var m = i * (1 - s);
        var r = r1 + m;
        var g = g1 + m;
        var b = b1 + m;

        var maxRgb = Math.Max(Math.Max(r, g), b);
        if (maxRgb > 1)
        {
            r /= maxRgb;
            g /= maxRgb;
            b /= maxRgb;
        }

        return (Convert.ToInt32(r * 255), Convert.ToInt32(g * 255), Convert.ToInt32(b * 255));
    }
}