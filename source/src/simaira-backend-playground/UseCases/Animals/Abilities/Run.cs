namespace simaira_backend_playground.UseCases.Animals.Abilities
{
    using System;
    public class Run : Ability
    {
        public override void Start()
        {
            Console.WriteLine(": Now I'm running.");
        }

        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}
