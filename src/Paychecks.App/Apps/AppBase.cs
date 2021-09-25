using FluentValidation;
using FluentValidation.Results;
using Paychecks.Domain.Entities;
using Paychecks.Domain.Notifications;
using Paychecks.Domain.Repositories;
using System.Linq;

namespace Paychecks.App.Apps
{
    public abstract class AppBase
    {
        private readonly INotifier _notifier;

        public AppBase(IUnitOfWork unitOfWork, INotifier notifier)
        {
            UnitOfWork = unitOfWork;
            _notifier = notifier;
        }

        protected IUnitOfWork UnitOfWork { get; }

        protected bool Validate<TValidator, TEntity>(TValidator validator, TEntity entity)
            where TValidator : AbstractValidator<TEntity>
            where TEntity : Entity
        {
            var validationResult = validator.Validate(entity);

            Notify(validationResult);

            return validationResult.IsValid;
        }

        protected void Notify(ValidationResult validationReult)
        {
            validationReult.Errors.ToList().ForEach((e) => { Notify(e.ErrorMessage); });
        }

        protected void Notify(string message)
        {
            _notifier.Handle(new Notification(message));
        }
    }
}