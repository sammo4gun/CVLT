using System;
using EventSystem;
using Godot;

namespace NaturalEvents
{
    public partial class SleepEvent : Event
    {
        public SleepEvent() : base("Sleep", "A peaceful night in the forest.",
        [
            new TraitModifierEffect(0.2f, "Strength", 5),
            new TraitModifierEffect(0.8f, "Joy", 3)
        ])
        {
        }

        internal override bool CheckArgs(params object[] args)
        {
            // Check if the arguments are valid for this event
            if (args.Length == 1 && args[0] is Individual)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Method <c>TriggerEvent</c> triggers the sleep event and applies its effects.
        /// </summary>
        /// <param name="target">The individual who is attempting to sleep.</param>
        /// <exception cref="ArgumentException">
        /// Thrown when the wrong arguments are passed to the event.
        /// </exception>
        public override bool TriggerEvent(params object[] objects)
        {
            if (!CheckArgs(objects))
            {
                throw new ArgumentException("Invalid arguments for event trigger.");
            }

            Individual target = (Individual)objects[0];

            // Apply effects to the target individual
            foreach (var effect in Effects)
            {
                if (effect.IsEffectTriggered())
                {
                    effect.ApplyToIndividual(target);
                }
            }
            
            GD.Print($"Sleep event triggered with description: {Description}");
            return true;
        }
    }
}