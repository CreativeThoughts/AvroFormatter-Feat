using System;
using Newtonsoft.Json;

namespace AvroFormatterFeat
{
    class MainClass
    {

        static void Main(string[] args)
        {
            //Event Object replica of Fenergo DataModel
            StatusEvent stEvent = new StatusEvent();

            //Initiating the values that is manadatory and available
            stEvent.CaseType = "KYCRefresh";
            stEvent.PreviousStatus = "Initiated";

            //newtonsoft json serialiser serialising the event object
            string str = JsonConvert.SerializeObject(stEvent, Formatting.Indented);

            //output the json onto Console
            str = str.Replace("\\", string.Empty);
            Console.WriteLine(str);
        }


        public class StatusEvent
        {
            public string StatusType { get; set; }

            //decorating the porperty that would need to adhere to the avro schema format
            // "previousStatus":{"string":"some"}
            [JsonConverter(typeof(CustomFormatter))]
            public string PreviousStatus { get; set; }

            //"caseType:"sksm";
            public string CaseType { get; set; }

            [JsonConverter(typeof(CustomFormatter))]
            public int NoOfTasksOpen { get; set; }

            [JsonConverter(typeof(CustomFormatter))]
            public string PreviousCase { get; set; }
        }
    }
}
