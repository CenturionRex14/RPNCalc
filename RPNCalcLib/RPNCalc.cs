namespace RPNCalcLib
{
    public record class RPNCalc()
    {
        protected List<double> stack = new();
        protected double mem = 0;

        public double x => (stack.Count > 0) ? stack[^1] : 0;
        public double y => (stack.Count > 1) ? stack[^2] : 0;

        public RPNCalc push(double num)
        {
            stack.Add(num);
            return this;
        }

        public double drop() {
            double rtn = x;
            stack.RemoveAt(stack.Count - 1);
            return rtn;
        }

        public RPNCalc add()
        {
            double temp = drop();
            stack[^1] += temp;
            return this;
        }

        public RPNCalc subtract() {
            double temp = drop();
            stack[^1] -= temp;
            return this;
        }

        public RPNCalc multiply()
        {
            throw new NotImplementedException();
            return this;
        }

        public RPNCalc divide()
        {
            throw new NotImplementedException();
        }


    }
}