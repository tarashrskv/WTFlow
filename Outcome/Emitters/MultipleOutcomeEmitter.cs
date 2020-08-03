using System.Collections.Generic;
using System.Threading.Tasks;
using WTFlow.Outcome.Interfaces;

namespace WTFlow.Outcome.Emitters
{

    public class MultipleOutcomeEmitter : IOutcomeEmitter
    {

        private readonly List<IOutcome> outcomes;

        public MultipleOutcomeEmitter() =>
            outcomes = new List<IOutcome>();

        /// <inheritdoc />
        public void Attach(IOutcome input) =>
            outcomes.Add(input);

        /// <inheritdoc />
        public Task Emit()
        {
            outcomes.ForEach(outcome => outcome.Execute());

            return Task.CompletedTask;
        }

    }

}