namespace Concordanse.TextGradation
{
    public class Symbol
    {
        protected char Value;
        public Symbol(char symbol)
        {
            Value = symbol;
        }
        public Symbol()
        {
        }
        public override string ToString()
        {
            return this.Value.ToString();
        }
    }
}
