using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Honeycomb.UI.BaseComponents.TextBoxVerifiers
{
    public interface IControlVerifier<T>
        where T : struct
    {
        public Guid TypeId { get; }
        public bool Enabled { get; set; }

        public Control? Parent { get; set; }


        /// <summary>
        /// Takes the result of a components TryParse() Function and tests it against some validation critera, 
        /// setting error providers as need
        /// </summary>
        /// <param name="tryParseResult"></param>
        bool Verify(in (bool couldParse, T parsedValue) tryParseResult);

     
        
       
    }
}
