using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE2300KurtisBridgemanICA15
{
    public abstract class Gate
    {
        //protected properties for gate ins/outs
        protected bool inA
        {
            get { return inA; }
            set { inA = value; }
        }

        protected bool inB
        {
            get { return inB; }
            set { inB = value; }
        }

        protected bool outAB
        {
            get { return outAB; }
            set { outAB = value; }
        }

        //public methods
        public void Set(bool A, bool B)
        {
            inA = A;
            inB = B;
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
            base.Latch();
            outAB = !outAB;
        }

        protected override string vName()
        {
            return "AND";
        }
    }

}
