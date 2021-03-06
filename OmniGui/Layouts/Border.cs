namespace OmniGui.Layouts
{
    using System.Linq;
    using Geometry;
    using Zafiro.PropertySystem;

    public class Border : Layout
    {
        private Layout child;

        public Border(IPropertyEngine propertyEngine) : base(propertyEngine)
        {
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            var child = Child;
            var padding = Padding + new Thickness(BorderThickness);

            if (child != null)
            {
                child.Measure(availableSize.Deflate(padding));
                return child.DesiredSize.Inflate(padding);
            }
            else
            {
                return new Size(padding.Left + padding.Right, padding.Bottom + padding.Top);
            }
        }

        public Thickness Padding { get; set; }

        public Layout Child
        {
            get { return Children.FirstOrDefault(); }
            set
            {
                Children.Clear();
                Children.Add(value);
            }
        }

        /// <summary>
        /// Arranges the control's child.
        /// </summary>
        /// <param name="finalSize">The size allocated to the control.</param>
        /// <returns>The space taken.</returns>
        protected override Size ArrangeOverride(Size finalSize)
        {
            var child = Child;

            if (child != null)
            {
                var padding = Padding + new Thickness(BorderThickness);
                child.Arrange(new Rect(finalSize).Deflate(padding));
            }

            return finalSize;
        }


        public double BorderThickness { get; set; }

        public double CornerRadius { get; set; }

        public override void Render(IDrawingContext drawingContext)
        {
            drawingContext.FillRoundedRectangle(VisualBounds, Background, new CornerRadius(CornerRadius));
            drawingContext.DrawRoundedRectangle(VisualBounds, new Pen(BorderBrush, BorderThickness), new CornerRadius(CornerRadius));
            
            base.Render(drawingContext);
        }

        public Brush BorderBrush { get; set; }
    }
}