namespace Lab1.Helpers;

public interface IHsiConverter
{
    public (int, int, int) ToRgbValues(int h, double s, double i);
}