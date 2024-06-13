using Honeycomb.UI.Interfaces;
using Honeycomb.UI.BaseComponents;
using Honeycomb.UI.StronglyTypedControls.ControlHost;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.StronglyTypedControls.ComboBoxes
{
    
    [ToolboxItem(Globals.SHOW_BASE_COMPONENTS_IN_TOOLBOX)]
    public class StringComboBox: StringControlHost<HoneycombComboBox>
    {
        
        protected NumberStyles _numericStyle = NumberStyles.Number;
        protected int _numericOrderingIndex = 0;
        public StringComboBox()
        {
            ComboBoxExtension = new(this, Child)
            {
                AutoSortCallback = this.AutoSortCallback
            };
        }

        public ComboBoxHostExtension<HoneycombComboBox, ReadOnlyMemory<char>> ComboBoxExtension { get; }

        //Default implementation for sorting function that allows us to optionally parse passed items as floats
        IEnumerable<ReadOnlyMemory<char>> AutoSortCallback(IEnumerable<ReadOnlyMemory<char>> values)
        {
            switch (ParseMethod)
            {
                case OrderMethod.AsString:
                    return values.OrderBy(x => x.ToString());

                default:
                    var defaultValue = ParseMethod switch
                    {
                        OrderMethod.AsNumberAppendNonNumeric => float.MaxValue,
                        OrderMethod.AsNumberPrependNonNumeric => float.MinValue,
                        _ => throw new InvalidOperationException()
                    };

                    var results = values
                        .OrderBy(x =>
                            x.ToString()
                            .FindNumericValues(NumericStyle)
                            .Skip(NumericOrderingIndex)
                            .FirstOrDefault(defaultValue));

                    return results;
            }
        }

        public OrderMethod ParseMethod { get; set; }

        [DefaultValue(NumberStyles.None)]      
        public NumberStyles NumericStyle
        {
            get => ParseMethod == OrderMethod.AsString ? NumberStyles.None : _numericStyle;
            set => _numericStyle = value;
        }

        [DefaultValue(0)]
        public int NumericOrderingIndex
        {
            get => ParseMethod == OrderMethod.AsString ? 0 : _numericOrderingIndex;
            set => _numericOrderingIndex = value;
        }

        [DefaultValue(ComboBoxHostExtension.NULL_LABEL_DEFAULT)]
        public string NullLabel
        {
            get => ComboBoxExtension.NullLabel;
            set => ComboBoxExtension.NullLabel = value;
        }

        [DefaultValue(ComboBoxHostExtension.PREPEND_NULL_VALUE_DEFAULT)]
        public bool PrependNullValue
        {
            get => ComboBoxExtension.PrependNullValue;
            set => ComboBoxExtension.PrependNullValue = value;
        }

        [DefaultValue(ComboBoxHostExtension.AUTO_SORT_DEFAULT)]
        public bool AutoSort
        {
            get => ComboBoxExtension.AutoSort;
            set => ComboBoxExtension.AutoSort = value;
        }

        public IEnumerable<ReadOnlyMemory<char>> RawValues
        {
            get => ComboBoxExtension.RawValues;
            set => ComboBoxExtension.RawValues = value;
        }
        public int SelectedIndex
        {
            get => Child.SelectedIndex;
            set => Child.SelectedIndex = value;
        }
        public ComboBoxStyle DropdownStyle
        {
            get => Child.DropDownStyle;
            set => Child.DropDownStyle = value;
        }
        public ComboBox.ObjectCollection Items => Child.Items;

    }
    
}
