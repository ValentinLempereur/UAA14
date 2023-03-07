using System;
using System.Collections.Generic;
using System.Text;

namespace Calculette_Binaire_WPF_POO
{
    
    class Function
    {
        private ushort[] _t;


        public Function(string nombreBinaire)
        {
            _t = RemplirTableau(nombreBinaire);
        }


        public Function()
        {
            _t = new ushort[8];
        }

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

        public Function Additionne(Function t2)
        {
            Function tRes = new Function();
            ushort report = 0;
            ushort res;
            bool ok = true;

            for (int i = 7; i > 0; i--)
            {
                res = (ushort)(_t[i] + t2.T[i] + report);

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
                    tRes.T[i] = 1;
                }
                else if (res % 2 == 1)
                {
                    tRes.T[i] = 1;
                }
                else
                {
                    tRes.T[i] = 0;
                }
            }
            if (report == 1)
            {
                ok = false;
            }

            return tRes;
        }


        public Function Soustraction(Function t2)
        {
            int[] tTemp = new int[8];
            Function tRes = new Function();
            bool ok = true;

            for (int i = 0; i < 8; i++)
            {
                tTemp[i] = _t[i] - t2.T[i];
            }

            for (int i = 7; i > 0; i--)
            {
                if (tTemp[i] == -1)
                {
                    t2.T[i - 1] = (ushort)(t2.T[i - 1] + 1);
                    _t[i] = (ushort)(_t[i] + 2);
                }

                if (_t[i] < t2.T[i])
                {
                    t2.T[i - 1] = (ushort)(t2.T[i - 1] + 1);
                    _t[i] = (ushort)(_t[i] + 2);
                }
                tRes.T[i] = (ushort)(_t[i] - t2.T[i]);
            }

            if (_t[0] >= t2.T[0])
            {
                tRes.T[0] = (ushort)(_t[0] - t2.T[0]);
            }
            else
            {
                ok = false;
            }

            return tRes;
        }

        public ushort[] T
        {
            get
            {
                return _t;
            }
            set
            {
                _t = value;
            }
        }
    }
}
