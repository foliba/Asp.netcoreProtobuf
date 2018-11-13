using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using ProtoBuf.Meta;
using ProtobufPOC.Helpers;

namespace Formatters
{
    public class ProtobufOutputFormatter :  OutputFormatter
    {
        private static Lazy<RuntimeTypeModel> model = new Lazy<RuntimeTypeModel>(CreateTypeModel);
  
        public static RuntimeTypeModel Model
        {
            get { return model.Value; }
        }
 
        public ProtobufOutputFormatter()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse(ConfigHelper.GetContentType(ContentType.Protobuf)));
 
            //SupportedEncodings.Add(Encoding.GetEncoding("utf-8"));
        }
 
        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
 
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context)
        {
            var response = context.HttpContext.Response;
     
            Model.Serialize(response.Body, context.Object);
            return Task.FromResult(response);
        }
    }
}