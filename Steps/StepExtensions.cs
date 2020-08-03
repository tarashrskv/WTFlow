using System;
using WTFlow.Outcome;
using WTFlow.Steps.Interfaces;

namespace WTFlow.Steps
{

    public static class StepExtensions
    {

        public static TStep Setup<TStep>(this TStep step, Action<TStep> setup) where TStep : IConfigurableStep
        {
            step.SetupActions.Add(() => setup(step));

            return step;
        }

        public static TCurrentStep Setup<TPreviousStep, TCurrentStep>(this TCurrentStep currentStep,
                                                                      TPreviousStep previousStep,
                                                                      Action<TPreviousStep, TCurrentStep> setup) where TPreviousStep : IConfigurableStep
                                                                                                                 where TCurrentStep : IConfigurableStep
        {
            currentStep.SetupActions.Add(() => setup(previousStep, currentStep));

            return currentStep;
        }

        public static TNextStep Then<TNextStep>(this IStep currentStep) where TNextStep : IStep, new()
        {
            var nextStep = new TNextStep();

            currentStep.Attach(new SimpleOutcome(nextStep));

            return nextStep;
        }

        public static TNextStep Then<TNextStep>(this IStep currentStep, TNextStep nextStep) where TNextStep : IStep
        {
            currentStep.Attach(new SimpleOutcome(nextStep));

            return nextStep;
        }

        public static TNextStep On<TCurrentStep, TNextStep>(this TCurrentStep currentStep,
                                                            Predicate<TCurrentStep> condition) where TCurrentStep : IConfigurableStep
                                                                                               where TNextStep : IStep, new()
        {
            var nextStep = new TNextStep();

            currentStep.Attach(new SatisfiableOutcome(() => condition(currentStep), nextStep));

            return nextStep;
        }

        public static TNextStep On<TCurrentStep, TNextStep>(this TCurrentStep currentStep,
                                                            Predicate<TCurrentStep> condition,
                                                            TNextStep nextStep) where TCurrentStep : IConfigurableStep
                                                                                where TNextStep : IStep
        {
            currentStep.Attach(new SatisfiableOutcome(() => condition(currentStep), nextStep));

            return nextStep;
        }

    }

}