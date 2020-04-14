/*
 * https://refactoring.guru/ru/design-patterns/state
 * https://metanit.com/sharp/patterns/3.6.php
 * https://bool.dev/blog/detail/pattern-sostoyanie
 */

namespace Patterns.BehavioralPatterns.State
{
    internal abstract class State
    {
        public abstract void Handle(Context context);
    }

    internal class Context
    {
        public State State { get; set; }

        public Context(State state)
        {
            State = state;
        }

        public void Request()
        {
            State.Handle(this);
        }
    }

    internal class StateA : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateB();
        }
    }

    internal class StateB : State
    {
        public override void Handle(Context context)
        {
            context.State = new StateA();
        }
    }
}