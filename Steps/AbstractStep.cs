using System.Threading.Tasks;
using WTFlow.Outcome.Emitters;
using WTFlow.Outcome.Interfaces;
using WTFlow.Steps.Interfaces;

namespace WTFlow.Steps
{

    public abstract class AbstractStep : IStep
    {

        protected IOutcomeEmitter OutcomeEmitter { get; set; } = default!;

        /// <inheritdoc />
        public void Attach(IOutcome input) => 
            OutcomeEmitter.Attach(input);


        /// <inheritdoc />
        public abstract Task Execute();

    }

}