using Newtonsoft.Json;
using ProinterV.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProinterV.Application.EventSourcedNormalizers
{
    class TarefaHistory
    {
        public static IList<TarefaHistoryData> HistoryData { get; set; }

        public static IList<TarefaHistoryData> ToJavaScriptTarefaHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<TarefaHistoryData>();
            AlunoHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<AlunoHistoryData>();
            var last = new AlunoHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new AlunoHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Name = string.IsNullOrWhiteSpace(change.Name) || change.Name == last.Name
                        ? ""
                        : change.Name,
                    Email = string.IsNullOrWhiteSpace(change.Email) || change.Email == last.Email
                        ? ""
                        : change.Email,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void AlunoHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new AlunoHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "AlunoRegisteredEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Email = values["Login"];
                        slot.Name = values["Nome"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "AlunoUpdatedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Email = values["Login"];
                        slot.Name = values["Name"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "AlunoRemovedEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Action = "Removed";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                }
                HistoryData.Add(slot);
            }
        }
    }
}
