﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccountingLib.Models;
using accounting.classes.bank;
using System.Transactions;

namespace accounting.classes
{
    public class Bank:Entity
    {
        public readonly int ENTITYTYPEID=(int)enums.entityType.bank;
        public int bankID;
        public string bankName;

        public Bank() :base(){}
        public Bank(int bankId):base()
        {   
            loadBankByBankID(bankId);
        }

        /// <summary>
        /// create new bank w/ optioanl addressing
        /// </summary>
        /// <param name="name"></param>
        /// <param name="address"></param>
        public void New(string name,Address address=null) 
        {
            using (var ctx = new AccContexts())
            {
                base.New((int)enums.entityType.bank);

                var _newBank = new AccountingLib.Models.bank() 
                {
                    name=name,
                    entityID=base.ENTITYID
                };
                ctx.bank.AddObject(_newBank);
                ctx.SaveChanges();

                if (address != null) 
                {
                
                }

                /*Update Class props*/
                this.bankID = _newBank.ID;
                this.bankName = _newBank.name;
            }
        }


        
        /// <summary>
        /// set or replace fee for anycardtype assignr to the bank
        /// </summary>
        /// <param name="cardType"></param>
        /// <param name="feeID"></param>
        public void setFeeForIntracCardType(decimal amount,string description) 
        {
            Fee fee = new Fee();
            fee.createNew(this.bankID, amount, description, (int)enums.cardType.DebitCard);
        }

        public void setFeeForCreditCardType(enums.ccCardType ccCardType, decimal amount, string description)
        {
            ccFee ccFee = new ccFee();
            ccFee.createNew(this.bankID, amount, description, (int)ccCardType);
        }

        /// <summary>
        /// assign a branch to the bank
        /// </summary>
        /// <param name="entityID"></param>
        public void createBranch(bankBranch branch) 
        {
            throw new NotImplementedException();
        }
        
        /// <summary>
        /// load the bank class params from DB by bankID
        /// </summary>
        /// <param name="bankID"></param>
        private void loadBankByBankID(int bankID)
        {
            using (var ctx = new AccContexts())
            {
                var _bank = ctx.bank
                    .Where(x => x.ID == bankID).SingleOrDefault();
                if (_bank == null)
                    throw new Exception("bank has not found");

                this.bankID = _bank.ID;
                this.bankName = _bank.name;
                base.ENTITYID = (int)_bank.entityID;
            }
        }
        public void loadBankByEntityID(int entityID)
        {
            using (var ctx = new AccContexts())
            {
                var _bank = ctx.bank
                    .Where(x => x.entityID == entityID).SingleOrDefault();
                if (_bank == null)
                    throw new Exception("bank has not found");

                this.bankID = _bank.ID;
                this.bankName = _bank.name;
                base.ENTITYID = (int)_bank.entityID;
            }
        }
    }
}
