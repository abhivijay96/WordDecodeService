using System.Collections.Generic;
using Newtonsoft.Json;
using System;
namespace HigherKnowledge.WordDecodeService.Models
{
    public class WordDecodeData
    {
        [JsonPropertyAttribute(PropertyName = "data")]
        public String data { get; set; }
    }
}
