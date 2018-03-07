using System;

namespace GrandPrix.Models
{
    public class UltrasoftTyre : Tyre
    {
        private double grip;
        public UltrasoftTyre(double hardness, double grip)
            : base(hardness)
        {
            this.grip = grip;
        }

        public override string Name => "Ultrasoft";

        public double Grip => this.grip;

        public override double Degradation
        {
            get => base.Degradation;
            protected set
            {
                if (value < 30)
                {
                    throw new ArgumentException("Blown Tyre");
                }

                base.Degradation = value;
            }
        }

        public override void ReduceDegradation()
        {
            double formulaResult = (this.Hardness + this.Grip);
            this.Degradation -= formulaResult;
        }
    }
}
