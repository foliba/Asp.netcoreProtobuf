using System.Collections.Generic;
using ProtoBuf;
using System;

namespace ProtobufPOC.DTOs
{
    [ProtoContract]
    public class ResponseDTO
    {
        [ProtoMember(1)]
        public List<string> Elements { get; set; }

        /*
        [ProtoMember(2)]
        public string CurrentDateTime => DateTime.UtcNow.ToString();
        */

        [ProtoMember(2)]
        public string CurrentDateTime {
            get {
                return (dateTimeWasOverwritten) ? currentDateTime.ToString() : DateTime.UtcNow.ToString();
            }
            set {
                currentDateTime = DateTime.Parse(value);
                dateTimeWasOverwritten = true;
            }
        }

        private DateTime currentDateTime;
        private bool dateTimeWasOverwritten;
    }
}
