using System;
using System.Collections.Generic;

namespace AdvancedJobProcessor.Entities
{
    [Serializable]
    public class Parameters: List<Parameter>
    {
        public string Prefix = "-";
        public string Delimiter = ":";
    }
}
