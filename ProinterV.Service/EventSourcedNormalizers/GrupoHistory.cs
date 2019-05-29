using Newtonsoft.Json;
using ProinterV.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProinterV.Application.EventSourcedNormalizers
{
    public class GrupoHistory
    {
        public static IList<GrupoHistoryData> HistoryData { get; set; }

        public static IList<GrupoHistoryData> ToJavaScriptGrupoHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<GrupoHistoryData>();
            GrupoHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<GrupoHistoryData>();
            var last = new GrupoHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new GrupoHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    IdAluno = change.IdAluno == Guid.Empty.ToString() || change.IdAluno == last.IdAluno
                        ? ""
                        : change.IdAluno,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                    Descricao = string.IsNullOrWhiteSpace(change.Descricao) || change.Descricao == last.Descricao
                        ? ""
                        : change.Descricao,
                    Prazo = string.IsNullOrWhiteSpace(change.Prazo) || change.Prazo == last.Prazo
                        ? ""
                        : change.Prazo,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void GrupoHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new GrupoHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "TarefaRegistradaEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        slot.Descricao = values["Descricao"];
                        slot.IdAluno = values["IdAluno"];
                        slot.Action = "Registered";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "TarefaAtualizadaEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        slot.Descricao = values["Descricao"];
                        slot.IdAluno = values["IdAluno"];
                        slot.Action = "Updated";
                        slot.When = values["Timestamp"];
                        slot.Id = values["Id"];
                        slot.Who = e.User;
                        break;
                    case "TarefaRemovidaEvent":
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
