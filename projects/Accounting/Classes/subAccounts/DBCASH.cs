﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using accounting.classes;
using Accounting.Models;
using accounting.classes.enums;

namespace accounting.classes.subAccounts
{
    public class DBCASHAccount : AssetAccount
    {
        public readonly int CATTYPE = AssetCategories.DBCASH;

        public Accounting.Models.account Create(int ownerEntityId,int currencyID,decimal balance=0)
        {
            using (var ctx = new AccContexts())
            {
                var duplicate = ctx.account
                    .Where(x => x.ownerEntityID == ownerEntityId && x.currencyID == currencyID && x.catTypeID ==CATTYPE)
                    .SingleOrDefault();
                if (duplicate != null)
                    ctx.DeleteObject(duplicate);
                var newAccount = new account()
                {
                    catTypeID=CATTYPE,
                    ownerEntityID=ownerEntityId,
                    currencyID=currencyID,
                    balance=balance
                };
                ctx.account.AddObject(newAccount);
                ctx.SaveChanges();

                return newAccount;
            }
        }

    }
}
