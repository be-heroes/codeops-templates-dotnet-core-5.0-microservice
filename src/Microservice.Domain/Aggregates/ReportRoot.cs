using CloudEngineering.CodeOps.Abstractions.Aggregates;
using CloudEngineering.CodeOps.Abstractions.Entities;
using Microservice.Domain.Events.Report;
using Microservice.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Microservice.Domain.Aggregates
{
    public sealed class ReportRoot : Entity<Guid>, IAggregateRoot
    {
        private readonly List<CostItem> _costItems;
        private readonly DateTime _created = DateTime.UtcNow;

        public IEnumerable<CostItem> CostItems => _costItems.AsReadOnly();
        public DateTime Created => _created;

        public ReportRoot()
        {
            _costItems = new List<CostItem>();

            var evt = new ReportCreatedEvent(this);

            AddDomainEvent(evt);
        }

        public ReportRoot(DateTime created) : this()
        {
            _created = created;
        }

        public void AddCostItem(CostItem costItem)
        {
            _costItems.Add(costItem);
        }

        public void AddCostItem(IEnumerable<CostItem> costItems)
        {
            _costItems.AddRange(costItems);
        }

        public void RemoveCostItem(CostItem costItem)
        {
            _costItems.Remove(costItem);
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return Enumerable.Empty<ValidationResult>();
        }
    }
}