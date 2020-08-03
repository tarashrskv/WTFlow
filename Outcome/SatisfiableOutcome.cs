using System;
using System.Threading.Tasks;
using WTFlow.Common.Interfaces;

namespace WTFlow.Outcome
{

    public sealed class SatisfiableOutcome : SimpleOutcome
    {

        private readonly Func<bool> condition;

        public SatisfiableOutcome(Func<bool> condition, IExecutable<Task> next) : base(next) =>
            this.condition = condition;

        /// <inheritdoc />
        public override Task Execute() =>
            IsSatisfied() ? base.Execute() : Task.CompletedTask;

        private bool IsSatisfied() =>
            condition();

    }

}