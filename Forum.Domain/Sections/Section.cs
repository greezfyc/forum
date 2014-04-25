﻿using System;
using ENode.Domain;

namespace Forum.Domain.Sections
{
    [Serializable]
    public class Section : AggregateRoot<string>
    {
        public string Name { get; private set; }

        public Section(string id, string name) : base(id)
        {
            RaiseEvent(new SectionCreatedEvent(Id, name));
        }

        public void Update(string name)
        {
            RaiseEvent(new SectionUpdatedEvent(Id, name));
        }

        private void Handle(SectionCreatedEvent evnt)
        {
            Id = evnt.AggregateRootId;
            Name = evnt.Name;
        }
        private void Handle(SectionUpdatedEvent evnt)
        {
            Name = evnt.Name;
        }
    }
}
