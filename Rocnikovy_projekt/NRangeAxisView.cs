namespace Rocnikovy_projekt
{
    internal class NRangeAxisView
    {
        private NRange1DD nRange1DD;
        private bool v1;
        private bool v2;

        public NRangeAxisView(NRange1DD nRange1DD, bool v1, bool v2)
        {
            this.nRange1DD = nRange1DD;
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}