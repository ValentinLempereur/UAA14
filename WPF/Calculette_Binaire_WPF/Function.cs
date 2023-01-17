using System;
using System.Collections.Generic;
using System.Text;

namespace Calculette_Binaire_WPF
{
    class Function
    {
        public ushort[] RemplirTableau(string nombreBinaire)
        {
            ushort[] tabBin = new ushort[8];

            for (int i = 0; i < 8; i++)
            {
                tabBin[i] = 0;
            }

            for (int i = 0; i < nombreBinaire.Length; i++)
            {
                tabBin[7 - i] = ushort.Parse(nombreBinaire[nombreBinaire.Length - 1 - i].ToString());
            }

            return tabBin;
        }

        public void Additionne(out ushort[] tRes, out bool ok, ushort[] t1, ushort[] t2)
        {
            tRes = new ushort[8];
            ushort report = 0;
            ushort res;
            ok = true;

            for (int i = 7; i > 0; i--)
            {
                res = (ushort)(t1[i] + t2[i] + report);

                if ((int)res / 2 == 0)
                {
                    report = 0;
                }
                else
                {
                    report = 1;
                }

                if (res == 1)
                {
                    tRes[i] = 1;
                }
                else if (res % 2 == 1)
                {
                    tRes[i] = 1;
                }
                else
                {
                    tRes[i] = 0;
                }
            }
            if (report == 1)
            {
                ok = false;
            }
        }


        public bool Soustraction(ushort[] t1, ushort[] t2, out ushort[] tRes)
        {
            int[] tTemp = new int[8];
            tRes = new ushort[8];
            bool ok = true;

            for (int i = 0; i < 8; i++)
            {
                tTemp[i] = t1[i] - t2[i];
            }

            for (int i = 7; i > 0; i--)
            {
                if (tTemp[i] == -1)
                {
                    t2[i - 1] = (ushort)(t2[i - 1] + 1);
                    t1[i] = (ushort)(t1[i] + 2);
                }

                if (t1[i] < t2[i])
                {
                    t2[i - 1] = (ushort)(t2[i - 1] + 1);
                    t1[i] = (ushort)(t1[i] + 2);
                }
                tRes[i] = (ushort)(t1[i] - t2[i]);
            }

            if (t1[0] >= t2[0])
            {
                tRes[0] = (ushort)(t1[0] - t2[0]);
            }
            else
            {
                ok = false;
            }

            return ok;
        }
    }
}
