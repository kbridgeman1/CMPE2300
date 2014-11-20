using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMPE2300KurtisBridgemanICA15
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo inputKey;

            do
            {
                inputKey = Console.ReadKey(true);

                if (inputKey.Key == ConsoleKey.A)
                {
                    Gate[] gt = new Gate[4] { new AndGate(), new NandGate(), new OrGate(), new XorGate() };

                    foreach (Gate g in gt)
                        Console.WriteLine(ToTable(g));
                }


                if (inputKey.Key == ConsoleKey.S)
                {
                    Gate[] gt = new Gate[10] { new AndGate(), new OrGate(), new NandGate(), new XorGate(), new NandGate(), new OrGate(), new AndGate(), new XorGate(), new AndGate(), new OrGate() };
                    Console.WriteLine(ToTables(gt));
                }

            } while (true);
        }



        private static string ToTable(Gate g)
        {
            StringBuilder st = new StringBuilder();
            st.AppendLine("A B  " + g.Name());

            for (int a = 0; a < 2; a++)
                for (int b = 0; b < 2; b++)
                {
                    g.Set(a, b);
                    g.Latch();
                    st.AppendLine(a.ToString() + " " + b.ToString() + "  " + (g.output.ToString()));
                }

            return st.ToString();
        }


        private static string ToTables(Gate[] g)
        {
            StringBuilder st = new StringBuilder();
            st.AppendLine("A B C D  O");

            for (int a = 0; a < 2; a++)
                for (int b = 0; b < 2; b++)
                    for (int c = 0; c < 2; c++)
                        for (int d = 0; d < 2; d++)
                        {
                            g[0].Set(a, a);
                            g[0].Latch();

                            g[1].Set(a, b);
                            g[1].Latch();

                            g[2].Set(b, c);
                            g[2].Latch();

                            g[3].Set(g[2].output, c);
                            g[3].Latch();

                            g[4].Set(g[0].output,g[1].output);
                            g[4].Latch();

                            g[5].Set(g[0].output, g[4].output);
                            g[5].Latch();

                            g[6].Set(g[1].output, g[3].output);
                            g[6].Latch();

                            g[7].Set(g[3].output, d);
                            g[7].Latch();

                            g[8].Set(g[5].output, g[6].output);
                            g[8].Latch();

                            g[9].Set(g[8].output, g[7].output);
                            g[9].Latch();

                            st.AppendLine(a.ToString() + " " + b.ToString() + " " + c.ToString() + " " + d.ToString() + "  " + g[9].output.ToString());
                        }

            return st.ToString();
        }

    }
}
