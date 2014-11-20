using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE2300KurtisBridgemanICA15
{
    public abstract class Gate
    {
        //protected properties for gate ins/out
        protected bool inA;
        protected bool inB;
        protected bool outAB;

        //getters for ins/out
        protected bool inputA
        {
            get { return inA; }
        }

        protected bool inputB
        {
            get { return inB; }
        }

        public int output
        {
            get { return (outAB ? 1 : 0); }
        }

        //public methods
        public void Set(int A, int B)
        {
            inA = 0 == A ? false : true;
            inB = 0 == B ? false : true;
        }

        //public user interface
        public void Latch()
        {
            vLatch();
        }
        public string Name()
        {
            return vName();
        }

        //non-virtual interface
        protected abstract void vLatch();
        protected abstract string vName();
    }


    public class NandGate : Gate
    {
        protected override void vLatch()
        {
            outAB = !(inA && inB);
        }

        protected override string vName()
        {
            return "NAND";
        }
    }

    public class OrGate : Gate
    {
        protected override void vLatch()
        {
            outAB = (inA || inB);
        }

        protected override string vName()
        {
            return "OR";
        }
    }

    public class XorGate : Gate
    {
        protected override void vLatch()
        {
            outAB = ((inA || inB) && !(inA && inB));
        }

        protected override string vName()
        {
            return "XOR";
        }
    }

    public class AndGate : NandGate
    {
        protected override void vLatch()
        {
            base.vLatch();
            outAB = !outAB;
        }

        protected override string vName()
        {
            return "AND";
        }
    }

}
