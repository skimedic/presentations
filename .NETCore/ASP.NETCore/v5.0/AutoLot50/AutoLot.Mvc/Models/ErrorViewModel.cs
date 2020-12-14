// Copyright Information
// ==================================
// AutoLot - AutoLot.Mvc - ErrorViewModel.cs
// All samples copyright Philip Japikse
// http://www.skimedic.com 2020/12/13
// ==================================

namespace AutoLot.Mvc.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
