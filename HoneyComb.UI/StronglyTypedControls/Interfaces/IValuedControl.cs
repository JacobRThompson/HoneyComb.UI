using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Honeycomb.UI.Interfaces;

namespace Honeycomb.UI.StronglyTypedControls
{
    /*
    public interface IValuedControl<T> : IValued<T>, IAffixed, IRequireableControl where T : struct
    {

        public const string IS_INVALID_MSG = "--";

        public event EventHandler WrappedValueChanged;

        

        public new bool TrySetValue(in T newValue, out Optioned<T> result)
        {

            if((this as IValued<T>).TrySetValue(newValue, out result))
            {
                UnaffixedText = UnParse(result);
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GenText(Optioned<T> option) => AddAffixes(UnParse(option));
        public Optioned<T> Parse(string text)
        {



            if (this.Text == InvalidMsg)
            {
                return new(IsNullable ? OptionStatus.IsEmpty : OptionStatus.IsInvalid);
            }
            else
            {
                T new
                return Unformat(TrimAffixes(text));
            }
        }

        public Optioned<T> GenResult(string text) => Parse(TrimAffixes(text));
        public string UnParse(Optioned<T> option) => option.Valid switch
        {
            true => MapToString(option.Unwrap()),
            false => InvalidMsg
        };
       
    }
    */
}
