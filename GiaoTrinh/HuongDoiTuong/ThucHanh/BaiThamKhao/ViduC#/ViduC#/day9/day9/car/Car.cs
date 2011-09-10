using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace car
{
     
        public class Car
        {
            // Define the delegate types.
            public delegate void AboutToBlow(string msg);
            public delegate void Exploded(string msg);

            // Define member variables of each delegate type.
            private AboutToBlow almostDeadList;
            private Exploded explodedList;

            // Add members to the invocation lists using helper methods.
    /*      public void OnAboutToBlow(AboutToBlow clientMethod)
            { almostDeadList = clientMethod; }
            public void OnExploded(Exploded clientMethod)
            { explodedList = clientMethod; }
      */      
            // Update MultiCast Del
            public void OnAboutToBlow(AboutToBlow clientMethod)
            { almostDeadList += clientMethod; }
            public void OnExploded(Exploded clientMethod)
            { explodedList += clientMethod; }
            
            private bool carIsDead;
            private int currSpeed;
            private int maxSpeed;
            private string Nname;
            public Car(string name, int maxspeed, int speed)
            {
                Nname = name;
                maxSpeed = maxspeed;
                currSpeed = speed;
            }

            public void Accelerate(int delta)
            {
                // If the car is dead, fire Exploded event.
                if (carIsDead)
                {
                    if (explodedList != null)
                        explodedList("Sorry, this car is dead...");
                }
                else
                {
                    currSpeed += delta;
                    // Almost dead?
                    if (10 == maxSpeed - currSpeed
                    && almostDeadList != null)
                    {
                        almostDeadList("Careful buddy! Gonna blow!");
                    }
                    // Still OK!
                    if (currSpeed >= maxSpeed)
                        carIsDead = true;
                    else
                        Console.WriteLine("->CurrSpeed = {0}", currSpeed);
                }
            }  //end of Accelerate.

        }
    }

 
