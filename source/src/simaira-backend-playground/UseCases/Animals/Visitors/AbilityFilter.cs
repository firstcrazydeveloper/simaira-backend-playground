﻿namespace simaira_backend_playground.UseCases.Animals.Visitors
{
    using System;
    using System.Collections.Generic;
    using simaira_backend_playground.UseCases.Animals.Abilities;

    public class AbilityFilter<T> : AbilityVisitor
        where T : Ability
    {
        private Animal Target { get; }
        public IEnumerable<Tuple<Animal, T>> FilteredAbilities => this.Accumulator;

        private IList<Tuple<Animal, T>> Accumulator { get; } = new List<Tuple<Animal, T>>();

        public AbilityFilter(Animal target)
        {
            this.Target = target;
        }

        public override void Visit(Ability ability)
        {
            if (ability.GetType() == typeof(T))
                this.Accumulator.Add(Tuple.Create(this.Target, (T)ability));
        }
    }
}
