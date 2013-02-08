﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Runtime.Serialization;

using System.ServiceModel.Web;
using System.ServiceModel;


using AccountingLib.Models;
using accounting.classes;
using System.ServiceModel.Activation;


namespace RyanGoreshi
{
    [DataContract(Namespace = "http://domain/testData")]
    public class testData
    {
        [DataMember]
        public string name;
    }
    
    
    [ServiceContract(SessionMode = SessionMode.Allowed)]
    public interface IAccountingV1
    {
        [WebGet(UriTemplate = "getInvoiceSum", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Invoice getInvoiceServicesSumAmt();

        [WebGet(UriTemplate = "createInvoice", ResponseFormat = WebMessageFormat.Json)]
        [OperationContract]
        Invoice createinvoice();
        
    }

    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
    public class AccountingV1: IAccountingV1
    {
        public Invoice getInvoiceServicesSumAmt()
        {
            accounting.classes.Invoice x = new accounting.classes.Invoice(1);
            return x;
        }
        public Invoice createinvoice()
        {
            throw new NotImplementedException();
        }
    }
}
