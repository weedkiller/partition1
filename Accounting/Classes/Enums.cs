﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Accounting.Classes.Enums
{   

    public class ASSET
    {
        /// <summary>
        /// static value
        /// </summary>
        public static readonly int Value = 1;
    }
    public class OE
    {
        /// <summary>
        /// static value
        /// </summary>
        public static readonly int Value = 2;
    }
    public class LIB
    {
        /// <summary>
        /// static value
        /// </summary>
        public static readonly int Value = 3;
    }
    public class AssetCategories : ASSET
    {
        /// <summary>
        /// static value
        /// </summary>
        public static readonly int AR = 1;
        public static readonly int  W= 2;
        public static readonly int  TA= 3;
        public static readonly int  DBCASH= 4;
        public static readonly int  PP= 5;
        public static readonly int  CCCASH= 6;
        public static readonly int  EE= 7;

        public static readonly Dictionary<int,string> list = new Dictionary<int,string>() 
        {
           {1,"AR"},
           {2,"W"},
           {3,"TA"},
           {4,"DBCASH"},
           {5,"PP"},
           {6,"CCCASH"},
           {7,"EE"}
        };
    }
    public class OECategories : OE
    {
        /// <summary>
        /// static value
        /// </summary>
        public static readonly int INC = 8;
        public static readonly int EXP = 9;

        public static readonly Dictionary<int, string> list = new Dictionary<int, string>() 
        {
           {8,"INC"},
           {9,"EXP"}
        };
    }
    public class LibCategories : LIB
    {
        /// <summary>
        /// static value
        /// </summary>
        public static readonly int AP = 10;

        public static readonly Dictionary<int,string> list = new Dictionary<int,string>() 
        {
           {10,"AP"}
        };
    }

    //entities Enums
    public enum entityType {Organization=1,Office=2,Person=3}
    public enum officeType {TemporaryOffice=1,HeadOffice=2,BankBranch=3}
    public enum userType { AppUser=1,SysUser=2}
    public enum sysUserType{NormalsysUser=1,AdminSysUser=2}

    public enum paymentType{External=1,Internal=2}
    public enum extPaymentType{CreditPayment=1,InteracPayment=2}

    public enum ccCardType{MC=1,Visa=2}
    public enum cardType{DebitCard=1,CreditCard=2}

    public enum invoiceStat{Generated=1,Refunded=2,Voided=3}
    public enum currencyType{ Real=1,UnReal=2}



    public enum accountStatus 
    { 
        initiated = 1, 
        suspended = 2, 
        closed = 2 
    }
    public enum accountOperationStatus 
    { 
        Approved = 1, 
        NotApproved = 2 
    }
    public enum personOperationStatus
    {
        Approved = 1,
        NotApproved = 2,
        Duplicated=3
    }
    public enum currencyOperationStatus
    {
        Approved = 1,
        NotApproved = 2,
        Duplicated = 3
    }
    public enum entityOperationStatus
    {
        Approved = 1,
        NotApproved = 2
    }
    public enum serviceOperationStatus
    {
        Approved = 1,
        NotApproved = 2,
        Duplicate=3,
        Unknown=4,
        NULL = 4,
    }
    public enum ControllerOperationStatus 
    { 
        Approved = 1, 
        NotApproved = 2 
    }
}
