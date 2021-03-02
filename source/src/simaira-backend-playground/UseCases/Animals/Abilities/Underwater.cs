namespace simaira_backend_playground.UseCases.Animals.Abilities
{
    using System;
    public class Underwater : Swim
    {
        public override void Accept(AbilityVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }

        public override void Start()
        {
            Console.WriteLine("Animal says: Now I'm Under water swimming.");
        }
    }
}
