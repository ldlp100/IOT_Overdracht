using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IoTEx.WaternetIoT.Model.DTOs.API
{
    public class APIRequestDTO
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? Page { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? PageSize { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<FilterDesc>? Filters { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public IList<SortDesc>? Sorts { get; set; }

        public APIRequestDTO()
        {
            Filters = new List<FilterDesc>();
            Sorts = new List<SortDesc>();
        }
        public class FilterDesc
        {

            public enum FilterOperator { Eq = 0, NotEq = 1, Contains = 2, DoesNotContain = 3, StartWith = 4, EndWith = 5, IsNull = 6, IsNotNull = 7, Greater = 8, GreaterEqual = 9, Lower = 10, LowerEqual = 11 }
            public string Member { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public FilterOperator Operator { get; set; }
            public dynamic Value { get; set; }

        }
        public class SortDesc
        {

            public enum SortDirection { ASC, DESC }
            public string Member { get; set; }
            [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
            public SortDirection Direction { get; set; }

        }

    }
}
