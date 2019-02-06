using System.Collections.Generic;
using ProtoBuf;

namespace ProtobufPOC.DTOs
{
    [ProtoContract]
    public class ResponseDTO : BaseDTO
    {
        [ProtoMember(1)]
        public List<string> Elements { get; set; }
    }
}
