using System.Threading.Tasks;
using WTFlow.Common.Interfaces;
using WTFlow.Outcome.Interfaces;

namespace WTFlow.Outcome.Emitters
{

    public interface IOutcomeEmitter : IEmittable<Task>, IAttachable<IOutcome>
    {

    }

}