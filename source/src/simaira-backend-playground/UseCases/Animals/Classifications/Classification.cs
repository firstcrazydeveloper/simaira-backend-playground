namespace simaira_backend_playground.UseCases.Animals.Classifications
{
    public abstract class Classification
    {
        public virtual void Accept(ClassificationVisitor visitor) =>
            visitor.Visit(this);
    }
}
