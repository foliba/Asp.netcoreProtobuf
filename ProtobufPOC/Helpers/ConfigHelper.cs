using System.Collections.Generic;
namespace ProtobufPOC.Helpers
{
    public static class ConfigHelper
    {
        static readonly Dictionary<ContentType, string> ContentTypeMap = new Dictionary<ContentType, string>() {
            { ContentType.Json, "application/json"},
            { ContentType.Protobuf, "application/x-protobuf"}
        };

        public static string GetContentType(ContentType contentType) {
            return ContentTypeMap[contentType];
        }
    }
}
