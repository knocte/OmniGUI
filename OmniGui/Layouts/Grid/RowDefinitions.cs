namespace OmniGui.Layouts.Grid
{
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    /// <summary>
    /// A collection of <see cref="RowDefinition"/>s.
    /// </summary>
    public class RowDefinitions : List<RowDefinition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RowDefinitions"/> class.
        /// </summary>
        public RowDefinitions()
        {
            ResetBehavior = ResetBehavior.Remove;
        }

        public ResetBehavior ResetBehavior { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RowDefinitions"/> class.
        /// </summary>
        /// <param name="s">A string representation of the row definitions.</param>
        public RowDefinitions(string s)
            : this()
        {
            AddRange(GridLength.ParseLengths(s, CultureInfo.InvariantCulture).Select(x => new RowDefinition(x)));
        }
    }
}