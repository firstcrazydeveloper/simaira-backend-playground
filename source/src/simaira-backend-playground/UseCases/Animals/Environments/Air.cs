namespace simaira_backend_playground.UseCases.Animals.Environments
{
    public class Air : Environment
    {
        public override void Accept(EnvironmentVisitor visitor) =>
            visitor.Visit(this);
    }
}
