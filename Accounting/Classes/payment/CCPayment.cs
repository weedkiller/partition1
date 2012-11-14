﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using accounting.classes.enums;
using Accounting.Models;
using System.Transactions;

namespace accounting.classes
{
    public class ccPayment : externalPayment
    {
        public readonly int EXTPAYMENTTYPEID= (int)enums.extPaymentType.CreditPayment;

        public int ccPaymentID;
        public int extPaymentTypeID;
        public string ccPaymentDescription;

        public ccPayment(int cardID):base(cardID) { }
        
        public override void pay(int payerEntityID, int payeeEntityID, decimal amount, int currencyID)
        {
            using (var ctx = new AccContext())
            using (var ts = new TransactionScope())
            {
                base.pay(payerEntityID, payeeEntityID, amount, currencyID);
                
                var _ccPayment = new Accounting.Models.ccPayment()
                {
                    extPaymentID=base.extPaymentID,
                    extPaymentTypeID=this.EXTPAYMENTTYPEID
                };
                ctx.ccPayment.AddObject(_ccPayment);
                ctx.SaveChanges();

                ts.Complete();

                this.mapData(_ccPayment);

            }
        }
        /// <summary>
        /// convert payment record from model to class data and renew class stat
        /// </summary>
        /// <param name="payment"></param>
        private void mapData(Accounting.Models.ccPayment ccPayment)
        {
            this.ccPaymentID = ccPayment.ID;
            this.extPaymentID = (int)ccPayment.extPaymentID;
            this.extPaymentTypeID = (int)ccPayment.extPaymentTypeID;
            this.ccPaymentDescription = (string)ccPayment.description;
        }
    }
  
}