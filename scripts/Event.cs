using Godot;
using System;
using System.Collections.Generic;

namespace EventSystem
{
    public partial class Event(string eventID, string description, List<EventEffect> effects) : Node2D
    {
        public string EventID { get; set; } = eventID;
        public string Description { get; set; } = description;
        public List<EventEffect> Effects { get; set; } = effects;
        public override string ToString()
        {
            return $"{EventID}: {Description}";
        }

        internal virtual bool CheckArgs(params object[] args)
        {
            // Check if the arguments are valid for this event
            // Any argument are valid for a BaseEvent
            return true;
        }
        

        /// <summary>
        /// Method <c>TriggerEvent</c> triggers the event and applies its effects.
        /// It checks the arguments passed to it and applies the effects to the target.
        /// </summary>
        /// <exception cref="ArgumentException">
        /// Thrown when the wrong arguments are passed to the event.
        /// </exception>
        public virtual bool TriggerEvent(params object[] objects)
        {
            if (!CheckArgs(objects))
            {
                throw new ArgumentException("Invalid arguments for event trigger.");
            }
            // Placeholder for event triggering logic
            return true;
        }
    }

    public class EventEffect(float probability)
    {
        public string EffectType { get; set; } = "GenericEventEffect";
        public float Probability { get; set; } = probability;

        public override string ToString()
        {
            return $"{EffectType}";
        }

        public bool IsEffectTriggered()
        {
            Random random = new();
            return random.NextDouble() < Probability;
            // this can in the future also be a function that takes its target into account
        }

        public virtual void ApplyToIndividual(Individual target)
        {
            // Logic to apply the effect to the target
        }

        public virtual void ApplyToLocation()
        {
            // Logic to apply the effect to a location
        }

        public virtual void ApplyToObject()
        {
            // Logic to apply the effect to a object, etc.
        }
    }

    public class TraitModifierEffect(float probability, string target, int value) : EventEffect(probability)
    {
        public new string EffectType { get; set; } = "TraitModifier";
        public string Target { get; set; } = target;
        public int Value { get; set; } = value;

        public override string ToString()
        {
            return $"{EffectType} on {Target} with value {Value}";
        }

        public override void ApplyToIndividual(Individual target)
        {
            // Logic to apply the effect to the target
            target.ModifyTrait(Target, Value);
        }
    }
}
