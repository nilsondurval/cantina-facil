using FluentValidation;
using FluentValidation.Results;
using CantinaFacil.Shared.Kernel.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CantinaFacil.Shared.Kernel.Domain
{
    public abstract class Entity
    {
        private List<Event>? _domainEvents;
        public IReadOnlyCollection<Event>? DomainEvents => _domainEvents?.AsReadOnly();
        public int Id { get; set; }
        public bool IsValid { get; private set; }
        public bool IsInvalid => !IsValid;
        public ValidationResult? ValidationResult { get; set; }

        protected Entity()
        {
            
        }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return IsValid = ValidationResult.IsValid;
        }

        public void AddDomainEvent(Event domainEvent)
        {
            _domainEvents ??= new List<Event>();
            _domainEvents.Add(domainEvent);
        }

        public void RemoveDomainEvent(Event domainEvent)
        {
            _domainEvents?.Remove(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

        #region BaseBehaviours

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() ^ 93) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return $"{GetType().Name} [Id={Id}]";
        }

        #endregion
    }
}
