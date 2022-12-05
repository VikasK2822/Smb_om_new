using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smb_om.Model
{
    public class OrderQuickSearch
    {
       public List<QuickSearchResult> quickSearchResults { get; set; }
        public List<detailSearchResult> detailSearchResults { get; set; }
        
        public string CBRPhoneNumber { get; set; }
        public string BillingAccountNumber { get; set; }
        public string OrderNumber { get; set; }
        public string commonOrderNumber { get; set; }
        public string quickBusinessName { get; set; }
        public bool Isordertype { get; set; }

        public DetailSearch detailSearch { get; set; }
        public List<partnersearch> partners { get; set; }
        public List<ordertype> Ordertypes { get; set; }
        public List<affiliatesearch> affiliates { get; set; }
        public List<region> regions { get; set; }
        public List<orderstate> orderstates { get; set; }
        public List<productstate> productstates { get; set; }
        public List<statereason> statereasons { get; set; }



    }

    public class QuickSearchResult
    {
        public string OrderNumber { get; set; }
        public string partnerName { get; set; }
        public string Product { get; set; }
        public string Status { get; set; }
        public string Business_Name { get; set; }
        public string Repid { get; set; }
        public string LastUpadtedDate { get; set; }
        public string ReceivedDate { get; set; }

    }

    public class detailSearchResult
    {
        public string OrderNumber { get; set; }
        public string partnerName { get; set; }
        public string Product { get; set; }
        public string Status { get; set; }
        public string Business_Name { get; set; }
        public string Repid { get; set; }
        public string LastUpadtedDate { get; set; }
        public string ReceivedDate { get; set; }

    }

    public class DetailSearch
    {
        public string OrderNumber { get; set; }
        public string contactNumber { get; set; }
        public string LastName { get; set; }
        public string BusinesName { get; set; }
        public string BillingAccountNumber { get; set; }
        public string CommonOrderNumber { get; set; }
        public string OrderType { get; set; }
        public bool IsOrderType { get; set; }
        public string Partnerid { get; set; }
        public string Affiliateid { get; set; }
        public string region { get; set; }
        public string orderstate { get; set; }
        public string product { get; set; }       
        public string productState { get; set; }
        public string productStateReason { get; set; }
        public string startDate { get; set; }
        public string enddate { get; set; }

    }

    public class partnersearch
    {
        public string text { get; set; }
        public string value { get; set; }


    }
    public class ordertype
    {
        public string text { get; set; }
        public string value { get; set; }


    }
    public class affiliatesearch
    {
        public string text { get; set; }
        public string value { get; set; }


    }
    public class region
    {
        public string text { get; set; }
        public string value { get; set; }


    }

    public class orderstate
    {
        public string text { get; set; }
        public string value { get; set; }


    }

    public class product
    {
        public string text { get; set; }
        public string value { get; set; }


    }

    public class productstate
    {
        public string text { get; set; }
        public string value { get; set; }


    }

    public class statereason
    {
        public string text { get; set; }
        public string value { get; set; }


    }

}
