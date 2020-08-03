using System;
using System.Collections.Generic;

namespace WTFlow.Steps.Interfaces
{

    public interface IConfigurableStep : IStep
    {

        ICollection<Action> SetupActions { get; }


    }

}