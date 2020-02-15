using System;
using System.Collections.Generic;
using System.Text;

namespace IAC
{
    public class Aircraft
    {
        public Aircraft()
        {

        }

        public Aircraft(int id, int modelId, int companyId, string tailNumber)
        {
            Id = id;
            ModelId = modelId;
            CompanyId = companyId;
            TailNumber = tailNumber;
        }
        public int Id { get; private set; }
        public int ModelId { get; set; }
        public int CompanyId { get; set; }
        public string TailNumber { get; set; }
    }
}
