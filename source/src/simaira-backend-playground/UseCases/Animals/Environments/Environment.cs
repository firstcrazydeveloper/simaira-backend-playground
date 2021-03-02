namespace simaira_backend_playground.UseCases.Animals.Environments
{
    public abstract class Environment
    {
        public abstract void Accept(EnvironmentVisitor visitor);
    }
}
