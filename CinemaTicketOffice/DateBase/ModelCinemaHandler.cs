using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinemaTicketOffice.DateBase
{
    public class ModelCinemaHandler
    {
        private static CinemaEntities context;

        public static CinemaEntities getContext()
        {
            if (context == null)
            {
                context = new CinemaEntities();
            }
            return context;
        }
    }
}
