﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI.WebControls.Expressions;
using nok_cinema_web.DAL;
using nok_cinema_web.Models;
using nok_cinema_web.ViewModels;

namespace nok_cinema_web.BLL
{
    public class SeatsBLL
    {
        public SeatListViewModel GetSeatListByShowtime(DateTime showdate, int movieid)
        {
            var theatreBLL = new TheatreBLL();
            byte theatreId = theatreBLL.GetTheatreIdByShowtime(showdate, movieid);

            var seatListViewModel = new SeatListViewModel();
            seatListViewModel.Seats = new List<SeatViewModel>();
            var seatDAL = new SeatDAL();
            var seatList = seatDAL.GetSeatByTheatreId(theatreId);
            foreach (var seatEach in seatList)
            {
                var seat = new SeatViewModel
                {
                    SeatNumber = seatEach.SEATNUMBER,
                    SeatRow = seatEach.SEATROW
                };
                if (seatEach.SEATROW == "A" ||
                    seatEach.SEATROW == "B" ||
                    seatEach.SEATROW == "C")
                {
                    seat.SeatUrl = "~/Content/Images/seat-purple.png";
                    seat.Class = "S";
                }
                else
                {
                    seat.SeatUrl = "~/Content/Images/seat-red.png";
                    seat.Class = "N";
                }
                seatListViewModel.Seats.Add(seat);
            }
            seatListViewModel.TheatreId = theatreId;
            seatListViewModel.SeatArray = GetSeatListForJavascriptArray(seatListViewModel);
            seatListViewModel.UnavailableSeatArray =
                GetUnavailableSeatListForJavascriptArray(new SHOWTIME { SHOWDATE = showdate, MOVIEID = movieid });
            return seatListViewModel;
        }

        public List<string> GetSeatListForJavascriptArray(SeatListViewModel seatListViewModel)
        {
            var seatArray = new List<string>();
            string seatFormat = string.Empty;
            foreach (var seat in seatListViewModel.Seats)
            {
                seatFormat += seat.Class;
                if (seat.SeatNumber == 10)
                {
                    seatFormat += "_";
                }
                else if (seat.SeatNumber == 20)
                {
                    seatArray.Add(seatFormat);
                    seatFormat = string.Empty;
                }
            }
            return seatArray;
        }

        public List<string> GetUnavailableSeatListForJavascriptArray(SHOWTIME showtime)
        {
            var showtimeDAL = new ShowtimeDAL();
            var seatList = new List<SEAT>();
            seatList = showtimeDAL.GetUnavailableSeatsByShowtime(showtime.SHOWDATE, showtime.MOVIEID);

            string seatFormat = string.Empty;
            var seatArray = new List<string>();
            foreach (var seat in seatList)
            {
                seatFormat = (seat.SEATROW + "_" + seat.SEATNUMBER);
                seatArray.Add(seatFormat);
            }
            return seatArray;
        }
    }
}