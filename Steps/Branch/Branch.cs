using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WTFlow.Steps.Interfaces;

namespace WTFlow.Steps.Branch
{
    /**
     * Composite
     */
    public class Branch : AbstractStep, IBranch
    {

        /// <inheritdoc />
        public ICollection<IStep> Steps { get; } = new List<IStep>();

        /// <inheritdoc />
        public void Attach(IStep input) =>
            Steps.Add(input);

        /// <inheritdoc />
        public override Task Execute()
        {
            Steps.ToList().ForEach(step => step.Execute());

            return Task.CompletedTask;
        }

    }

}