﻿namespace simaira_backend_playground.UseCases.Animals.Environments
{
    public class Water : Environment
    {
        public override void Accept(EnvironmentVisitor visitor) =>
            visitor.Visit(this);
    }
}
