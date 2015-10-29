﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// 

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace triage.database
{
    public class Thread
    {
        public Thread()
        {
            this.Frames = new HashSet<Frame>();
        }

        public int ThreadId { get; set; }

        public int DumpId { get; set; }

        public string OSId { get; set; }

        public int Number { get; set; }

        public bool CurrentThread { get; set; }

        public virtual ICollection<Frame> Frames { get; set; }

        [ForeignKey("DumpId")]
        public virtual Dump Dump { get; set; }
    }
}
