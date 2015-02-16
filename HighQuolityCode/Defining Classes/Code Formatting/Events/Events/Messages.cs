using System;
using System.Collections.Generic;


using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

static class Messages
{
    public static void EventAdded()
    { EventsTest.Output.Append("Event added\n"); }
    public static void EventDeleted(int x)
    {
        if (x == 0) NoEventsFound();

        else EventsTest.Output.AppendFormat("{0} events deleted\n", x);
    }
    public static void NoEventsFound() { EventsTest.Output.Append("No events found\n"); }
    public static void PrintEvent(Event eventToPrint)
    {


        if (eventToPrint != null)
        {
            EventsTest.Output.Append(eventToPrint + "\n");
        }
    }
}
