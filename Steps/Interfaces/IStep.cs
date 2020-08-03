using System.Threading.Tasks;
using WTFlow.Common.Interfaces;
using WTFlow.Outcome.Interfaces;

namespace WTFlow.Steps.Interfaces
{

    public interface IStep : IExecutable<Task>, IAttachable<IOutcome>
    {

    }

}