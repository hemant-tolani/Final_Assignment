using TicketBookingSystem.Entities;
using TicketBookingSystem.Repository;
using System.Net;
using System.Reflection;
using System.Threading;
using TicketBookingSystem.Entities;
using TicketBookingSystem.Repository;
Console.WriteLine("\n\t\t\t\t\t--- Ticket Booking System ---\t\t\t\t");

Console.CursorVisible = false;
bool blinking = true;

Thread blinkThread = new Thread(() =>
{
    while (blinking)
    {
        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write("Press enter to continue   ");
        Thread.Sleep(500);

        Console.SetCursorPosition(0, Console.CursorTop);
        Console.Write("                          ");
        Thread.Sleep(500);
    }
});

blinkThread.Start();
Console.ReadKey(true);
blinking = false;
blinkThread.Join();
Console.Clear();
string c = "y";
IEventRepository es = new EventService();
IVenueRepository v = new VenueService();
ICustomerRepository cm = new CustomerService();
IBookingRepository bookingRepository = new BookingService();

//IPayrollService ps = new PayrollService();
//ITaxService ts = new TaxService();
//IFinancialRecordService fs = new FinancialRecordService();

do
{
label1: Console.WriteLine("\n\t\t\t\t\t--- Ticket Booking System ---\t\t\t\t");
    Console.WriteLine("1 for Event");
    Console.WriteLine("2 for Booking");
    Console.WriteLine("3 for Customer");
    Console.WriteLine("4 for Venue");
    Console.WriteLine("5 for Exit");
    int option1 = int.Parse(Console.ReadLine());
    Console.Clear();

    switch (option1)
    {

        case 1:


            string ch = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- Ticket Booking System ---\t\t\t\t");
                Console.WriteLine("1 for Add Event");
                Console.WriteLine("2 for Update Event");
                Console.WriteLine("3 for Delete Event");
                Console.WriteLine("4 for Get All Events");
                Console.WriteLine("5 for Get Event By ID");
                Console.WriteLine("6 for Main Menu");
                int option = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (option)
                {
                    case 1:
                        Console.WriteLine("Customer Details ..");

                        Console.WriteLine("Enter Customer ID ...");
                        int c11 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Customer Name ...");
                        string c22 = Console.ReadLine();
                        Console.WriteLine("\nEnter Customer Email ...");
                        string c33 = Console.ReadLine();
                        Console.WriteLine("\nEnter Customer Phone Number ...");
                        string c44 = Console.ReadLine();


                        Console.WriteLine("Venue Details ..");

                        Console.WriteLine("Enter Venue ID ...");
                        int vvid = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Venue Name ...");
                        string vname = Console.ReadLine();
                        Console.WriteLine("\nEnter Venue Address ...");
                        string vad = Console.ReadLine();

                        Console.WriteLine("Event Details ..");

                        Console.WriteLine("Enter Event ID ...");
                        int id = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Event Name ...");
                        string name = Console.ReadLine();
                        Console.WriteLine("\nEnter the DATE of Event ...");
                        int date = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the MONTH of Event ...");
                        int month = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the YEAR of Event ...");
                        int year = int.Parse(Console.ReadLine());
                        Console.Write("Event Time (HH:MM): ");
                        TimeSpan eventTime = TimeSpan.Parse(Console.ReadLine());


                        int vid = vvid;

                        Console.WriteLine("\nEnter the Total Seats ...");
                        int phn = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the Available Seats ...");
                        int ava = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter the Ticket Price ...");
                        decimal price = decimal.Parse(Console.ReadLine());
                        Console.WriteLine("\nFor the Event Type ... \n1 for movie \n2 for sport \n3 for concert");
                        int d = int.Parse(Console.ReadLine());
                        string type;
                        if (d == 1)
                        {
                            type = "Movie";

                        }
                        else if (d == 2)
                        {
                            type = "Sport";
                        }
                        else
                        {
                            type = "Concert";
                        }


                        Customer cus11 = new Customer() 
                        { 
                            customer_id = c11,
                            customer_name = c22,
                            email = c33,
                            phone_number = c44
                        };

                        cm.Addcustomer(cus11);

                        Venue venue = new Venue() 
                        {
                            venue_id = vvid,
                            venue_name = vname,
                            address = vad
                        };

                        v.AddVenue(venue);

                        Event newEvent = new Event()
                        {

                            event_id = id,
                            event_name = name,
                            event_date = new DateTime(year, month, date),
                            event_time = eventTime,
                            venue_id = vid,
                            total_seats = phn,
                            available_seats = ava,
                            ticket_price = price,
                            event_type = type
                        };

                        es.AddEvent(newEvent);


                        
                        break;

                    case 2:

                        Console.WriteLine("Enter Event id: ");
                        int iidd = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new Event Name");
                        string new_name = Console.ReadLine();

                        es.UpdateEvent(iidd, new_name);
                       
                        break;

                    case 3:

                        Console.WriteLine("Enter Event id: ");
                        int iidd1 = int.Parse(Console.ReadLine());

                        es.DeleteEvent(iidd1);


                        break;

                    case 4:

                        List<Event> events = es.GetAllEvents();

                        Console.WriteLine("List of Events:");
                        foreach (Event ev in events)
                        {
                            Console.WriteLine($"Event ID: {ev.event_id}, Name: {ev.event_name}, Date: {ev.event_date}, Time: {ev.event_time}");
                        }
                        break;

                    case 5:

                        Console.WriteLine("Enter Event id: ");
                        int id2 = int.Parse(Console.ReadLine());

                        Event new_e = es.GetEventById(id2);
                        Console.WriteLine($"Event id: {new_e.event_id}\nEvent name: {new_e.event_name}\nEvent date: {new_e.event_date}\nEvent time: {new_e.event_time}");
                      
                        break;


                    case 6:
                       
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                ch = Console.ReadLine();
                Console.Clear();

            } while (ch == "y");

            break;

        case 2:

            string ch2 = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
                Console.WriteLine("1 for Add Booking");
                Console.WriteLine("2 for Update Booking");
                Console.WriteLine("3 for Delete Booking");
                Console.WriteLine("4 for Get_All_Bookings");
                Console.WriteLine("5 for Get_Booking_by_ID");
                Console.WriteLine("6 for Main Menu");
                int opt = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opt)
                {
                    case 1:
                        Console.WriteLine("Enter Booking details:");

                        Console.Write("Booking ID: ");
                        int bookingId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Event ID: ");
                        int eventId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Customer ID: ");
                        int customerId = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Number of Tickets: ");
                        int numTickets = Convert.ToInt32(Console.ReadLine());

                        Console.Write("Total Cost: ");
                        decimal totalCost = Convert.ToDecimal(Console.ReadLine());

                        Console.Write("Booking Date (YYYY-MM-DD): ");
                        DateTime bookingDate = Convert.ToDateTime(Console.ReadLine());

                        Booking newBooking = new Booking()
                        {
                            booking_id = bookingId,
                            event_id = eventId,
                            customer_id = customerId,
                            num_tickets = numTickets,
                            total_cost = totalCost,
                            booking_date = bookingDate
                        };

                        bookingRepository.AddBooking(newBooking);
                        Console.WriteLine("Booking added successfully!");


                        break;

                    case 2:

                        Console.WriteLine("Enter the booking id: ");
                        int bid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the new event_id: ");
                        int eid = int.Parse(Console.ReadLine());

                        bookingRepository.UpdateBooking(bid,eid);


                        break;

                    case 3:

                        Console.WriteLine("Enter the booking_id: ");
                        int bbid = int.Parse(Console.ReadLine());

                        bookingRepository.DeleteBooking(bbid);

                        break;

                    case 4:
                        List<Booking> allBookings = bookingRepository.GetAllBookings();
                        Console.WriteLine("\nAll Bookings:");
                        foreach (var booking in allBookings)
                        {
                            Console.WriteLine($"{booking.booking_id}: Event {booking.event_id}, Customer {booking.customer_id}, Tickets: {booking.num_tickets}, Cost: {booking.total_cost}");
                        }


                        break;

                        case 5:

                        Console.WriteLine("Enter the booking id: ");    

                        int bookingIdToRetrieve = int.Parse(Console.ReadLine()); 
                        Booking retrievedBooking = bookingRepository.GetBookingById(bookingIdToRetrieve);

                        if (retrievedBooking != null)
                        {
                            Console.WriteLine($"Booking Details for Booking ID {bookingIdToRetrieve}:");
                            Console.WriteLine($"Event ID: {retrievedBooking.event_id}");
                            Console.WriteLine($"Customer ID: {retrievedBooking.customer_id}");
                            Console.WriteLine($"Number of Tickets: {retrievedBooking.num_tickets}");
                            Console.WriteLine($"Total Cost: {retrievedBooking.total_cost}");
                            Console.WriteLine($"Booking Date: {retrievedBooking.booking_date}");
                        }
                        else
                        {
                            Console.WriteLine($"Booking with ID {bookingIdToRetrieve} not found.");
                        }

                        break;


                    case 6:
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                ch2 = Console.ReadLine();
                Console.Clear();

            } while (ch2 == "y");

            break;


        case 3:

            string ch3 = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
                Console.WriteLine("1 for Add Customer");
                Console.WriteLine("2 for Update Customer");
                Console.WriteLine("3 for Delete Customer");
                Console.WriteLine("4 for Get all Customers");
                Console.WriteLine("5 for Get Customer By id");
                Console.WriteLine("6 for Main Menu");
                int op11 = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op11)
                {
                    case 1:
                        Console.WriteLine("Enter customer details:");
                        Console.WriteLine("Id: ");
                        int iid = int.Parse(Console.ReadLine());

                        Console.Write("Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Email: ");
                        string email = Console.ReadLine();

                        Console.Write("Phone Number: ");
                        string phoneNumber = Console.ReadLine();

                        Customer newCustomer = new Customer()
                        {
                            customer_id = iid,
                            customer_name = name,
                            email = email,
                            phone_number = phoneNumber
                        };

                        cm.Addcustomer(newCustomer);

                        Console.WriteLine("Customer added successfully.");


                        break;

                    case 2:
                        Console.WriteLine("Enter the customer id: ");
                        int cid = int.Parse(Console.ReadLine());

                        Console.WriteLine("Enter the new name: ");
                        string eid = Console.ReadLine();

                        cm.UpdateCustomer(eid, cid);

                        break;

                    case 3:

                        Console.WriteLine("Enter the customer_id: ");
                        int cbid = int.Parse(Console.ReadLine());

                        cm.DeleteCustomer(cbid);

                        break;


                      

                    case 4:
                        List<Customer> allCustomers = cm.GetAllCustomers();

                        if (allCustomers.Count > 0)
                        {
                            Console.WriteLine("List of all customers:");
                            foreach (var customer in allCustomers)
                            {
                                Console.WriteLine($"Customer ID: {customer.customer_id}");
                                Console.WriteLine($"Name: {customer.customer_name}");
                                Console.WriteLine($"Email: {customer.email}");
                                Console.WriteLine($"Phone Number: {customer.phone_number}");
                                Console.WriteLine("---------------------------------");
                            }
                        }
                        else
                        {
                            Console.WriteLine("No customers found.");
                        }
                


                break;


                        case 5:
                        Console.WriteLine("Enter Customer ID:");
                        int customerId = Convert.ToInt32(Console.ReadLine());

                        Customer foundCustomer = cm.GetCustomerById(customerId);

                        if (foundCustomer != null)
                        {
                            Console.WriteLine("Customer found:");
                            Console.WriteLine($"Customer ID: {foundCustomer.customer_id}");
                            Console.WriteLine($"Name: {foundCustomer.customer_name}");
                            Console.WriteLine($"Email: {foundCustomer.email}");
                            Console.WriteLine($"Phone Number: {foundCustomer.phone_number}");
                        }
                        else
                        {
                            Console.WriteLine("Customer not found.");
                        }

                        break;
                    case 6:
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                ch3 = Console.ReadLine();
                Console.Clear();

            } while (ch3 == "y");

            break;
        case 4:

            string chh12 = "y";

            do
            {
                Console.WriteLine("\n\t\t\t\t\t--- WELCOME TO PayXpert ---\t\t\t\t");
                Console.WriteLine("1 for Add Venue: ");
                Console.WriteLine("2 for Update Venue");
                Console.WriteLine("3 for Delete");
                Console.WriteLine("4 for Get all venues");
                Console.WriteLine("5 for Get venue by id");
                Console.WriteLine("6 for Main Menu");
                int op1313 = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (op1313)
                {
                    case 1:
                        Console.WriteLine("Venue Details ..");

                        Console.WriteLine("Enter Venue ID ...");
                        int vvid = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter Venue Name ...");
                        string vname = Console.ReadLine();
                        Console.WriteLine("\nEnter Venue Address ...");
                        string vad = Console.ReadLine();

                        Venue venue = new Venue()
                        {
                            venue_id = vvid,
                            venue_name = vname,
                            address = vad
                        };

                        v.AddVenue(venue);

                        break;

                    case 2:

                        Console.WriteLine("Enter Venue ID ...");
                        int vvid1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nEnter new Venue Name ...");
                        string vname1 = Console.ReadLine();
                        Console.WriteLine("\nEnter new Venue Address ...");
                        string vad1 = Console.ReadLine();

                        Venue updatedVenue = new Venue()
                        {
                            venue_id = vvid1,
                            venue_name = vname1,
                            address = vad1
                        };

                        v.UpdateVenue(updatedVenue);

                        Console.WriteLine("Venue updated successfully.");


                        break;

                    case 3:

                        Console.WriteLine("Enter Venue id: ");
                        int venueIdToDelete = int.Parse(Console.ReadLine());

                        // Call the DeleteVenue method to delete the venue
                        v.DeleteVenue(venueIdToDelete);

                        Console.WriteLine("Venue deleted successfully.");


                        break;

                    case 4:
                        List<Venue> allVenues = v.GetAllVenues();

                        Console.WriteLine("All Venues:");
                        foreach (var v2 in allVenues)
                        {
                            Console.WriteLine($"Venue ID: {v2.venue_id}, Name: {v2.venue_name}, Address: {v2.address}");
                            
                        }

                        break;


                    case 5:
                        Console.Write("Enter Venue ID to get details: ");
                        if (int.TryParse(Console.ReadLine(), out int venueId))
                        {
                            Venue v1 = v.GetVenueById(venueId);

                            if (v1 != null)
                            {
                                Console.WriteLine("Venue Details:");
                                Console.WriteLine($"ID: {v1.venue_id}");
                                Console.WriteLine($"Name: {v1.venue_name}");
                                Console.WriteLine($"Address: {v1.address}");
                                // Print other details as needed based on the Venue class properties
                            }
                            else
                            {
                                Console.WriteLine("Venue with the provided ID was not found.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input for Venue ID.");
                        }

                        break;

                    case 6:
                        goto label1;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Wrong Choice ... Your Highness .. !!!\nGood-Bye .. ");
                        break;


                }

                Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the menu ... ?? (y/n)");
                chh12 = Console.ReadLine();
                Console.Clear();

            } while (chh12 == "y");

            break;
        case 5:
            Console.WriteLine("Thank you for using our application. Have a great day!");
            Environment.Exit(0);
            break;


            break;



    }


    Console.WriteLine("\n\n\n\t\t\t\t\tDo you want the main menu ... ?? (y/n)");
    c = Console.ReadLine();
    Console.Clear();

} while (c == "y");



