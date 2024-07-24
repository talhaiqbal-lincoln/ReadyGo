using System;
using System.Collections.Generic;
using System.Text;

namespace ReadyGo.Domain.Entities
{
    public class RequestModel
    {
        public string Draw{get;set;}
        public string Status{get;set;}
        public string Start {get;set;}
        public string Length {get;set;}
        public string SortColumn {get;set;}
        public string SortColumnDirection {get;set;}
        public string SearchValue {get;set;}
        public int PageSize {get;set;}
        public int Skip {get;set;}
        public string Role {get;set;}
    }
}
