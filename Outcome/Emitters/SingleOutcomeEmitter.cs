using System.Threading.Tasks;
using WTFlow.Outcome.Interfaces;

namespace WTFlow.Outcome.Emitters
{

    public sealed class SingleOutcomeEmitter : IOutcomeEmitter
    {

        public IOutcome? Outcome { private get; set; }

        /// <inheritdoc />
        public void Attach(IOutcome input) =>
            Outcome = input;

        /// <inheritdoc />
        public Task Emit() =>
            Outcome?.Execute() ?? Task.CompletedTask;

    }

}