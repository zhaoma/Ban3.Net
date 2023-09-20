using System;
using System.Collections.Generic;
using System.Text;
using Ban3.Infrastructures.DataPersist.Attributes;


namespace Ban3.Sites.ViaMicrosoft.Entities;
    [TableIs( "Identity", "Identity", true )]
    public class Identity
            : IdentityRef {}
