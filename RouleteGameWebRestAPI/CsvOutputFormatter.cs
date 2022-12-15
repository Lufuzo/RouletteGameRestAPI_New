using Microsoft.AspNetCore.Mvc.Formatters;
using Shared.DataTransferObjects;
using System.Net.Http.Headers;
using System.Text;

namespace RouleteGameWebRestAPI
{
    public class CsvOutputFormatter : TextOutputFormatter
    {

        public CsvOutputFormatter()
        {
           // SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        protected override bool CanWriteType(Type? type)
        {
            if (typeof(SpinDto).IsAssignableFrom(type)
                || typeof(IEnumerable<SpinDto>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }

            return false;
        }
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context,
            Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var buffer = new StringBuilder();

            if (context.Object is IEnumerable<SpinDto>)
            {
                foreach (var spin in (IEnumerable<SpinDto>)context.Object)
                {
                    FormatCsv(buffer, spin);
                }
            }
            else
            {
                FormatCsv(buffer, (SpinDto)context.Object);
            }

            await response.WriteAsync(buffer.ToString());
        }
        private static void FormatCsv(StringBuilder buffer, SpinDto spin)
        {
            buffer.AppendLine($"{spin.Id},\"{spin.SpinResult}\",\"{spin.TimestampUtc}\"");
        }
    }
}
