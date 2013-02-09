﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace accounting.classes.organization
{
    public class Office:Entity
    {
        public readonly int ENTITYTYPEID = (int)enums.entityType.Organization;
        public int officeID;
        public string name;

        public void New() 
        {
            base.New((int)enums.entityType.Office);
        }
    }
}
