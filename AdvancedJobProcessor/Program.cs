using System.IO;
using System.Xml.Serialization;
using System.Xml;

namespace AdvancedJobProcessor
{
    class Program
    {
        private static XmlSerializer queueSerializer = new XmlSerializer(typeof(Entities.JobQueue));

        static void Main(string[] args)
        {
            SerializeQueue(BuildSimpleQueue(), "SimpleQueue.xml");
            Entities.JobQueue deserializedQueue = DeserializeQueue("SimpleQueue.xml");
        }

        private static Entities.JobQueue DeserializeQueue(string FileName)
        {
            FileStream xmlJobDefinition = File.OpenRead(FileName);
            return (Entities.JobQueue)queueSerializer.Deserialize(xmlJobDefinition);

        }

        private static Entities.JobQueue BuildSimpleQueue()
        {
            Entities.Parameter time = new Entities.Parameter() { Name = "t", Value = "2" };
            Entities.Parameter exitcode = new Entities.Parameter() { Name = "e", Value = "2" };
            Entities.Parameters waiterParams = new Entities.Parameters() { Prefix = "/", Delimiter = "=" };
            waiterParams.Add(time);
            waiterParams.Add(exitcode);
            ImplementedJobs.WaiterJob waiter = new ImplementedJobs.WaiterJob() { Parameters = waiterParams };
            Entities.JobQueue queue = new Entities.JobQueue()
            {
                DisplayName = "TestQueue",
                Description = "Lorem ipsum dolor sit amet",
                LogLevel = 1
            };
            queue.Add(waiter);
            return queue;
        }

        private static void SerializeQueue(Entities.JobQueue Queue, string FileName)
        {
            StreamWriter writer = new StreamWriter(FileName);
            queueSerializer.Serialize(writer, Queue);
        }
    }
}