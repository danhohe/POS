using System.ComponentModel;

namespace Caravan.Logic
{
    public class Caravan
    {
        private class Element
        {
            public Element(PackAnimal animal, Element? next)
            {
                Animal = animal;
                Next = next;
            }
            public PackAnimal Animal { get; set; }
            public Element? Next { get; set; }
        }

        #region fields
        private Element? _first = null;
        #endregion fields
        public Caravan()
        {
        }

        /// <summary>
        /// Gibt die Anzahl der Tragtiere in der Karavane zurück
        /// </summary>
        public int Count
        {
            get
            {
                int result = 0;
                Element? run = _first;

                while (run != null)
                {
                    result++;
                    run = run.Next;
                }
                return result;
            }
        }

        /// <summary>
        /// Anzahl der Ballen der gesamten Karawane
        /// </summary>
        public int Load
        {
            get
            {
                int result = 0;
                Element? run = _first;

                while (run != null)
                {
                    result += run.Animal.Load;
                    run = run.Next;
                }
                return result;
            }

        }

        /// <summary>
        /// Indexer, der ein Packtier nach Namen sucht und zurückgibt.
        /// Existiert das Packtier nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="name">Name des Packtiers</param>
        /// <returns>Packtier</returns>
        public PackAnimal? this[string name]
        {
            get
            {

                Element? run = _first;

                while (run != null && run.Animal.Name != name)
                {
                    run = run.Next;
                }
                return run != null ? run.Animal : null;
            }
        }

        /// <summary>
        /// Indexer, der ein Packtier entsprechend der Position in der Karawane sucht 
        /// und zurückgibt (0 --> Erstes Tier in der Karawane)
        /// Existiert die Position nicht, wird NULL zurückgegeben.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public PackAnimal? this[int index]
        {
            get
            {
                int counter = 0;
                Element? run = _first;

                while (run != null && counter < index)
                {
                    counter++;
                    run = run!.Next;
                }
                return run?.Animal;
            }
        }

        /// <summary>
        /// Liefert die Reisegeschwindigkeit dieser Karawane, die
        /// vom langsamsten Tier bestimmt wird. Dabei wird die Ladung 
        /// der Tiere berücksichtigt
        /// </summary>
        public int Pace
        {
            get
            {
                return FindSlowestAnimal().Pace;
            }
        }

        public PackAnimal FindSlowestAnimal()
        {
            Element? run = _first;
            Element? slowest = run;

            while (run!.Next != null)
            {
                if (slowest!.Animal.Pace > run.Animal.Pace)
                {
                    slowest = run;
                }
                run = run.Next;
            }
            return slowest!.Animal;
        }

        /// <summary>
        /// Fügt ein Tragtier in die Karawane ein.
        /// Dem Tragtier wird mitgeteilt, in welcher Karawane es sich nun befindet.
        /// </summary>
        /// <param name="packAnimal">einzufügendes Tragtier</param>
        public void AddPackAnimal(PackAnimal? packAnimal)
        {
            if (packAnimal!.MyCaravan != null)
            {
                packAnimal.MyCaravan.RemovePackAnimal(packAnimal);
            }
            if (_first == null)
            {
                _first = new Element(packAnimal, _first);
            }
            else
            {
                Element? run = _first;

                while (run.Next != null)
                {
                    run = run.Next;
                }
                run.Next = new Element(packAnimal, null);
            }
            if (packAnimal.MyCaravan == null)
            {
                packAnimal.MyCaravan = this;
            }
        }

        /// <summary>
        /// Nimmt das Tragtier o aus dieser Karawane heraus
        /// </summary>
        /// <param name="packAnimal">Tragtier, das die Karawane verläßt</param>
        public void RemovePackAnimal(PackAnimal packAnimal)
        {
            packAnimal.MyCaravan = null;
            if (_first != null)
            {
                if (_first.Animal == packAnimal)
                {
                    _first = _first.Next;
                }
                else
                {
                    Element? run = _first;

                    while (run != null && run.Next != null)
                    {
                        if (run.Next.Animal == packAnimal)
                        {
                            run.Next = run.Next.Next;
                        }
                        run = run.Next;
                    }
                }
            }
        }

        /// <summary>
        /// Entlädt alle Tragtiere dieser Karawane
        /// </summary>
        public void Unload()
        {
            Element? run = _first;
            if (run != null)
            {
                while (run != null)
                {
                    run.Animal.Load = 0;
                    run = run.Next;
                }
            }
        }

        /// <summary>
        /// Verteilt zusätzliche Ballen Ladung so auf die Tragtiere 
        /// der Karawane, dass die Reisegeschwindigkeit möglichst hoch bleibt
        /// Tipp: Gib immer einen Ballen auf das belastbarste (schnellste) Tier bis alle Ballen vergeben sind
        /// </summary>
        /// <param name="load">Anzahl der Ballen Ladung</param>
        public void AddLoad(int load)
        {
            int loadToDistribute = load;

            while (loadToDistribute > 0)
            {
                FindFastestAnimal().Load++;
                loadToDistribute--;
            }
        }

        public PackAnimal FindFastestAnimal()
        {
            Element? run = _first;
            Element? fastest = run;

            while (run!.Next != null)
            {
                if (fastest!.Animal.Pace < run.Animal.Pace)
                {
                    fastest = run;
                }
                run = run.Next;
            }
            return fastest!.Animal;
        }
    }
}
