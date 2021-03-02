namespace simaira_backend_playground.UseCases.Animals.Abilities
{
    public abstract class Ability
    {
        public virtual void Accept(AbilityVisitor visitor) =>
            visitor.Visit(this);

        public abstract void Start();
    }
}
