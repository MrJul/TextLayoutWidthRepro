using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.TextFormatting;

namespace TextLayoutWidthRepro;

public class CustomControl : Control
{
    private readonly TextLayout _textLayout;

    public CustomControl()
    {
        _textLayout = new TextLayout("\ue971", new Typeface("avares://TextLayoutWidthRepro/#Symbols"), 26, Brushes.White);
    }

    protected override Size MeasureOverride(Size availableSize)
    {
        return new Size(GetWidth(), _textLayout.Height);
    }

    public override void Render(DrawingContext context)
    {
        context.DrawRectangle(Brushes.Black, null, new Rect(0.0, 0.0, GetWidth(), _textLayout.Height));
        _textLayout.Draw(context, new Point(0.0, 0.0));
    }

    private double GetWidth()
    {
        return _textLayout.Width;
        //return _textLayout.WidthIncludingTrailingWhitespace;
    }
}