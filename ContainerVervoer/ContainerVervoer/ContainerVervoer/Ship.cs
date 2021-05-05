using System;
using System.Collections.Generic;
using System.Text;

namespace ContainerVervoer
{
    public class Ship
    {
        //Waardevolle containers mogen geen containers bovenop wel op containers
        //Waardevolle containers moeten of voor of achteraan het schip
        //Gekoelde containers moeten voor aan het schip zitten
        //50% van het maximale gewicht moet benut zijn
        //het schip moet links en rechts evenveel gewicht hebben (σ: 20%)
        public int MaximumWeight { get; private set; }
        public Container[,,] Deck { get; private set; }
        public List<Container> TotalContainers { get; private set; }

        public Ship(int width, int length, int maxWeight)
        {
            Deck = new Container[width, 31, length];
            MaximumWeight = maxWeight;
        }
    }
}
