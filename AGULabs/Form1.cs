using Lab1.Helpers;

namespace Lab1;

public partial class Fill : Form
{
    private readonly IHsiConverter _hsiConverter;
    private int _h;
    private double _s;
    private double _i;
    public Fill(IHsiConverter hsiConverter)
    {
        _hsiConverter = hsiConverter;
        InitializeComponent();
        UpdateColorLabels();
    }

    private void HScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        _h = HScrollBar.Value;
        UpdateColorLabels();
        UpdateColorIf(IsAutoFilling());
    }

    private void SScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        _s = SScrollBar.Value / 100.0;
        UpdateColorLabels();
        UpdateColorIf(IsAutoFilling());
    }

    private void IScrollBar_Scroll(object sender, ScrollEventArgs e)
    {
        _i = IScrollBar.Value / 100.0;
        UpdateColorLabels();
        UpdateColorIf(IsAutoFilling());
    }

    private void FillButton_Click(object sender, EventArgs e) => UpdateColorIf(true);

    private void UpdateColorIf(bool condition)
    {
        if (!condition) return;
        var (r, g, b) = _hsiConverter.ToRgbValues(_h, _s, _i);
            
        FillingPanel.BackColor = Color.FromArgb(r, g, b);
        UpdateColorLabels(r, g, b);
    }
    private bool IsAutoFilling() => AutoFillCheckBox.Checked;

    private void UpdateColorLabels(int r = default, int g = default, int b = default)
    {
        if (r == default && g == default && b == default)
        {
            (r, g, b) = _hsiConverter.ToRgbValues(_h, _s, _i);
        }

        HLabel.Text = _h.ToString();
        SLabel.Text = _s.ToString("F");
        ILabel.Text = _i.ToString("F");
        RLabel.Text = r.ToString();
        GLabel.Text = g.ToString();
        BLabel.Text = b.ToString();
    }
}