namespace simaira_backend_playground.UseCases.Animals.Classifications
{
    public class BonyFish : Classification
    {
        public override void Accept(ClassificationVisitor visitor)
        {
            base.Accept(visitor);
            visitor.Visit(this);
        }
    }
}
