using System.Collections.Generic;
using WTFlow.Common.Interfaces;
using WTFlow.Steps.Interfaces;

namespace WTFlow.Steps.Branch
{

    public interface IBranch : IStep, IAttachable<IStep>
    {

        ICollection<IStep> Steps { get; }

    }

}