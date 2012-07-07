using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace CodeDayWcf
{
    [DataContract]
    public class ScoreboardItem
    {
        [DataMember]
        public string ID;

        [DataMember]
        public int Position;

        [DataMember]
        public string Nickname;

        [DataMember]
        public int Score;

        [DataMember]
        public int Scans;

        [DataMember]
        public DateTime LastUpdated;
    }
}