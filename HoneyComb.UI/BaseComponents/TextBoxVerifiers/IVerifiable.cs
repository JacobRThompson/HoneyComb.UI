using Honeycomb.UI.BaseComponents.TextBoxVerifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HoneyComb.UI.BaseComponents.TextBoxVerifiers
{
    /// <summary>
    /// An object (presumably a UserControl) with a collection of Control Verifiers
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IVerifiable<T>
        where T : struct
    {

        public Dictionary<Guid, IControlVerifier<T>> Verifiers { get; }

        public bool Verify(in (bool couldParse, T parsedValue) tryParseResult);
    }
}
