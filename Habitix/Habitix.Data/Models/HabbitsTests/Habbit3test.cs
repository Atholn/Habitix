using System;
using System.Collections.Generic;
using System.Text;

namespace Habitix.Data.Models.HabbitsTests
{
    public class Habbit3test
    {
        public Guid Habbit1testId { get; set; }
        public virtual Habbit1test Habbit1Test { get; set; }
        public Guid Habbit2testId { get; set; }
        public virtual Habbit2test Habbit2Test { get; set; }
    }
}
