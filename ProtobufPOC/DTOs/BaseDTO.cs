using System;
using ProtoBuf;

namespace ProtobufPOC.DTOs
{
    [ProtoContract]
    [ProtoInclude(100, typeof(ResponseDTO))]
    public class BaseDTO
    {
        [ProtoMember(1)]
        public string CurrentDateTime
        {
            get
            {
                return (dateTimeWasOverwritten) ? currentDateTime.ToString() : DateTime.UtcNow.ToString();
            }
            set
            {
                currentDateTime = DateTime.Parse(value);
                dateTimeWasOverwritten = true;
            }
        }

        private DateTime currentDateTime;
        private bool dateTimeWasOverwritten;
    }
}
