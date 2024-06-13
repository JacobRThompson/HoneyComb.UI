using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.Interfaces
{
    /*
    public interface IValued<T>: IAffixed 
        where T : struct, IEquatable<T>
    {

        public Verifier<T> Verifier { get; }
        public string InvalidMsg { get; set; }

        public Optioned<T> UnaffixedResult { get; set; }
        public bool Valid { get; set; }
        public T Value { get; set; }





        public bool CalcIsValid(T value);

        public T Unformat(string text);
        public string Format(T value);


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



        public bool TrySetValidity(in bool newValidity)
        {
            if(newValidity != this.Valid)
            {
                UnaffixedResult = new(UnaffixedResult.Value, newValidity);
                return true;
            }
            else return false; 
        }

        public bool TrySetValue(in T newValue)
        {         
            if(!newValue.Equals(Value))
            {
                UnaffixedResult = new(newValue, CalcIsValid(newValue));
                return true;
            }
            else return false;
           
        }

        public bool TrySetResult(in Optioned<T> newResult)
        {
            if (!newResult.Equals(UnaffixedResult))
            {
                Valid = UnaffixedResult.Valid;
                return true;
            }
            else return false;
        }





    }
    */
}
