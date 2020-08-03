using System.Threading.Tasks;
using WTFlow.Common.Interfaces;
using WTFlow.Outcome.Interfaces;

namespace WTFlow.Outcome
{

    public class SimpleOutcome : IOutcome
    {

        protected readonly IExecutable<Task> Next;

        public SimpleOutcome(IExecutable<Task> next) =>
            Next = next;

        /// <inheritdoc />
        public virtual Task Execute() =>
            Next.Execute();

    }

}