using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestRK
{
    public class JaratKezelo
    {
        List<Jarat> jaratok = new List<Jarat>();

        public void UjJarat(string jaratSzam, string repterHonnan, string repterHova, DateTime indulas)
        {
            if (Kereses(jaratSzam) == null)
            {
                jaratok.Add(new Jarat(jaratSzam, repterHonnan, repterHova, indulas));
            }
        }

        public DateTime MikorIndul(string jaratSzam)
        {
            return Kereses(jaratSzam).getIndulas();
        }

        public void Keses(string jaratSZam, int keses)
        {
            if (Kereses(jaratSZam).JaratSzam.Equals(jaratSZam))
            {
                Kereses(jaratSZam).setKeses(keses);
            }
        }

        private Jarat Kereses(string jaratSzam)
        {
            foreach (var i in jaratok)
            {
                if (i.getJaratszam().Equals(jaratSzam))
                {
                    return i;
                }
            }
            return null;
        }

        public List<string> JaratokRepuloterrol(string repter)
        {
            List<string> vissza = new List<string>();
            foreach (var i in jaratok)
            {
                if (i.getHonnanRepter().Equals(repter))
                {
                    vissza.Add(i.getHonnanRepter());
                }
            }
            return vissza;
        }
        

        class Jarat
        {
            public string JaratSzam;
            public string HonnanRepter;
            public string HovaRepter;
            public DateTime Indulas;
            public int Keses;

            public Jarat(string jaratSzam, string honnanRepter, string hovaRepter, DateTime indulas)
            {
                this.JaratSzam = jaratSzam;
                this.HonnanRepter = honnanRepter;
                this.HovaRepter = hovaRepter;
                this.Indulas = indulas;
                this.Keses = 0;
            }

            public string getJaratszam()
            {
                string vissza = this.JaratSzam;
                return vissza;
            }

            public void setKeses(int keses)
            {
                if (this.Keses + keses < 0)
                {
                    throw new NegativKesesException("Negativ keses exception");
                }
                else
                {
                    this.Keses += keses;
                }

            }       

            public string getHonnanRepter()
            {
                string vissza = this.HonnanRepter;

                return vissza;
            }

            public DateTime getIndulas()
            {
                DateTime ido = this.Indulas;

                return ido.AddMinutes(this.Keses);
            }
        }

        [Serializable()]
        public class NegativKesesException : Exception
        {
            
            public NegativKesesException(string message, System.Exception inner) : base(message, inner) { }

            public NegativKesesException(string message) : base(message) { }

            public NegativKesesException() : base() { }


            protected NegativKesesException(System.Runtime.Serialization.SerializationInfo info,
                System.Runtime.Serialization.StreamingContext context) : base(info, context)
            { }

        }
    }
}
