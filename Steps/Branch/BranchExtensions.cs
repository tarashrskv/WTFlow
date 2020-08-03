using System.Collections.Generic;
using System.Linq;
using WTFlow.Steps.Interfaces;

namespace WTFlow.Steps.Branch
{

    public static class BranchExtensions
    {

        public static IBranch AsBranch(this IEnumerable<IStep> steps)
        {
            var branch = new Branch();

            steps.ToList().ForEach(step => branch.Attach(step));

            return branch;
        }

        public static TBranch AsBranch<TBranch>(this IEnumerable<IStep> steps) where TBranch : IBranch, new()
        {
            var branch = new TBranch();

            steps.ToList().ForEach(step => branch.Attach(step));

            return branch;
        }

        public static TBranch Add<TBranch>(this TBranch branch, IStep step) where TBranch : IBranch
        {
            branch.Attach(step);

            return branch;
        }

        public static TBranch Link<TBranch>(this IStep firstStep, IStep secondStep) where TBranch : IBranch, new()
        {
            var branch = new TBranch();

            branch.Attach(firstStep);
            branch.Attach(secondStep);

            return branch;
        }

        public static IBranch Flat(this IBranch firstBranch, IBranch secondBranch)
        {
            var branch = new Branch();

            firstBranch.Steps.ToList().ForEach(step => branch.Attach(step));
            secondBranch.Steps.ToList().ForEach(step => branch.Attach(step));

            return branch;
        }

        public static TBranch Flat<TBranch>(this IBranch firstBranch, IBranch secondBranch) where TBranch : IBranch, new()
        {
            var branch = new TBranch();

            firstBranch.Steps.ToList().ForEach(step => branch.Attach(step));
            secondBranch.Steps.ToList().ForEach(step => branch.Attach(step));

            return branch;
        }

    }

}