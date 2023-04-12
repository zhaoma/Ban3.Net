//  ————————————————————————————————————————————————————————————————————————————
//  zhaoma @ 2022/12/27 09:26
//  function:	IntegrationEvent.cs
//  reference:	https://
//  ————————————————————————————————————————————————————————————————————————————
using System;
using Newtonsoft.Json;

namespace  Ban3.Infrastructures.EventBus.Events
{
	public class IntegrationEvent
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        [JsonConstructor]
        public IntegrationEvent(Guid id, DateTime createDate)
        {
            Id = id;
            CreationDate = createDate;
        }

        [JsonProperty]
        public Guid Id { get; private set; }

        [JsonProperty]
        public DateTime CreationDate { get; private set; }
    }
}

