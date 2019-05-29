using Newtonsoft.Json;
using ProinterV.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProinterV.Application.EventSourcedNormalizers
{
    public class TarefaHistory
    {
        public static IList<TarefaHistoryData> HistoryData { get; set; }

        public static IList<TarefaHistoryData> ToJavaScriptTarefaHistory(IList<StoredEvent> storedEvents)
        {
            HistoryData = new List<TarefaHistoryData>();
            TarefaHistoryDeserializer(storedEvents);

            var sorted = HistoryData.OrderBy(c => c.When);
            var list = new List<TarefaHistoryData>();
            var last = new TarefaHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new TarefaHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    IdGrupo = change.IdGrupo == Guid.Empty.ToString() || change.IdGrupo == last.IdGrupo
                        ? ""
                        : change.IdGrupo,
                    IdAluno = change.IdAluno == Guid.Empty.ToString() || change.IdAluno == last.IdAluno
                        ? ""
                        : change.IdAluno,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                    Descricao = string.IsNullOrWhiteSpace(change.Descricao) || change.Descricao == last.Descricao
                        ? ""
                        : change.Descricao,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    When = change.When,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void TarefaHistoryDeserializer(IEnumerable<StoredEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var slot = new TarefaHistoryData();
                dynamic values;

                switch (e.MessageType)
                {
                    case "TarefaRegistradaEvent":
                        values = JsonConvert.DeserializeObject<dynamic>(e.Data);
                        slot.Nome = values["Nome"];
                        slot.Descricao = values["Descricao"];
                        slot.IdGrupo = values["IdGrupo"];
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
                        slot.IdGrupo = values["IdGrupo"];
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
